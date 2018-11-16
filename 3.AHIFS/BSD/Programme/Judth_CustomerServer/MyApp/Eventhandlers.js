
module.exports = function () {
    var idx = 0;
    var CL = require('./cartLogic.js');
    var CI = CL.registerCustomer("firstname", "lastname", "user", "hallo");
    CL.logout(CI);
    var CI = CL.registerCustomer("firstname", "lastname", "user2", "hallo");
    CL.logout(CI);
    var myApp = require('./myAppMethods.js');
    var myWebserver = myApp.CreateServer(1337);
    return {
        
        dynamicRoute: function (req, res, data) {
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.write(data);
            res.end();
        },
        
        loginPostHandle: function (req, res) {
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "",'text/html' , 413);
            });
            var obj;
            req.on('end', function () {
                var obj = splitRequestBody(reqbody);
                try {
                    CI = CL.login(obj.userName, obj.password);
                    setCookie(res, 'Customer-Id=' + CI);
                    myWebserver.redirect(res, "/shoppingCart.html");
                } catch (Ex) {
                    if (Ex == "1")
                        myWebserver.redirect(res, "/LoginFailWrongUserNameOrPassword.html");
                    if (Ex == "2")
                        myWebserver.redirect(res, "/LoginFailUserIsAlreadyLoggedIn.html");
                    else
                        myWebserver.redirect(res, "unknownError.html");
                }
                
            });
        },
        
        shoppingCart: function (req, res) {
            try {
                if (_getCookie(req) == undefined)
                    throw "No cookie!";
                var id = _getCookie(req).split('=')[1];
                var items = CL.getItems(id);
           
            } catch (Ex) {
                myWebserver.redirect(res, "unknownError.html");
            }
            var innerhtml = "no items";
            if (items != undefined)
                innerhtml = surroundItemWithPTag(items)
            
            try {
                var userString = CL.userToString(id);
            } catch (ex){
                myWebserver.redirect(res, "unknownError.html");
            }
            
            

            var html = getValidHtml(
                 "<img src='Warenkorb.png' />" 
                + "<h1>Your shopping cart from " + userString +":</h1>" 
                + "<ul>"
                + innerhtml 
                + "</ul>" 
                + "<h2>add Item:</h2>"
                + "<form method='post' action='/addItemPostHandle.html'>" 
                + "<lable>item name:</lable>"
                + "<input type='text' name='itemName' /><br />" 
                + "<lable>item quantity:</lable>" 
                + "<input type='text' name='quantity' /><br>" 
                + "<input type='submit' name='Submit' value='Add' />"
                + "</form>"
                + "<p>to logout click <a href='logout.html'>here</a></p>" 

                + "<br /><a href='home.html'>home</a><br />" 
                + "<a href='deleteUser.html'>delete User</a><br />"
                + "<a href='registerCustomer.html'>register Customer</a>"
            );

            responseEnd(res, html, 'text/html', 200);
        },
        
        addItemPostHandle: function (req, res){
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", 'text/html', 413);
            });
            
            req.on('end', function () {
                try {
                    var obj = splitRequestBody(reqbody);
                    var cookie = _getCookie(req).split('=')[1];
                    if (obj.quantity == "")
                        obj.quantity = 1;
                    CL.addItem(obj.itemName, obj.quantity, cookie);
                    myWebserver.redirect(res, "/shoppingCart.html");
                } catch (ex) {
                    console.log(ex);
                    myWebserver.redirect(res, "/shoppingCart.html");
                }
            });
        },

        logout: function (req, res) {
            try {
                var cookie = _getCookie(req);
                var id = cookie.split('=')[1];
                CL.logout(id);
                delCookie(res, cookie);
                myWebserver.redirect(res, "/home.html");
            } catch (Ex) {
                myWebserver.redirect(res, "unknownError.html");
            }
            
        },

        registerPostHandle: function (req, res){
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", 'text/html' , 413);
            });
            var obj;
            req.on('end', function () {
                var obj = splitRequestBody(reqbody);
                try {
                    CI = CL.registerCustomer(obj.FirstName, obj.LastName, obj.userName, obj.password);
                    setCookie(res, 'Customer-Id=' + CI);
                    myWebserver.redirect(res, "/shoppingCart.html");
                } catch (Ex) {
                    if (Ex == "1")
                        myWebserver.redirect(res, "/LoginFailWrongUserNameOrPassword.html");
                    if (Ex == "2")
                        myWebserver.redirect(res, "/LoginFailUserIsAlreadyLoggedIn.html");
                    if (Ex == "3")
                        myWebserver.redirect(res, "/alreadyRegistered.html");
                    else
                        myWebserver.redirect(res, "unknownError.html");
                }
                
            });
        },

        deleteUserPostHandle: function (req, res){
            try {
                var reqbody = '';
                req.on('data', function (data) {
                    reqbody += data;
                    if (reqbody.length > 1e7)
                        responseEnd(res, "", 'text/html' , 413);
                });
                var obj;
                req.on('end', function () {
                    try {
                        var obj = splitRequestBody(reqbody);
                        CL.removeCustomer(obj.userName);
                        myWebserver.redirect(res, "/home.html");
                    } catch (Ex) {
                        if (Ex == "1")
                            myWebserver.redirect(res, "/DeleteWrongUserName.html");
                        else
                            myWebserver.redirect(res, "unknownError.html");
                    }
                   
                });
            } catch (Ex) {
                myWebserver.redirect(res, "unknownError.html");
            }
        }
    }
    
    function surroundItemWithPTag(allitems){
        var innerhtml = "";

        allitems.forEach(function (e) {
            innerhtml += "<li>article: " + e.item + ", quantity: " + e.quantity + "</li>";
        });

        return innerhtml;
    }

    function responseEnd(res, data, contentType, statusCode) {
        res.writeHead(statusCode, { 'Content-Type': contentType });
        res.end(data);
    }

    function splitRequestBody(body) {
        var querystring = require('querystring');
        return querystring.parse(body);
    }
    
    function getValidHtml(innerHtml, title){
        return "<!DOCTYPE html>" +

                "<html xmlns='http://www.w3.org/1999/xhtml'>" + 
                "<head>" + 
                "<meta charset='utf-8' />" + 
                "<title>" + title + "</title>" + 
                "</head>" +
                "<body>" +
                innerHtml +
                "</body>" +
                "</html>";
    }
    
    function _getCookie(httpMessage){
        return httpMessage.headers.cookie;
    }

    function setCookie(httpMessage, cookieString){
        httpMessage.setHeader('set-cookie', cookieString);
    }

    function delCookie(response, cookieStr){
        var d = new Date();
        cookieStr += "; Expires = " + d.toUTCString();
        setCookie(response, cookieStr);
    }
}();


