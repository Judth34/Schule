using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterClient
{
    public static class SessionManager
    {
        static List<Session> sessions = new List<Session>();
        static int nextId = 1;

        static public Session CreateSession(string Title, string Speaker)
        {
            
            if (Title == "" || Speaker == "")
                throw new Exception("Empty Input!");

            if(titleAlreadyInList(Title))
                throw new Exception("Title is already added!");

            Session result = new Session(nextId, Title, Speaker);
            nextId++;
            sessions.Add(result);

            return result;
        }

        static public void RateSession(int SessionId, String Evaluator, int RatingValue)
        {
            //to do: if session is in Evaluation 
            Session sessionToRate = Get(SessionId);
            if (!sessionIdValid(SessionId))
                throw new Exception("This session does not exist!");

            if (RatingValue < 1 && RatingValue > 5)
                throw new Exception("Rating Value is not between 1 and 5!");

            if (Evaluator == "")
                throw new Exception("Empty input in Evaluator");

            if (sessionToRate.CurrentSessionState == SessionState.Closed /*|| sessionToRate.CurrentSessionState == SessionState.InEvaluation*/)
                throw new Exception("This session can not be rated!");

            Rating newRating = new Rating(RatingValue, Evaluator,  Get(SessionId));
            Get(SessionId).addRating(newRating);
        }

        public static Session Get(int sessionId)
        {
            foreach (Session se in sessions)
                if (se.Id == sessionId)
                    return se;
            return null;
        }

        public static List<Session> Get()
        {
            return sessions;
        }

        public static void Delete(int SessionId)
        {
            if (Get(SessionId) == null)
                throw new Exception("This session does not exist!");
            sessions.Remove(Get(SessionId));
        }

        static public void CloseSession(int SessionId)
        {
            bool sessionIsInList = false;
            if (Get(SessionId) == null)
                throw new Exception("This session does not exist!");

            foreach (Session s in sessions)
            {
                if (s.Id == SessionId)
                {
                    s.closeSession();
                    sessionIsInList = true;
                }
            }
            if (!sessionIsInList)
                throw new Exception("This session does not exist!");
        }

        static public void CloseSession(Session SessionToClose)
        {
            bool result = false;
            foreach (Session s in sessions)
                if (s == SessionToClose)
                {
                    s.closeSession();
                    result = true;
                }
             
            if(!result)
                throw new Exception("Session is not in List!");
        }

        #region private Methods
        static private bool titleAlreadyInList(string Title)
        {
            bool result = false;
            foreach(Session s in sessions)
            {
                if (s.Title == Title)
                    result = true;
            }
            return result;
        }

        static private bool sessionIdValid(int sessionId)
        {
            foreach (Session s in sessions)
                if (s.Id == sessionId)
                    return true;

            return false;
        }

        static private bool sessionIsAlreadyAdded(string Title, string Speaker)
        {
            foreach (Session s in sessions)
            {
                if (s.Speaker == Speaker && s.Title == Title)
                    return true;
            }
            return false;
        }
        #endregion
    }
}