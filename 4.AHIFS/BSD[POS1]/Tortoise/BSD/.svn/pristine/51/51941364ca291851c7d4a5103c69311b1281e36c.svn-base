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

ratingRouter.get('/:id/ratings', function(req, res) {
    try {
        if(!req.params.id){
            // console.log("Servas");
            // sessionManager.getRatings(
            //     (sqlResult) => {
            //         res.json(sqlResult);
            //     },(sqlError) => {
            //         res.status(500).send(sqlError);
            //     }
            // );
            res.status(505).send("Session ID is not defined!");
        }else{
            var session = sessionManager.getRatingBySessionId(req.params.id,
                (sqlResult) => {
                    res.json(sqlResult);
                },(sqlError) => {
                    res.status(500).send(sqlError);
                }
            );            
        }
    } catch (error) {
        res.status(404).send(error.toString());
    }  

    //TODO links eintragen
});

ratingRouter.post('/:id/ratings',function(req,res){
    var newRating = sessionManager.rateSession(parseInt(req.params.id),req.body.ratingValue,
    (sqlResult) => {
        res.json("Inserted!");
    },(sqlError) => {
        res.status(500).send(sqlError);
    });
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