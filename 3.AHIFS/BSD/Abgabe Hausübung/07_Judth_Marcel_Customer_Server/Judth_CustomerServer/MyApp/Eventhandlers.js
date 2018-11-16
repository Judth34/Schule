
module.exports = function () {
    var idx = 0;
    var CL = require('./cartLogic.js');
    CL.registerCustomer("User", "Name", "user1", "hallo");
    CL.registerCustomer("User", "Name", "user2", "hallo");
    CL.registerCustomer("User", "Name", "user3", "hallo");
    CL.registerCustomer("User", "Name", "user4", "hallo");
    var myApp = require('./myAppMethods.js');
    var myWebserver = myApp.CreateServer(1337);
    return {
        
        dynamicRoute: function (req, res, data) {
            res.writeHead(200, { 'Content-Type': 'text/plain' });
            res.write(data);
            res.end();
        },
        
        postHandle: function (req, res) {
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", 'text/plain', 413);
            });
            
            req.on('end', function () {
                var obj = splitRequestBody(reqbody);
                str = JSON.stringify(obj, null, 4);
                responseEnd(res, "Your given Date: " + str, 'text/plain', 200);
            });
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
                    var CI = CL.login(obj.userName, obj.password);
                    setCookie(res, 'Customer-Id=' + CI);
                    myWebserver.redirect(res, "/shoppingCart.html");
                } catch (Ex) {
                    myWebserver.redirect(res, "/loginFail.html");
                }
                
            });
        },
        
        shoppingCart: function (req, res) {
            var cookie = _getCookie(req).split('=')[1];
            var items = CL.getItems(cookie);
            var innerhtml = "no items";
            if (items != undefined)
                innerhtml = surroundItemWithPTag(items)
            
            var html = getValidHtml(
                 "<img src='Warenkorb.png' />" 
                + "<h1>Your shopping cart:</h1>" 
                + innerhtml 
                + "<h2>add Item:</h2>"
                + "<form method='post' action='/addItemPostHandle.html'>" 
                + "<lable>item name:</lable>"
                + "<input type='text' name='itemName' /><br />" 
                + "<lable>item quantity:</lable>" 
                + "<input type='text' name='quantity' /><br>" 
                + "<input type='submit' name='Submit' value='Add' />"
                + "</form>"
                + "<p>to logout click <a href='logout.html'>here</a></p>"
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
                var obj = splitRequestBody(reqbody);
                var cookie = _getCookie(req).split('=')[1];
                CL.addItem(obj.itemName, obj.quantity, cookie);
                myWebserver.redirect(res, "/shoppingCart.html");
            });
        },

        logout: function (req, res) {
            var cookie = _getCookie(req);
            var id = cookie.split('=')[1];
            CL.logout(id);
            delCookie(res, cookie);
            myWebserver.redirect(res, "/home.html");
        },

        loginFail: function (req, res) {
            var html = getValidHtml(
                "<img src='Warenkorb.png' />" 
               + "<p>There was an error!</p>"
               + "<p>Please try again <a href='home.html'>here</a></p>"
            );
            responseEnd(res, html, 'text/html', 200);

        },
        
    }
    
    function surroundItemWithPTag(allitems){
        var innerhtml = "";

        allitems.forEach(function (e) {
            innerhtml += "<p>article: " + e.item + ", quantity: " + e.quantity + "</p>";
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


