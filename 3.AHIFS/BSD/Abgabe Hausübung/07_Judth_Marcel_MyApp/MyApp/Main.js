var myApp = require("./myAppMethods.js");
var myWebserver = myApp.CreateServer(1337);
myWebserver.Register("/sayhello", "GET", function () { return "hello";})
myWebserver.Start();