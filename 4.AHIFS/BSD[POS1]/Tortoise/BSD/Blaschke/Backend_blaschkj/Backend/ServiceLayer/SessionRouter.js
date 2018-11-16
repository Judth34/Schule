// =============================================================================


var express    = require('express'); 
var sessionManager = require('../LogicLayer/BL/sessionRaterBL.js');
var sessionRouter = express.Router();


// test route to make sure everything is working (accessed at GET http://localhost:8080/api)



    //session router
        sessionRouter.get('/', function(req, res) {
            
            console.log("here");
            sessionManager.getSessions(
              (sqlResult) => {
                res.json(sqlResult);
              },(sqlError) => {
                res.status(500).send(sqlError);
              }
            );   
        });

        sessionRouter.get('/:Id', function(req, res) {
            var session;
            try {
                sessionManager.getSessionByID(req.params.Id,
                    (sqlResult) => {
                        res.json(sqlResult);
                    },(sqlError) => {
                        res.status(500).send(sqlError);
                    }
                );

            } catch (error) {
                res.status(404).send(error.toString());
            }  
        });

        sessionRouter.post('/', function (req,res){
            var newSessionObject = req.body;
            var result = sessionManager.createSession(newSessionObject.title,newSessionObject.speaker,
                (sqlResult) => {
                    res.status(201).send({message : "session created"});
                },(sqlError) =>{
                    res.status(500).send(sqlError);
                }
            );
        });

        sessionRouter.delete('/:Id',function(req,res){
            try{
               let sessionId = parseInt(req.params.Id); 

                sessionManager.deleteSession(sessionId,
                    (sqlResult) => {
                        res.status(200).send({message : "session deleted"});
                    },(sqlError) => {
                        res.status(500).send(sqlError);
                    }
                );

            }catch(error){
                res.status(500).send(error.toString());
            }
        });

module.exports = sessionRouter;