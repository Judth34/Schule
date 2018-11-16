var myApp = require("./myAppMethods.js");
var myWebserver = myApp.CreateServer(1337);
myWebserver.Register("/sayhello", "GET", function () { throw "it is just a test!"; });
myWebserver.Register("/index.btml", "GET", function () { return "index.btml is registered and showed!" });
myWebserver.Static("/content/Pages/home.html");//überprüfen ob File vorhanden ist und dan in eine eigene routingtable speichern
myWebserver.Static("/content/Stylesheets/Stylesheet1.css");
myWebserver.Static("/content/Pictures/Logo.png");
myWebserver.Static("/content/Scripts/Script1.js");

myWebserver.Start();
console.log("Server is up and running");

