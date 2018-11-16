function SessionState(){
    return {
        Created : 1,
        InEvaluation : 2,
        Evaluated : 3,
        Closed : 4
    };
    
}

module.exports = SessionState();