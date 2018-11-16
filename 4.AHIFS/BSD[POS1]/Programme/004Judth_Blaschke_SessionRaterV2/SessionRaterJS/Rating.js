var nextID = 1;
function Rating(ratingValue, evaluator){
    var ratingID = nextID++;
    var ratingValue = ratingValue;
    var evaluator = evaluator;
    
    this.toString = toString;

    function toString(){
        return "ID: " + ratingID + ", evaluator: " + evaluator + ", rating-value: " + ratingValue;
    }
}

module.exports = Rating;