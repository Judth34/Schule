
//creation
var myApp = require("./myAppMethods.js");
var myWebserver = myApp.CreateServer(1337);
var eventHandler = require('./EventHandlers.js');


//konfiguration

myWebserver.Register("/loginPostHandle", "POST", eventHandler.loginPostHandle);
myWebserver.Register("/shoppingCart.html", "GET", eventHandler.shoppingCart);
myWebserver.Register("/addItemPostHandle.html", "GET", eventHandler.addItemPostHandle);
myWebserver.Register("/logout.html", "GET", eventHandler.logout);
myWebserver.Register("/registerPostHandle", "GET", eventHandler.registerPostHandle);
myWebserver.Register("/deleteUserPostHandle", "GET", eventHandler.deleteUserPostHandle);

//static-mode
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
