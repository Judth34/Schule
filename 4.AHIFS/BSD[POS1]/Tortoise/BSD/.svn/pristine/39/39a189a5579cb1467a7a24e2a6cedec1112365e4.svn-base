using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterModel
{
    public static class SessionManager
    {
        private static List<Session> sessions = new List<Session>();
        static int nextId = 1;


        public static Session Session
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Session createSession(string Title, string Speaker)
        {
            //Parameter überprüfen
            if(Title == "" || Speaker == "")
                throw new Exception("Empty Input (in create Session) !");

            //Eindeutigkeit des Titels sicherstellen - sonst Exception 
            if (TitleAlreadyInList(Title))
                throw new Exception("Title already in List! (in create Session) !");

            //todo Konstruktor bauen
            Session result = new Session(nextId,Title,Speaker);

            //belgen und einhängen (in Liste)
            sessions.Add(result);
            nextId++;

            return result;
        }

        public static void CloseSession(int SessionId)
        {

            //check ob die Session überhaupt durch den SessionManager verwaltet wird
            if (!SessionIDAlreadyInList(SessionId))
                throw new Exception("Session not in List (at RateSession) !");

            //sonstige weitere checks ----
            Get(SessionId).CurrentSessionState = SessionState.Closed;

        }

        public static void CloseSession(Session SessionToClose)
        {
            if (!SessionIDAlreadyInList(SessionToClose.Id))
                throw new Exception("Session not in List (at RateSession) !");

            SessionToClose.CurrentSessionState = SessionState.Closed;
        }

        public static void RateSession(int SessionID,string Evaluator,int RatingValue)
        {

            //todo : notwendige checks durchführen
            if (!SessionIDAlreadyInList(SessionID))
                throw new Exception("Session not in List (at RateSession) !");

            if(Evaluator == "" || RatingValue <0 || RatingValue >5)
                throw new Exception("Empty Input/ Wrong Input (at RateSession) !");


            Rating newRating = new Rating(RatingValue,Evaluator,Get(SessionID));

            Console.WriteLine(newRating);
            //implement Get(sessionId)

            Get(SessionID).AddRating(newRating);

        }   

        public static void Delete(int SessionId)
        {

        }



        public static Session Get(int sessionID)
        {
            foreach (Session session in sessions)
            {
                if (session.Id == sessionID)
                    return session;
            }
            return null;
        }

        public static List<Session> Get()
        {
            return sessions;
        }


        #region private Methods

        static private bool TitleAlreadyInList(string Title)
        {
            foreach(Session session in sessions)
            {
                if (session.Title == Title)
                    return true;
            }
            return false;
        }

        static private bool SessionIDAlreadyInList(int SessionId)
        {
            foreach (Session session in sessions)
            {
                if (session.Id == SessionId)
                    return true;
            }
            return false;
        }

        #endregion


    }
}
