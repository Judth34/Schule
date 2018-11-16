"use strict";

var Session             = require("./Session.js");
var Rating              = require("./Rating.js");
var SessionException    = require("./SessionException.js");
var SessionState        = require("./SessionState.js");
var Speaker             = require("./Speaker.js");
var srDataAccessManager = require("../../DataLayer/sessionRaterDataAccessSQL.js");


module.exports = (function () {

    //fields
    var sessions = [];
    
    //functions related to session 
    function _createSession(title, speaker,cbfSucess,cbfError) {
      return _validate({'title' : title     , 'speaker' : speaker },
                       {'title' : "string"  , 'speaker' : "number"},
                function(){
                  if(_titleAlrreadyInList(title))
                    throw new SessionException("This title appears to be already taken");
                  var session = new Session(null, title, speaker);
                  srDataAccessManager.createSession(session,cbfSucess,cbfError);
                }
              );
    }

    function _getSessionByID(param,cbfSucess,cbfError) {
      srDataAccessManager.getSessionByID(param,
        (SqlResult) => {
          cbfSucess(SqlResult);
        },(SqlError) => {
          cbfError(SqlError);
        }
      );
    }
    
    function _getSessions(cbfSucess,cbfError) {
      srDataAccessManager.getSessions(
        (sqlResult) => {
          //sucess
          cbfSucess(sqlResult);
        },(sqlError) => {
          //error
          cbfError(sqlError);
        }
      );
    }

    function _deleteSession(sessionId,cbfSucess,cbfError) {
        srDataAccessManager.deleteSession(sessionId,
          (sqlResult) => {
            //success
            cbfSucess(sqlResult);
          },
          (sqlError) => {
            //error
            cbfError(sqlError);
          }
        );
    }

    function _closeSession(sessionID) {
      //to implemnt
    }
    
    //functions related to rating
    function _getAllRatings(cbfSucess,cbfError){
      
      srDataAccessManager.getRatings(
        (sqlResult) => {
          //success
          cbfSucess(sqlResult);  
        },(sqlError) => {
          //error
          cbfError(sqlError);
        }
      );
      
      //return (sessions.length < 1 ) ? sessions :  x(0,[]); ;
      //function x(index,arr){
          //return (!sessions[index+1]) ?  arr : x(index+1,arr.concat((sessions[index].getRatings())));
      //} 
    }
   
    function _rateSession(sessionId, ratingVal, evaluator, cbfSuccess, cbfError) {
      let rating = new Rating(1,ratingVal,evaluator,sessionId);
      srDataAccessManager.createRating(rating, 
        (sqlResult) => {
          //success 
          cbfSuccess(sqlResult);
        },(sqlError) => {
          cbfError(sqlError);
      })
      ;
    }

    function _getRatingById(ratingId,cbfSuccess,cbfError){
      srDataAccessManager.getRatingById(ratingId,cbfSuccess,cbfError);
    }

    function _getRatingsForSession(sessionId,cbfSuccess,cbfError){
      srDataAccessManager.getRatingsForSession(sessionId,cbfSuccess,cbfError);
    }

    function _getRatingsForSessionById(sessionId,ratingId,cbfSuccess,cbfError){
      srDataAccessManager.getRatingsForSessionById(sessionId,ratingId,cbfSuccess,cbfError);
    }

    //functions related to speaker
    function _getSpeakers(cbfSucess,cbfError){
      srDataAccessManager.getSpeakers(
        (sqlResult) => {
          //todo : some business checks here
          var speakers = sqlResult;
          cbfSucess(speakers);
        
        },
        (sqlError) => {
          cbfError(sqlError);
        }
      );
    }

    function _createSpeaker(name,cbfSuccess,cbfError){
      let speaker = new Speaker(name,null);
      srDataAccessManager.createSpeaker(speaker,cbfSuccess,cbfError);
    }

    //return object
    return {

        createSession   : _createSession,
        deleteSession   : _deleteSession,
        closeSession    : _closeSession,
        getSessionByID  : _getSessionByID,
        getSessions     : _getSessions,
        getRatings      : _getAllRatings,
        getRatingById   : _getRatingById,
        getRatingsForSession : _getRatingsForSession,
        getRatingsForSessionById : _getRatingsForSessionById,
        rateSession     : _rateSession,
        getSpeakers     : _getSpeakers

    };


    //helping methods...

    function _validate(param,paramtype,callback){
      try{
        for(var key in param)
          if(typeof param[key] != paramtype[key])
            throw new SessionException("given param is not valid","invalid type Session Exception");

      }catch(ex){
        throw new SessionException("given param is not valid : " + ex, "invalid type Session Exception");
      }

      try{
        if(typeof callback != "function")
          throw new SessionException("callback function is not type of function","invalid type Session Exception");
        return callback();
      }catch(ex){
        console.log(ex.toString());
        throw new SessionException("An error occured : " + ex.toString());
      }

    }

    function _titleAlrreadyInList(title){
      return sessions.some(function(value,index,arr){
        return (value.title == title);
      });
    }


})();
