// =============================================================================


var express    = require('express'); 

var defaultrouter = express.Router(); 


//REQUESTS
defaultrouter.get('/', function(req, res) {
    res.json({ message: 'hooray! api session Rater Backend!' ,
            sessions: 'http://localhost:8080/api/sessions',
            ratings: 'http://localhost:8080/api/ratings'});   
    }
);

module.exports = defaultrouter;