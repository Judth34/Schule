using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Oracle.ManagedDataAccess.Client;

namespace SPO_Geometry
{
    public class Database
    {
        static OracleConnection conn;
        OracleDependency dep = null;
        MainWindow w;


        public Database(MainWindow mw)
        {
            w = mw;
            Connect();
        }


        public void Connect()
        {
                conn = new OracleConnection("Data Source=192.168.128.152:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d4a11;Password=d4a");
                //conn = new OracleConnection("Data Source=212.152.179.117:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d4a11;Password=d4a");
                var cmd = new OracleCommand("select * from visitors", conn);
                conn.Open();
                OracleDependency.Port = -1;
                dep = new OracleDependency(cmd);
                dep.QueryBasedNotification = false;
                cmd.Notification.IsNotifiedOnce = false;
                dep.OnChange += new OnChangeEventHandler(dep_OnChange);
                cmd.ExecuteNonQuery();
        }

        void dep_OnChange(object sender, OracleNotificationEventArgs e)
        {
            w.Dispatcher.Invoke(new Action(w.Refresh));
        }

        public List<Building> getBuildings ()
        {
            List<Building> allBuildings = new List<Building>();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select building_id, name, visitors from village";

            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) 
            {
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["building_id"]);
                    Building b = new Building(id, Convert.ToString(dr["name"]), Convert.ToInt32(dr["visitors"]), getBuildingCoordinates(id));
                    b.allVisitors = getAllVisitiorsInsideABuilding(id);
                    allBuildings.Add(b);
                 }
            }         
            return allBuildings;
        }

        private PointCollection getBuildingCoordinates(int buildingId)
        {
            PointCollection vertices = new PointCollection();
            
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = " SELECT t.X, t.Y FROM village v, TABLE(SDO_UTIL.GETVERTICES(v.building)) t where building_id=:ID";
            cmd.Parameters.Add(":ID", buildingId);
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
                while (dr.Read())
                    vertices.Add(new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"])));
            
            return vertices;
        }

        public List<Visitor> getAllVisitiorsInsideABuilding(int buildingId) {
            List<Visitor> allVisitiorsInBuild = new List<Visitor>();
            int maxNr = 0;
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT visitors.ID, village.NAME,village.VISITORS FROM visitors, village WHERE SDO_WITHIN_DISTANCE(village.BUILDING,visitors.POSITION,'distance=7') = 'TRUE' AND village.BUILDING_ID = :bid";
            cmd.Parameters.Add(":bid", buildingId);
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    maxNr = Convert.ToInt32(dr["VISITORS"]);
                    allVisitiorsInBuild.Add(new Visitor(Convert.ToInt32(dr["ID"]),getVisitorCoordinates(Convert.ToInt32(dr["ID"])) ));
                }
            }
            
            return allVisitiorsInBuild;
        }

        private Point getVisitorCoordinates(int visitorId)
        {
            Point vertices = new Point();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = " SELECT t.X, t.Y FROM visitors v, TABLE(SDO_UTIL.GETVERTICES(v.position)) t where v.id=:ID";
            cmd.Parameters.Add(":ID", visitorId);
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
                while (dr.Read())
                   vertices = new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"]));

            return vertices;
        }
    }
}
