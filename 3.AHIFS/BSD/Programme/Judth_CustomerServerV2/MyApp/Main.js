
//creation
var myApp = require("./myAppMethods.js");
var myWebserver = myApp.CreateServer(1337);
var eventHandler = require('./EventHandlers.js');


//konfiguration
myWebserver.Register('/getAllArticles', 'GET', eventHandler.getArticles);
myWebserver.Register('/addNewAvailableArticle', 'GET', eventHandler.addNewAvailableArticle);
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
