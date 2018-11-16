
//creation
var myApp = require('./myAppMethods.js');
var myWebserver = myApp.CreateServer(1337);
var eventHandler = require('./EventHandlers.js');


//konfiguration

myWebserver.Register("/shoppingCartPostAction", "POST", eventHandler.shoppingCartPostAction);
myWebserver.Register("/shoppingCart1", "GET", eventHandler.shoppingCartPage);
myWebserver.Register("/shoppingCart2", "GET", eventHandler.shoppingCartPage2);

myWebserver.Static("Content", 
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
