"use strict";

function Rating(ID,ratingValue, Evaluator, EvaluatedSession) {

    //fields
    this.ID = ID;
    this.ratingValue = ratingValue;
    this.Evaluator = Evaluator;
    this.EvaluatedSession = EvaluatedSession;

    //methods

    this.toString = _toString;

    //private methods
    function _toString(){
        return "{ ID : " + this.ID + " , ratingValue : " + this.ratingValue + " , evaluator : " + this.Evaluator + " , Session : " + this.EvaluatedSession.toString();
    }


}

module.exports = Rating;
