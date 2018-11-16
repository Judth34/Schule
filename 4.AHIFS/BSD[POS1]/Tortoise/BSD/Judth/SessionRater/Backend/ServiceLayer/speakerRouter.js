var express    = require('express');        // call express
var defaultRouter = express.Router({mergeParams: true});
var APILink = 'http://localhost:8080/api';
var srManager = require('../LogicLayer/BL/SessionRaterBL')

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)
defaultRouter.get('/', function(req, res) {
    srManager.getSpeakers(
        (sqlResult) => {
            res.json(sqlResult);
        },
        (sqlError) => {
            res.json(sqlError);
        }
    );
});

module.exports = defaultRouter;