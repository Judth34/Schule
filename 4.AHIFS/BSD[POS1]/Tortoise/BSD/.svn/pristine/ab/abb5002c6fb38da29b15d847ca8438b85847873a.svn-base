// server.js

// BASE SETUP
// =============================================================================

// call the packages we need
var express    = require('express');        // call express
var app        = express();                 // define our app using express
var bodyParser = require('body-parser');
var sessionManager = require('./LogicLayer/BL/sessionRaterBl');
var APILink = 'http://localhost:8080/api';
//sessionManager.createTestData();

// configure app to use bodyParser()
// this will let us get the data from a POST
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(express.static('Frontend'));

var port = process.env.PORT || 8080;        // set our port

// ROUTES FOR OUR API
// =============================================================================
var defaultRouter = require('./ServiceLayer/defaultRouter.js');              // get an instance of the express Router

var sessionRouter = require('./ServiceLayer/sessionRouter');
var ratingRouter = require('./ServiceLayer/ratingRouter');
var speakerRouter = require('./ServiceLayer/speakerRouter');

// more routes for our API will happen here

// REGISTER OUR ROUTES -------------------------------
// all of our routes will be prefixed with /api 
app.use('/api', defaultRouter);
defaultRouter.use('/sessions', sessionRouter);
defaultRouter.use('/speakers', speakerRouter);
defaultRouter.use('/ratings', ratingRouter);
sessionRouter.use('/', ratingRouter);

// START THE SERVER
// =============================================================================
app.listen(port);
console.log('Magic happens on port ' + port);
