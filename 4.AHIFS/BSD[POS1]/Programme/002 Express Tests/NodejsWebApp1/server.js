var http = require('http');
var port = process.env.port || 1337;
var express = require('express');
var app = express();

app.set('port', process.env.PORT || 3000);

app.get('/', function (req, res) {
    res.status(404).send('Sorry cant find that!');
});

app.listen(app.get('port'), function(){
console.log('Express started press ctrl-c to terminate');
});

app.use('/static', express.static('public'));
