using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterClient
{
    public class Session
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public SessionState CurrentSessionState { get; set; }
        public HashSet<Rating> Ratings { get; set; }

        public Session(int id, string Title, string Speaker)
        {
            this.Id = id;
            this.Title = Title;
            this.Speaker = Speaker;
            this.Ratings = new HashSet<Rating>();

            CurrentSessionState = SessionState.Created;
        }


        #region public-Methods
        public void addRating(Rating newRating)
        {
            CurrentSessionState = SessionState.Evaluated;
            Ratings.Add(newRating);
        }

        public void closeSession()
        {
            CurrentSessionState = SessionState.Closed;
        }
        public override string ToString()
        {
            return "Title: " + Title + "    Speaker: " + Speaker + "    Status: " + CurrentSessionState.ToString();
        }
        #endregion
    }
}