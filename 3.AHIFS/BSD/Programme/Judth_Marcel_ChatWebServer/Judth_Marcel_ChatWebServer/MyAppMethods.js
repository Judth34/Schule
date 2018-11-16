

module.exports = function (){
    return {
        CreateServer: function (portnum){
            var routingtable = [];
            var http = require("http");
            var port = portnum || process.env.port || 1337;
            var staticMode = false;
            var allExtensions = [];
            var dataFolder = "";
            return {
                Register: _register,
                Start: _start,
                Static: _static
            }

            function _register(reurl, httpMethod, callbackfcn) {
                if (!_urlValid(reurl))
                    throw "url is not valid";

                if (httpMethod != "GET" && httpMethod != "POST")
                    throw "type of httpMethod is not 'POST' or 'GET'";
                
                if (typeof (callbackfcn) != "function" ) 
                    throw "callbackfunction is not function";
                
                var obj = {
                    reurl: reurl,
                    httpMethod: httpMethod,
                    callbackfcn: callbackfcn
                };

                if (_urlAlreadyRegistered(obj))
                    throw "url is already registered!";

                routingtable.push(obj);
            }
            
            function _start(){
                if (routingtable.length == 0 || staticMode == false)
                    throw "Error: nothing is registered and you are not in static mode";
                http.createServer(function (req, res) {
                    if (!_urlValid(req.url))
                        _resEnd(res, 400, allExtensions['txt'], '');
                    else {
                        console.log("out here: " + _urlIsStaticRoute(req.url));
                        if (_urlIsStaticRoute(req.url)) {
                            console.log("We did it");
                        } else {
                            var registeredObj = _getRegisteredObjectFromUrl(req.url);
                            if (registeredObj == undefined)
                                _resEnd(res, 404, allExtensions['txt'], '');
                            else
                                _resEnd(res, 200, allExtensions['txt'], registeredObj.callbackfcn());
                        }                        
                    }
                }).listen(port);
            }
            
            function _static(folder, allextensions){
                allExtensions = allextensions;
                staticMode = true;
                dataFolder = folder;
            }

            function _urlValid(url){
                var regEx = /^\/([w*.\w*\/])*/;
                return regEx.test(url);
            }

            function _urlAlreadyRegistered(obj){
                return routingtable.some(function (e) {
                    return e.reurl == obj.reurl;
                });
            }

            function _resEnd(res, statuscode, contentType, data){
                res.writeHead(statuscode, { 'Content-Type': contentType });
                res.end(data);
            }

            function _getRegisteredObjectFromUrl(reurl){
                return routingtable.filter(function (e) {
                    if (e.reurl == reurl)
                        return e.callbackfcn;
                })[0];
            }

            function _urlIsStaticRoute(reurl){
                var urlFileExtension = reurl.split('.');
                console.log(_urlFileExtensionIsRegistered(urlFileExtension[urlFileExtension.length - 1]));
                return (urlFileExtension.lenth > 1 && _urlFileExtensionIsRegistered(urlFileExtension[urlFileExtension.length - 1]));
            }

            function _urlFileExtensionIsRegistered(urlFileExtension) {
                return allExtensions[urlFileExtension] != undefined;
            }
        }
    };
}();