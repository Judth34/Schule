
//creation
var myApp = require("./myAppMethods.js");
var myWebserver = myApp.CreateServer(1337);
var eventHandler = require('./EventHandlers.js');


//konfiguration
myWebserver.Register("/", "GET", function (req, res) {
    eventHandler.dynamicRoute(req, res, "Welcome to the website")
});
myWebserver.Register("/sayhello", "GET", function (req, res) {
    eventHandler.dynamicRoute(req, res, "I am not going to say hello :P");
});
myWebserver.Register("/index.btml", "GET", function (req, res) {
    eventHandler.dynamicRoute(req, res, "dynamic Route !!");
});


myWebserver.Register("/post", "POST", eventHandler.postHandle);
myWebserver.Register("/loginPostHandle", "POST", eventHandler.loginPostHandle);
myWebserver.Register("/shoppingCart.html", "GET", eventHandler.shoppingCart);
myWebserver.Register("/addItemPostHandle.html", "GET", eventHandler.addItemPostHandle);
myWebserver.Register("/logout.html", "GET", eventHandler.logout);
myWebserver.Register("/loginFail.html", "GET", eventHandler.loginFail);



myWebserver.Static("content", 
    {
    'html': 'text/html',
    'txt': 'text/plain',
    'js': 'application/javascript',
    'css': 'text/css',
    'png': 'text/html'
});

//run
myWebserver.Start();
console.log("Server is up and running");
console.log("<<<<<<<<<<<<<<<<<<<<<<<<Welcome to The Server>>>>>>>>>>>>>>>>>>>>>>>>>>>");
