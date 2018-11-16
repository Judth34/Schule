var sessionManager =    require("./SessionRaterBL.js");
var Session =           require("./Session.js");
var SessionException =  require("./SessionException.js");
var SessionState =      require("./SessionState.js");

   
//Referenzen ? 

try {
    
    //sessionManager.createTestData();
    
    console.log("\n********** Creating new Session **********");
    var createdSession = sessionManager.createSession("ex_title", "ex_subject");
    console.log(sessionManager.getSessionByID(createdSession.ID) + "\n");

    console.log("********** Rating Session **********");
    sessionManager.rateSession(createdSession.ID, 4, "judth");
    sessionManager.rateSession(createdSession.ID, 2, "blaschke");
    sessionManager.rateSession(createdSession.ID, 6, "berisha");

    console.log(createdSession.getRatings() + "\n");

    console.log("********** Closing Session **********");
    sessionManager.closeSession(createdSession.ID);
    console.log("current State : \t " + createdSession.getState() + "\n");

    console.log("********** Get Sessions **********");
    console.log(sessionManager.getSessions() + "\n");

    console.log("********** Get Ratings of a Session **********");
    console.log(createdSession.getRatings() + "\n");

    console.log("********** Get Average ratingvalue **********");
    console.log(createdSession.getAverageRatingValue() + "\n");



} catch (ex) {
    console.log(ex.toString());
}

