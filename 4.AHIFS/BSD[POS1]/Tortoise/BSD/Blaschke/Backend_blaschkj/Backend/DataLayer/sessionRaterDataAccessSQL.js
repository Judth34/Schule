var Speaker             = require("../LogicLayer/BL/Speaker.js");
var Speaker             = require("../LogicLayer/BL/Session.js");
const sql = require('mssql');

const config = {
    user: 'dbuser',
    password: 'Julian1999',
    server: 'localhost',
    database: 'SessionRatingDB',
    options: {
        instanceName: 'SQLEXPRESS',
    }
};

var srDataAccesManager = {};

//functions realted to speaker
srDataAccesManager.getSpeakers = (cbfSuccess,cbfError)=>{
    sqlQuery('select * from.Speaker;',cbfSuccess,cbfError);
}

srDataAccesManager.createSpeaker = (speaker,cbfSuccess,cbfError)=>{
    let query = "INSERT INTO Speaker (Name) VALUES ('";   
        query += speaker.name;
        query += "')";
        sqlQuery(query,cbfSuccess,cbfError);
}
//realted to session
srDataAccesManager.getSessions = (cbfSuccess,cbfError)=>{
    sqlQuery('select * from.Session;',cbfSuccess,cbfError);
}

srDataAccesManager.createSession = (Session,cbfSuccess,cbfError)=>{
    let query = "INSERT INTO Session (Title, SpeakerId) VALUES ('";   
        query += Session.title;
        query += "'," + Session.speaker + ");";
    sqlQuery(query,cbfSuccess,cbfError);
}

srDataAccesManager.deleteSession = (sessionId,cbfSuccess,cbfError)=>{
    let query = "DELETE from Session WHERE Session.SessionId LIKE " + sessionId + " ;";
    sqlQuery(query,cbfSuccess,cbfError);
}

srDataAccesManager.getSessionByID = (SessionId,cbfSuccess,cbfError) => {
    let query = "Select * from.Session where Session.SessionID = " + SessionId + ";"
    sqlQuery(query,cbfSuccess,cbfError);
}
//ratings
srDataAccesManager.getRatings = (cbfSuccess,cbfError)=>{
    sqlQuery('select * from.Rating;',cbfSuccess,cbfError);
}

srDataAccesManager.getRatingById = (ratingId,cbfSuccess,cbfError) => {
    let query = "Select * from.Rating where Rating.RatingId = " + ratingId + ";"
    sqlQuery(query,cbfSuccess,cbfError);
}

srDataAccesManager.createRating = (rating,cbfSuccess,cbfError)=>{
    let date = new Date();
    let query = "INSERT INTO Rating (Value,Date,SessionId) VALUES (";   
        query += rating.ratingValue;
        query += "," + date.getDate();
        query += "," + rating.sessionId + ")";
    sqlQuery(query,cbfSuccess,cbfError);
}

srDataAccesManager.getRatingsForSession = (sessionId,cbfSuccess,cbfError)=>{
    let query = "select * from Rating inner join Session on Session.SessionId = Rating.SessionId where Session.SessionId = " + sessionId;
    sqlQuery(query,cbfSuccess,cbfError);
}

srDataAccesManager.getRatingsForSessionById = (sessionId,ratingId,cbfSuccess,cbfError)=>{
    let query = "select * from Rating inner join Session on Session.SessionId = Rating.SessionId where Session.SessionId = " + sessionId;
        query += "and Rating.RatingId = " + ratingId;
    sqlQuery(query,cbfSuccess,cbfError);
}



module.exports = srDataAccesManager;

function sqlQuery(query,cbfSuccess,cbfError){
    sql.close();
    sql.connect(config, (err,NonErr) => {
        // ... error checks
        if (err) {
            cbfError(err);
            return;
        } else {
            console.log("connected");
    
            // execute (very) simple query    
            new sql.Request().query(query, (err, result) => {
                if (err) {
                    cbfError(err);
                    return;
                } else {
                    cbfSuccess(result);
                    return;
                }
            });
        }

    });
}