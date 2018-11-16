"use strict";

var Rating              = require("./Rating.js");
var SessionException    = require("./SessionException.js");
var SessionState        = require("./SessionState.js");

function Session(ID,title, speaker) {

    //private fields
    var ratings  = [];
    var nextID = 1;

    //public fields
    this.ID = ID;
    this.title = title;
    this.speaker = speaker;
    this.currentSessionState = SessionState.CREATED;

    //private methods
    function _rate(RatingValue,Evaluator,session) {
      var rating = new Rating(nextID ++,RatingValue,Evaluator,session)
      this.currentSessionState = SessionState.EVALUATED;
      ratings.push(rating);
      return rating;
    }

    function _toString() {
        return "{ ID :  " + this.ID + " , title : " + this.title + " , speaker : " + this.speaker + " , currentSessionState : " + _getState(this.currentSessionState) + " }";
    }

    function _getAll() {
      return ratings;
    }

    function _getState(state = this.currentSessionState){
      switch (state) {
        case 1:
          return "CREATED";
          break;
        case 2:
          return "INEVALUATION";
          break;
        case 3 :
          return "EVALUATED";
          break;
        case 4 :
          return "CLOSED";
          break;
        default:
          return "NONE";
          break;
      }
    }

    function _getAverageRatingValue(){

      return ratings.reduce(function(val1,val2){
        if(typeof val1 != "object") 
          return val1 + val2.ratingValue;
        if(typeof val2 != "object")
          return val1.ratingValue + val2;
        return val1.ratingValue + val2.ratingValue;

      }) / ratings.length;
    }

    function _getRatingById(param){
        return ratings.find(function(val,index,arr){
            return val.ID == param;
        })
    }

    function _deleteRating(param){
      var rating = _getRatingById(param);
      var index = ratings.indexOf(rating);
      if(index > -1)
        ratings.splice(index,1)
      else
        throw new SessionException("This element isnt available anymore!","Removing Rating Excpetion");
    }

    //methods
    this.rate = _rate;
    this.toString = _toString;
    this.getRatings = _getAll;
    this.getRatingById = _getRatingById;
    this.getState = _getState;
    this.getAverageRatingValue = _getAverageRatingValue;
    this.deleteRating = _deleteRating;

}

module.exports = Session;
