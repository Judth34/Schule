
module.exports = function () {
    var idx = 0;
    
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
                    responseEnd(res, "", allExtensions["txt"], 413);
            });
            
            req.on('end', function () {
                var obj = splitRequestBody(reqbody);
                str = JSON.stringify(obj, null, 4);
                responseEnd(res, "Your given Date: " + str, 'text/plain', 200);
            });
        },
        
        getTime: function (req, res) {
            var d = new Date();
            var n = d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
            var htmlCode = getValidHtml("<h1>" + n + " </h1>", "Time");
            responseEnd(res, htmlCode, 'text/html', 200);
        },
        
        PageCounter: function (req, res) {
            var htmlCode = getValidHtml("<lable>" + (idx++) + " </lable>");
            responseEnd(res, htmlCode, 'text/html', 200);
        },
        
        PageCounterCheater: function (req, res) {
            var htmlCode = getValidHtml(
            "<form method='post' action='/pageCounter/post'>" +
            "<input type='text' name='idx' />" +
            "<input type='submit' name='Submit' value='Absenden' />" +
            "</form>");
            responseEnd(res, htmlCode, 'text/html', 200);
        },

        pageCounterPostHandle: function (req, res) {
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", allExtensions["txt"], 413);
            });
            
            req.on('end', function () {
                var obj = splitRequestBody(reqbody);
                idx = obj.idx;         
            });

            responseEnd(res, "Successfully cheated", 'text/plain', 200);
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
}();


