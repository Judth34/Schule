using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterModel
{
    public class Session
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }


        public SessionState CurrentSessionState{ get; set; }

        public HashSet<Rating> Ratings { get; set; }

        public Session(int Id, string Title,string Speaker)
        {
            this.Id = Id;
            this.Title = Title;
            this.Speaker = Speaker;
            this.CurrentSessionState = SessionState.Created;
            Ratings = new HashSet<Rating>();
        }



        #region functions

        public void AddRating(Rating rating)
        {
            this.Ratings.Add(rating);
        }

        public override string ToString() {
            return "Session {Title : " + this.Title + " , Speaker : " + this.Speaker + " } "; 
        }

        #endregion
    }
}