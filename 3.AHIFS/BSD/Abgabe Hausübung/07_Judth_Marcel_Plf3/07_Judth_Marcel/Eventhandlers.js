
module.exports = function () {
    var idx = 0;
    var allItems = [];
    return {
        
        shoppingCartPage: function (req, res){
            var items = "";
            if (allItems.length == 0) {
                items = "no articles in cart";
            } else {
                items = "<ul>";
                allItems.forEach(function (e) { 
                    items += "<li>" + e.data + ": " + e.idx + "</li>";
                });
                items += "</ul>";
            }
            
            var html = getValidHtml(
                "<img src='Unbenannt.png' />" +
                "<p>Click at <a href='shoppingCart2'>cart</a> to add new articles</p>" +
                "<p id='items'>" + items + "</p>"
            );
            responseEnd(res, html, 'text/html', 200);
        },
        
        shoppingCartPage2: function (req, res) {
            var items = "";
            if (allItems.length == 0) {
                items = "no articles in cart";
            } else
                items = allItems.toString();
            
            var html = getValidHtml(
                "<img src='Unbenannt.png' />" +
                "<form method='post' action='/shoppingCartPostAction'>" + 
                "<input type='text' name='Item' />" +
                "<input type='submit' name='Submit' value='add new article' />" +
                "</form>"
            );
            responseEnd(res, html, 'text/html', 200);
        },

        shoppingCartPostAction: function (req, res){
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", allExtensions["txt"], 413);
            });
            
            req.on('end', function () {
                var bodyobj = splitRequestBody(reqbody);
                var result = false;
                var elements = allItems.filter(function (e) {
                    return (bodyobj.Item == e.data); 
                });
                if (elements.length > 0) {
                    elements[0].idx++;
                } else {
                    var obj = {
                        data: bodyobj.Item,
                        idx: 0
                    }
                    allItems.push(obj);
                }
                
                
            });
            
            var html = getValidHtml(
                "<img src='Unbenannt.png' />" +
                "<h1>Operation performed</h1>" + 
                "<p>Go back to the cart <a href='shoppingCart1'>here</a></p>"
            );

            responseEnd(res, html, 'text/html', 200);
        }
    }
    
    function responseEnd(res, data, contentType, statusCode) {
        res.writeHead(statusCode, { 'Content-Type': contentType });
        res.end(data);
    }
    
    function splitRequestBody(body) {
        var querystring = require('querystring');
        return querystring.parse(body);
    }
    
    function getValidHtml(innerHtml, title) {
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
}();


