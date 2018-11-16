using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterModel
{
    public class Rating
    {
        public int RatingId { get;}
        public int RatingValue { get; set; }
        public string Evaluator { get; set; }
        private static int nextID = 1;

        public Session EvaluatedSession { get; set; }

        public Rating(int RatingValue,string Evaluator,Session Evaluated)
        {
            this.RatingId = nextID;
            this.Evaluator = Evaluator;
            this.EvaluatedSession = Evaluated;
            nextID++;
        }
    }
}