module.exports = function () {
    return {
        CreateServer: function (portnum) {
            var folder;
            var http = require("http");
            var port = portnum || process.env.port || 1337;
            var routingtable = [];
            var allExtensions;
            var fs = require("fs");
            var staticMode = false;
            
            return {
                Register: _register,
                Start: _start,
                Static: _static
            };
            
            function _register(reurl, httpMethod, callbackfn) {
                if (!urlValid(reurl))
                    throw "Url is not valid!";
                var obj = {
                    reurl: reurl,
                    httpMethod: httpMethod,
                    callbackfn: null
                }
                
                if (routeAlreadyRegistered(obj, routingtable))
                    throw "Route is already registered!";
                
                if (typeof (callbackfn) === "function") {
                    obj.callbackfn = callbackfn;
                    routingtable.push(obj);
                }
                else
                    throw "type of callbackfunction is not function"
            }
            
            function _start() {
                if (!staticMode && routingtable.length == 0)
                    throw "Nothing was registered and you are not in static mode!!";
                http.createServer(function (req, res) {
                    
                    if (!urlValid(req.url))
                        responseEnd(res, "", allExtensions['text'], 400);
                    
                    var extension = getUrlExtension(req.url);
                    var filepath = getFilePathFromUrl(req.url);
                    var fileStatus = false;
                    
                    if (isStatic(req.url) && extentionExsist(extension) && fileIsAvailable(filepath)) {
                        fileStatus = true;
                        var contentType = allExtensions[extension];
                        fs.readFile(filepath, function (error, data) {
                            if (error) fileStatus = false;
                            else 
                                responseEnd(res, data, contentType, 200);
                        });
                    }
                    
                    if (!fileStatus) {
                        var arr = routingtable.filter(function (e) { return (e.reurl == req.url); });
                        
                        if (arr.length > 0) {
                            try {
                                arr[0].callbackfn(req, res);
                            } catch (ex) {
                                responseEnd(res, "Sorry there is an error: " + ex, allExtensions['txt'], 200);
                            }

                        } else {
                            responseEnd(res, "", allExtensions['txt'], 404);
                        }
                        
                    }
                }).listen(port);
            }
            
            function _static(_folder, _extensions) {
                folder = _folder;
                allExtensions = _extensions;
                staticMode = true;
            }
            
            function urlValid(_url) {
                //to do: see if url has the right pattern like /.../ or aplhanum.alpha
                var regEx = /^\/([w*.\w*\/])*/;
                return regEx.test(_url);
            }
            
            function contains(object, arr) {
                return arr.some(function (e) { return (object == e); });
            }
            
            function routeAlreadyRegistered(object, arr) {
                return arr.some(function (e) { return ((object.reurl == e.reurl) && (object.httpMethod == e.httpMethod)); });
            }
            
            function isStatic(reurl) {
                var urlSplitted = reurl.split('.');
                if (urlSplitted.length > 1) return true;
                return false;
            }
            
            function getFilePathFromUrl(url) {
                return ".\\" + folder + "\\" + url.split('/')[1];
            }
            
            function getUrlExtension(url) {
                return url.split('.')[1];
            }
            
            function fileIsAvailable(filePath) {
                if (fs.existsSync(filePath))
                    return true;
                return false;
            }
            
            function extentionExsist(extension) {
                return (allExtensions[extension] != undefined);
            }
            
            function responseEnd(res, data, contentType, statusCode) {
                res.writeHead(statusCode, { 'Content-Type': contentType });
                res.end(data);
            }

        }


    };
    
    
    
}();