var myApp = require('./MyAppMethods.js');
var myWebserver = myApp.CreateServer(1337);
myWebserver.Register("/", "GET", function () { return 'Welcome to the Chat Web Server'; });
myWebserver.Register("/Sers", "GET", function () { return 'hallo'; });
myWebserver.Register("/sayHello", "GET", function () { return 'hello'; });
myWebserver.Static("content", 
    {
    'html': 'text/html',
    'txt': 'text/plain',
    'js': 'application/javascript',
    'css': 'text/css',
    'png': 'text/html'
});
myWebserver.Start();
console.log("hallo");