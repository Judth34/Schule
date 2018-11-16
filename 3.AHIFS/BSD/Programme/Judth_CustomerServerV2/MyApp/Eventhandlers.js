
module.exports = function () {
    var idx = 0;
    var myWebShop = require('./webShopLogic.js');
    var myApp = require('./myAppMethods.js');
    var myWebserver = myApp.CreateServer(1337);
    return {
        getArticles: _getAllArticles,

        addNewAvailableArticle: function (req, res){
            var reqbody = '';
            req.on('data', function (data) {
                reqbody += data;
                if (reqbody.length > 1e7)
                    responseEnd(res, "", 'text/html' , 413);
            });
            var obj;
            req.on('end', function () {
                var newArticle = {};
                switch (req.headers['content-type'].split(';')[0]) {
                    case "multipart/form-data":
                        console.log("multipart:");
                        console.log(reqbody);
                        var newArticle = _splitMultipartFormat(reqbody);
                        myWebShop.addAvailableArticle(newArticle);
                        _getAllArticles(req, res);
                        break;

                    case "application/x-www-form-urlencoded":
                        console.log("www-url-encoded:");
                        console.log(reqbody);
                        var querystring = require('querystring');
                        newArticle = querystring.parse(reqbody);
                        myWebShop.addAvailableArticle(newArticle);
                        _getAllArticles(req, res);
                        break;

                    case "application/json":
                        console.log("json:");
                        console.log(reqbody);
                        newArticle = JSON.parse(reqbody);
                        myWebShop.addAvailableArticle(newArticle);
                        _getAllArticles(req, res);
                        break;
                }
        
            });
        }

    }
    
    function _splitMultipartFormat(reqbody){
        var s = reqbody.split(';');
        s = reqbody.split('\r\n\r');
        var arr = [];
        var str = "";
        s.forEach(function (e, index) {
            arr = e.split("\r\n");
            arr.forEach(function (e1, index1) {
                str += e1;
            });
        });

        arr = str.split(':');
        var arr1 = [];
        str = "";
        arr.forEach(function (e) {
            arr1.push(e.split('------')[0]);
        });
        

        arr = arr1;
        str = "";
        arr1 = [];
        arr.forEach(function (e) {
            arr1.push(e.split(';')[1]);
        });

        arr = arr1;
        arr1 = [];
        arr.forEach(function (e, index) {
            if (index != 0) {
                arr1.push(e.split('=')[1]);
            }
        });

        arr = arr1;
        arr1 = [];
        var arr2 = [];
        arr.forEach(function (e) {
            arr1.push(e.split('"')[1]);
            arr2.push(e.split('"')[2].split('\n')[1]);
        });
 
        var obj = {};
        arr1.forEach(function (e, index) {
            obj[e] = arr2[index];
        });
        return obj;
    }

    function _getAllArticles(req, res){
        var allArticles = myWebShop.getArticles();
        res.setHeader('Cache-Control', 'no-cache');
        res.setHeader("Content-Type", 'application/json');
        res.write(JSON.stringify(allArticles));
        res.end();
    }
}();


