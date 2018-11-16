var express    = require('express');        // call express
var sessionRouter = express.Router();
var sessionManager = require('../LogicLayer/BL/SessionRaterBL');
var APILink = 'http://localhost:8080/api';
//sessionManager.createTestData();

// test route to make sure everything is working (accessed at GET http://localhost:8080/api)

sessionRouter.get('/', function(req, res){
    sessionManager.getSessions(
        (sqlResult) => {
            res.json(sqlResult);
        },
        (sqlError) =>{
            res.json(sqlError);
        }
    );
});

sessionRouter.get('/:id', function(req, res){
    sessionManager.getSessionByID(req.params.id,
        (sqlResult) => {
            res.json(sqlResult);
        },
        (sqlError) =>{
            res.json(sqlError);
        }
    );
});

sessionRouter.post('/', function(req, res){
    // var newSessionObject = req.body;
    // var newSession = sessionManager.createSession(newSessionObject.title, newSessionObject.speaker);
    // var sessionLink = APILink + '/sessions/' + newSession.ID;
    // res.status(201).json({session : sessionLink});

    var newSessionObject = req.body;
    var newSession = sessionManager.createSession(newSessionObject.title, parseInt(newSessionObject.speaker), 
    (sqlResult) => {
        res.json("Inserted!");
    }, 
    (sqlError) => {
        res.status(500).send(sqlError);
    });
});

sessionRouter.delete('/:id', function(req, res){
    // console.log(typeof(req.params.id));
    // sessionManager.deleteSession(parseInt(req.params.id));
    // res.json({message: 'Session with id: ' + req.params.id + ' deleted!',
    //           sessions: APILink + '/sessions'
    // });
    console.log("id: " + req.params.id);
    sessionManager.deleteSession(parseInt(req.params.id), 
    (sqlResult) => {
        res.json("deleted!");
    },
    (err) => {
        res.status(500).send(err);
    });
});

module.exports = sessionRouter;