// =============================================================================


var express    = require('express'); 
var sessionManager = require('../LogicLayer/BL/sessionRaterBL.js');
var ratingRouter = express.Router(); 


        //REQUESTS
        ratingRouter.get('/', function(req, res){
            sessionManager.getRatings(
                (sqlResult) => {
                    res.json(sqlResult);
                },(sqlError) => {
                    res.status(500).send(sqlError);
                }
            );
        });

        ratingRouter.get('/:Id/ratings', function(req, res) {
            let sessionId = req.params.Id;
            sessionManager.getRatingsForSession(sessionId,
                (sqlResult) => {
                    res.json(sqlResult);
                },(sqlError) => {
                    res.status(500).send(sqlError);
                }
            );
        });

        ratingRouter.get('/:Id/ratings/:ratingId', function(req, res) {
            let sessionId = req.params.Id;
            let ratingId = req.params.ratingId;
            sessionManager.getRatingsForSessionById(sessionId,ratingId,
                (sqlResult) => {
                    res.json(sqlResult);
                },(sqlError) => {
                    res.status(500).send(sqlError);
                }
            );
        });

        ratingRouter.post('/',function(req,res){
            let sessionId = req.body.sessionId;
            
            sessionManager.rateSession(sessionId,req.body.ratingValue,req.body.evaluator,
                (sqlResult) => {
                    res.json(sqlResult);
                },(sqlError) => {
                    res.status(500).send(sqlError);
                }
            );
        });

        ratingRouter.delete('/:IdRating', function(req,res){
            try{
                var sess = sessionManager.getSessionByID(parseInt(req.params.Id));
                sess.deleteRating(req.params.IdRating);
                res.status(202).send({message:"rating deleted"});
            }catch(error){
                res.status(404).send(error.toString());
            }
        });

module.exports = ratingRouter;