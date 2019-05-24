var express    = require('express');        // call express
var defaultRouter = express.Router();
var APILink = 'http://localhost:8080/api';

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)
defaultRouter.get('/', function(req, res) {
    var host = 'http://localhost:8080/api'
    res.json({ message: 'Welcome to the API Session Rater Backend',
               sessions: APILink + '/sessions',
               ratings : host + '/ratings',
               speaker: host + '/speakers'
    });
});

module.exports = defaultRouter;
