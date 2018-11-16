// =============================================================================


var express    = require('express'); 
var sessionManager = require('../LogicLayer/BL/sessionRaterBL.js');
var SpeakerRouter = express.Router({mergeParams:true}); 


//REQUESTS
SpeakerRouter.get('/', function(req, res) {
    var dummyObject = { message: 'hooray! Speakers will be here soon!'};
        
    sessionManager.getSpeakers(
        (speakers) => {
            res.json(speakers);
        },
        (error) => {
            res.status(500).send(error);
        }
    );

    }
);

SpeakerRouter.post('/',function(req,res){
   //todo  
});

module.exports = SpeakerRouter;