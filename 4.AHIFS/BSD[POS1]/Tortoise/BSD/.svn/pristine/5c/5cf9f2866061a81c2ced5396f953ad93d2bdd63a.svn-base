
var Session             = require("./Session.js");
var Rating              = require("./Rating.js");
var Speaker              = require("./Speaker.js");

var SessionException    = require("./SessionException.js");
var SessionState        = require("./SessionState.js");
var srDataAccessManager = require('../../DataLayer/srDataAccessSQL');


module.exports = (function () {

    //fields
    var nextID = 1;
    var sessions = [];
    
    //methods
    function _createTestData() {
        _createSession("A", "sdafasd");
        _createSession("B", "sdafasd");
        _createSession("C", "sdafasd");
        _createSession("D", "sdafasd");
        _createSession("E", "sdafasd");
        _createSession("F", "sdafasd");

        _rateSession(1, 1, "Judth");
        _rateSession(2, 2, "Franz");
        _rateSession(3, 1, "Blaschke");
        _rateSession(3, 3, "Hansi");
        
    }

    function _createSession(title, speakerId, sqlSuccess, sqlError) {
      // return _validate({'title' : title     , 'speaker' : speaker },
      //                  {'title' : "string"  , 'speaker' : "string"},
      //           function(){
      //             if(_titleAlrreadyInList(title))

      //               throw new SessionException("This title appears to be already taken");
      //             var session = new Session(nextID++, title, speaker);
      //             sessions.push(session);
      //             return session;
      //           }
      //         );

      srDataAccessManager.postSession(title, speakerId, 
      (sqlResult) => {
        sqlSuccess(sqlResult);
      },
      (err) => {
        sqlError(err);
      });
    }

    function _getSessionByID(param, sqlSuccess, sqlError) {
        srDataAccessManager.getSessionByID(param,
          (sqlResult) => {
              sqlSuccess(sqlResult);
          },
          (err) => {
            sqlError(err);
          }
        );
    }

    function _getAll(sqlSuccess, sqlError) {
      srDataAccessManager.getSessions(
        (sqlResult) => {
          sqlSuccess(sqlResult);
        },
        (err) => {
          sqlError(err);
        }
      );
    }

    function _deleteSession(sessionID, sqlSuccess, sqlError) {
      // _validate({'sessionID' : sessionID},
      //           {'sessionID' : "number"},
      //           function(){
      //             var session = _getSessionByID(sessionID);
      //             var index   = sessions.indexOf(session);
      //             if(index > -1 )
      //               sessions.splice(index,1)
      //             else
      //               throw new SessionException("This element isnt available anymore!","Removing Session Excpetion");
      //           }
      //         );

      srDataAccessManager.deleteSession(sessionID, 
      (sqlResult) => {
        sqlSuccess(sqlResult);
      },
      (err) => {
        sqlError(err);
      });
    }

    function _rateSession(sessionID, RatingValue, sqlSuccess, sqlError) {
      // _validate({'sessionID' : sessionID , 'Evaluator' : Evaluator},
      //           {'sessionID' : "number"  , 'Evaluator' : "string"},
      //           function(){
      //             var session = _getSessionByID(sessionID);
      //             if(session.currentSessionState == SessionState.CLOSED)
      //               throw new SessionException("this Session has already been closed");
      //             session.rate(RatingValue,Evaluator,session);
      //           }
      //         );

      srDataAccessManager.postRating(sessionID, RatingValue, 
        (result) => {
          sqlSuccess(result);
        }, (err) => {
          sqlError(err);
        });
    }

    function _closeSession(sessionID) {
      _validate({'sessionID' : sessionID},
                {'sessionID' : "number"},
                function(){
                  var session = _getSessionByID(sessionID);
                  session.currentSessionState = SessionState.CLOSED;
                }
              );
    }

    function _getAllRatings(sqlSuccess, sqlError){
      srDataAccessManager.getAllRatings(
        (sqlResult) => {
          sqlSuccess(sqlResult);
        },
        (err) => {
          sqlError(err);
        }
      );
    }

    function _getSpeakers(sqlSuccess, sqlError){
      srDataAccessManager.getSpeakers(
        (sqlResult) => {
          sqlSuccess(sqlResult);
        
        },
        (sqlError) => {
          sqlError(sqlError);
        }
      );
    }


    function _getRatingBySessionId (sessionId, sqlSuccess, sqlError){
      srDataAccessManager.getRatingBySessionId(sessionId,
        (sqlResult) => {
          sqlSuccess(sqlResult);
        },
        (err) => {
          sqlError(err);
        }
      );
    }

    //return object
    return {

        createSession   : _createSession,
        deleteSession   : _deleteSession,
        closeSession    : _closeSession,
        getSessionByID  : _getSessionByID,
        getSessions     : _getAll,
        rateSession     : _rateSession,
        createTestData  : _createTestData,
        getRatings    : _getAllRatings,
        getSpeakers     : _getSpeakers,
        getRatingBySessionId : _getRatingBySessionId
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
        throw new SessionException("An error occured : " + ex.toString());
      }

    }

    function _titleAlrreadyInList(title){
      return sessions.some(function(value,index,arr){
        return (value.title == title);
      });
    }

})();
