var http = require('http');
var port = process.env.port || 1337;
http.createServer(function (req, res) {
    var message = "<h1>This is a h1 maybe</h1>";
    if (req.url == "/HelloWorldAsText")
        res.writeHead(200, { 'Content-Type': 'text/text' });
    else
        if (req.url == "/HelloWorldAsHTML")
            res.writeHead(200, { 'Content-Type': 'text/html' });
        else
            message = "Answer from Node Web Server!";
    res.end(message);
}).listen(port);
console.log("Server is up and running");