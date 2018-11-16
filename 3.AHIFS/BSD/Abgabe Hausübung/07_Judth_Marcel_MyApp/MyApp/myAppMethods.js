module.exports = function () {
    return {
        CreateServer: function (portnum) {
            var http = require("http");
            var port = portnum || process.env.port || 1337;
            var routingtable = [];
            
            return {
                Register: function (reurl, httMethod, callbackfn) {
                    var object = {
                        reurl: reurl,
                        httMethod: httMethod,
                        callbackfn: callbackfn
                    }
                    var result = true;
                    for(var i = 0; i < routingtable.length && result; i++) {
                        if (!routingtable[i] == Object) result = false;
                    }

                    if (result) routingtable.push(object);
                },
                Start: function () {
                    http.createServer(function (req, res) {
                        res.writeHead(200, { 'Content-Type': 'text/plain' });
                        console.log(routingtable.length);
                        for (var idx = 0; idx < routingtable.length; idx++) {
                            if (req.url == '/') res.end("Welcome!");
                            if (routingtable[idx].reurl == req.url) {
                                try {
                                    res.end(routingtable[idx].callbackfn());
                                }
                                catch (error) {
                                    res.end("405: Method not allowed!!" + error);
                                }
                            }
                            else
                                res.end("404: Recource not found");    
                        }
                    }).listen(port);
                }
        
            };
        }
    };
    
}();