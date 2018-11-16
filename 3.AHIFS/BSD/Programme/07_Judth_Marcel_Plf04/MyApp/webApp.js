
//creation
var myApp = require('./webServer.js');
var myWebserver = myApp.CreateServer(1337);
var eventHandler = require('./WebApp_Eventhandlers.js');


//konfiguration
myWebserver.Register("/generateTableData", "POST", eventHandler.generateTableData);

//static-mode
myWebserver.Static("content", 
    {
    'html': 'text/html',
    'js': 'application/javascript',
});

//run
myWebserver.Start();
console.log("Server is up and running");
console.log("<<<<<<<<<<<<<<<<<<<<<<<<Welcome to The Server>>>>>>>>>>>>>>>>>>>>>>>>>>>");
