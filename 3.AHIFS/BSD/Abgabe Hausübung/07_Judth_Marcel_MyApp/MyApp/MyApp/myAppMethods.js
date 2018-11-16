module.exports = function () {
    return {

        CreateServer: function (portnum) {
            var http = require("http");
            var port = portnum || process.env.port || 1337;
            var routingtable = [];
            var whitelistExt = getHashMapExt();
            var routingtableFiles = [];
            console.log("<<<<<<<<<<<<<<<<<<<<<<<<Welcome to The Server>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            
            
            return {
                Register: function (reurl, httpMethod, callbackfn) {
                    
                    //url auf valid überprüfen
                    if (urlValid(reurl)) {
                        var object = {
                            reurl: reurl,
                            httpMethod: httpMethod,
                            callbackfn: null
                            
                        }   
                        //prove if object is in the array
                        if (!contains(object, routingtable)) {
                            if(typeof(callbackfn) === "function" ) {
                                object.callbackfn = callbackfn;
                                routingtable.push(object);
                            }
                        }
                    }               
                },
                Start: function () {
                    http.createServer(function (req, res) {
                        res.writeHead(200, { 'Content-Type': 'text/plain' });
                        if (urlValid(req.url)) {
                            
                            if (req.url == '/' || req.url == '') {
                                res.end("Welcome!");
                            } else {

                                var ext = getUrlExtension(req.url);
                                var filepath = getFilePathFromUrl(req.url);

                                if (isStatic(req.url) && contains(filepath, routingtableFiles) && fileIsAvailable(filepath)) {
                                    var fs = require("fs");
                                    var contentType = whitelistExt[ext];
                                    res.writeHead(200, { 'Content-Type': contentType });
                                    fs.readFile(filepath, function (error, data) {
                                        if (error) res.end("error: File not found!");
                                        res.end(data);
                                    });
                                } else {
                                    var arr = routingtable.filter(function (e) { return (e.reurl == req.url); });
                                    var answer;
                                    if (arr.length > 0) {
                                        try {
                                            res.end(arr[0].callbackfn());
                                        } catch (ex) {
                                            res.end("Sorry there is an error: " + ex);
                                        }

                                    } else {
                                        res.writeHead(404, { 'Content-Type': 'text/plain' });
                                        res.end();
                                    }
                                }
                            }
                        } else {
                            res.writeHead(400, { 'Content-Type': 'text/plain' });
                            res.end();
                        }
                    }).listen(port);
                },
                Static: function (filename) {
                    filename = getFilePathFromUrl(filename);
                    if (fileIsAvailable(filename)) {
                        routingtableFiles.push(filename);
                    }
                }
        
            };
            
            function urlValid(_url) {
                //to do: see if url has the right pattern like /.../ or aplhanum.alpha
                var regEx = /^\/([w*.\w*\/])*/;
                return regEx.test(_url);
            }
            
            function contains(object, arr) { 
                return arr.some(function (e) { return (object == e); });
            }

            function isStatic(reurl) {
                var urlSplitted = reurl.split('.');
                if (urlSplitted.length > 1) return true;
                return false;
            }

            function getFilePathFromUrl(url) {
                //return ".\\content\\" + url.split("/");
                var splittedUrl = url.split("/");

                if (splittedUrl.length > 1) {
                    var filepath = "";
                    splittedUrl.forEach(function (e, idx, arr) { 
                        if (idx != 0) arr[idx] = "\\" + arr[idx];
                    });
                    splittedUrl[0] = "." + splittedUrl[0];
                    for (var idx = 0; idx < splittedUrl.length; idx++) {
                        filepath += splittedUrl[idx];
                    }
                    return filepath;
                }
                else
                    return ".\\" + filepath[filepath.length - 1];
            }
            function getUrlExtension(url) { 
                return url.split('.')[1];
            }
            function fileIsAvailable(filePath) {
                //See if file is at the given filePath             
                
                var fs = require("fs");
                try {
                    fs.exists(filePath, function (exist) {
                        if (!exist) throw "file not found!";
                    });
                    return true;
                } catch (err) {
                    return false;
                }
            }
            function whitelistContainsExt(ext){
                var result = false;                
                // Get the size of an object
                if (whitelistExt[ext] != undefined) return true;
                return false;
            }
            function getHashMapExt(){
                var obj = {};
                obj['html'] = 'text/html';
                obj['txt'] = 'text/plain';
                obj['js'] = 'application/javascript';
                obj['css'] = 'text/css';
                obj['png'] = 'text/html';

                return obj;
            }
          
        }

    };
    
}();