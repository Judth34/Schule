using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SessionRaterClient
{
    public class Rating
    {
        public int RatingId { get; }
        public int RatingValue { get; set; }
        public string Evaluator { get; set; }
        public Session EvaluatedSession { get; set; }
        private static int nextId = 1;

        public Rating(int RatingValue, string Evaluator, Session EvaluatedSession)
        {
            RatingId = nextId;
            nextId++;
            this.Evaluator = Evaluator;
            this.EvaluatedSession = EvaluatedSession;
            this.RatingValue = RatingValue;
        }
    }
}