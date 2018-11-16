using SessionRaterClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionRater
{
    class Program
    {
        static void Main(string[] args)
        {
            Session firstSession = SessionManager.CreateSession("First Session", "Sepp");
            SessionManager.RateSession(firstSession.Id, "User1", 4);
            SessionManager.RateSession(firstSession.Id, "User2", 1);
            SessionManager.RateSession(firstSession.Id, "User3", 5);
            SessionManager.RateSession(firstSession.Id, "User9", 2);
            List<Session> all = SessionManager.Get();
            SessionManager.CloseSession(1);
            SessionManager.Delete(1);
        }
    }
}
