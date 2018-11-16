"use strict";

function Rating(ID,ratingValue, Evaluator, sessionId) {

    //fields
    this.ID = ID;
    this.ratingValue = ratingValue;
    this.Evaluator = Evaluator;
    this.sessionId = sessionId;

    //methods

    this.toString = _toString;

    //private methods
    function _toString(){
        return "{ ID : " + this.ID + " , ratingValue : " + this.ratingValue + " , evaluator : " + this.Evaluator + " , Session : " + this.EvaluatedSession.toString();
    }


}

module.exports = Rating;
