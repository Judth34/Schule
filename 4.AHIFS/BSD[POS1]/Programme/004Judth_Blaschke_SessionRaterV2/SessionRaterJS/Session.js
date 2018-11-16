var enumSessionState = require('./SessionSate.js');
function Session(id, title, speaker){
    //properties
    var id = id;
    var title = title;
    var speaker = speaker;
    var ratings = [];
    var sessionState = enumSessionState.Created;

    //Methods
    this.addRating = _addRating;
    this.closeSession = _closeSession;
    this.toString = _toString;
    this.getTitle = _getTitle;
    this.getID = _getID;
    this.getSpeaker = _getSpeaker;
    this.getSessionState = _getSessionState;
    
    

    function _addRating(newRating){
        ratings.push(newRating);
        sessionState = enumSessionState.Evaluated;
    }
    
    function _closeSession(){
        sessionState = enumSessionState.Closed;
    }
    
    function _getID(){
        return id;
    }
     
    function _getTitle(){
        return title;
    }
    
    function _getSpeaker(){
        return speaker;
    }
    
    function _getSessionState(){
        return sessionState;
    }

    function _toString(){
        var ratingString = "{";
        ratings.forEach(function (e){ ratingString += " " + e.toString() + ";" });
        ratingString += "}";
        return "ID: " + id + ", Title " + title + ", Speaker: " + speaker + ", Number of ratings: " + ratingString + " State: " + sessionState + ";";
    }

}

module.exports = Session;