"use strict";
var Session = require('./Session.js');
var Rating = require('./Rating.js');

module.exports = (function () {
    var nextid = 1;
    var sessions = [];
    
    return {
        CreateSession: _createSession,
        GetSession: _getSession,
        GetSessions: _getSessions,
        CloseSession: _closeSession,
        CloseSessionById: _closeSessionById,
        RateSession: _rateSession,
        DeleteSession: _deleteSession,

        CreateTestData: _createTestData
    };

    function _createSession(title, speaker){
        if (_sessionAlreadyAdded(title, speaker))
            throw "Session already added!";
        if (_titleAlreadyInList(title))
            throw "Title already exsists!";
        var newSession = new Session(nextid, title, speaker);
        nextid++;
        sessions.push(newSession);
        return newSession;
    }
    
    function _getSession(sessionId){      
        var result = sessions.filter(function (e) {
            if (e.getID() == sessionId)
                return e;
        });
        if (result.length == 0)
            throw "This session does not exist!";
        return result[0];
    }

    function _getSessions() {
        return sessions;
    }
    
    function _closeSession(sessionToClose){
        var index = sessions.indexOf(sessionToClose);
        sessions[index].closeSession();
    }
    
    function _closeSessionById(sessionId){
        _getSession(sessionId).closeSession();
    }
    
    function _deleteSession(sessionID){
        var s = _getSession(sessionID);
        var index = sessions.indexOf(s);
        sessions.splice(index, 1);
    }

    function _rateSession(sessionid, evaluator, ratingValue){
        var s = _getSession(sessionid);
        if (evaluator == "" || !typeof ("") || evaluator == undefined)
            throw "Evaluator is not valid!";
        if (ratingValue < 1 || ratingValue > 5 || ratingValue == undefined)
            throw "Rating Value is not valid!";
        if (s.getSessionState() == 4)
            throw "Rating is closed!";
        s.addRating(new Rating(evaluator, evaluator));
    }
    
    function _titleAlreadyInList(title){
        return sessions.some(function (e) {
            if (e.getTitle() == title)
                return true;
        });
    }
    
    function _sessionAlreadyAdded(title, speaker){
        return sessions.some(function (e) {
            if (e.getTitle() == title && e.getSpeaker() == speaker)
                return true;
        });
    }
    
    function _createTestData(){
        _createSession("Title1","Speaker");
        _createSession("Title2","Speaker");
        _createSession("Title3","Speaker");
        _createSession("Title4", "Speaker");
    }
})();