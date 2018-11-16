// session  RaterMain.js

// BASE SETUP
// =============================================================================

// call the packages we need
var express    = require('express');        // call express
var app        = express();                 // define our app using express
var bodyParser = require('body-parser');
var sessionManager = require('./LogicLayer/BL/sessionRaterBL.js');
var SessionException = require('./LogicLayer/BL/SessionException.js');

// configure app to use bodyParser()
// this will let us get the data from a POST
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || 8080;        // set our port

// ROUTES FOR OUR API
// =============================================================================
var defaultrouter = require('./ServiceLayer/defaultRouter.js');
var speakerRouter = require('./ServiceLayer/SpeakerRouter.js');  
var sessionRouter = require('./ServiceLayer/SessionRouter.js');
var ratingRouter  = require('./ServiceLayer/RatingRouter.js');  


// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api
app.use(express.static('./Backend_blaschkj/Frontend'));
app.use('/api', defaultrouter);
defaultrouter.use('/sessions',sessionRouter);
defaultrouter.use('/ratings',ratingRouter);
sessionRouter.use('/',ratingRouter);
defaultrouter.use('/speakers',speakerRouter);

// START THE SERVER
// =============================================================================
app.listen(port);
console.log('Magic happens on port ' + port);

