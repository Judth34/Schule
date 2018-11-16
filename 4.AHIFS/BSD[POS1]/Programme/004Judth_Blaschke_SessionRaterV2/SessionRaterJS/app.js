var sessionManager = require('./SessionRaterBL.js');
var Session = require('./Session.js');
var Rating = require('./Rating.js');


try{
    sessionManager.CreateTestData();    

    var sessions = sessionManager.GetSessions();
    sessions.forEach(function (e) { console.log(e.toString()); });
    console.log("******************");
    console.log("Add Two same sessions:");
    try {
        sessionManager.CreateSession("title", "speaker");
        sessionManager.CreateSession("title", "speaker");
    } catch (ex){
        console.log(ex);
    }

    console.log("******************");
    console.log("Add Two sessions with same title:");
    try {
        sessionManager.CreateSession("title", "speaker1");
        sessionManager.CreateSession("title", "speaker2");
    } catch (ex) {
        console.log(ex);
    }

    console.log("******************");
    console.log("before close:");
    console.log(sessionManager.GetSession(1).toString());
    sessionManager.CloseSession(sessionManager.GetSession(1));
    console.log("after close:");
    console.log(sessionManager.GetSession(1).toString());

    console.log("******************");
    console.log("rating closed session:");
    try {
        sessionManager.RateSession(1, "Judth", 1);
    } catch (ex) {
        console.log(ex);
    }

    console.log("******************");
    console.log("rating session empty input:");
    try {
        sessionManager.RateSession(2, undefined, 1);
    } catch (ex) {
        console.log(ex);
    }
    try {
        sessionManager.RateSession(2, "judth", undefined);
    } catch (ex) {
        console.log(ex);
    }
    
    console.log("******************");
    console.log("before close:");
    console.log(sessionManager.GetSession(2).toString());
    sessionManager.CloseSessionById(2);
    console.log("after close:");
    console.log(sessionManager.GetSession(2).toString());

    console.log("******************");
    console.log("before rating:");
    console.log(sessionManager.GetSession(3).toString());
    sessionManager.RateSession(3, "Judth", 2);
    sessionManager.RateSession(3, "Frank", 1);
    sessionManager.RateSession(3, "Heinz", 3);
    sessionManager.RateSession(3, "Sepp", 5);
    console.log("after rating:");
    console.log(sessionManager.GetSession(3).toString());

    console.log("******************");
    console.log("before delete:");
    console.log(sessionManager.GetSession(4).toString());
    sessionManager.DeleteSession(4);
    console.log("after delete:");
    console.log(sessionManager.GetSession(4).toString());
} catch (ex) {
    console.log("Error: " + ex);
}
