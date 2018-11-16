using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace _008Village
{
    class Database
    {
        MainWindow w;
        public Database(MainWindow mw)
        {
            if (mw == null)
                throw new Exception("Unvalid MainWindow in Database Constructor!");
            w = mw;
        }

        private static OracleConnection conn;

        OracleDependency dep = null;

        public void Connect()
        {
            try
            {
                conn = new OracleConnection(
                        "Data Source=192.168.128.152/ora11g;PERSIST SECURITY INFO=True;User ID=d4a06;Password=d4a");

                var cmd = new OracleCommand("select * from stand", conn);

                conn.Open();
                OracleDependency.Port = -1;
                dep = new OracleDependency(cmd);
                dep.QueryBasedNotification = false;
                cmd.Notification.IsNotifiedOnce = false;
                dep.OnChange += new OnChangeEventHandler(dep_OnChange);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void dep_OnChange(object sender, OracleNotificationEventArgs eventArgs)
        {
            MessageBox.Show("Database changed");
            w.Dispatcher.Invoke(new Action(w.refresh));
        }

        public Boolean hasChanges()
        {
            return this.dep.HasChanges;
        }

        public ObservableCollection<t1> GetT1()
        {
            ObservableCollection<t1> l = new ObservableCollection<t1>();
            try
            {
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * from t1";
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    l.Add(new t1() { Nr = Convert.ToInt32(reader["nr"].ToString()), Name = (String)reader["name"], Email = (String)reader["Email"] });
                    
                }

            }
            catch (System.Exception _e)
            {
                MessageBox.Show(_e.Message);
            }

            return l;
        }

        public Village selectVilage(int buildingsID)
        {
            Village newVillage = new Village(1, "", 2);

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = " SELECT t.X, t.Y FROM village v, TABLE(SDO_UTIL.GETVERTICES(v.building)) t where building_id=:ID";
            cmd.Parameters.Add(":ID", buildingsID);
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
                while (dr.Read())
                    newVillage.addPoint(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"]));

            return newVillage;
        }

        public List<Visitor> selectVisitors(int buildingsID)
        {
            List<Visitor> listVisitor = new List<Visitor>();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT visitors.ID, village.NAME,village.VISITORS FROM visitors, village WHERE SDO_WITHIN_DISTANCE(village.BUILDING,visitors.POSITION,'distance=7') = 'TRUE' AND village.BUILDING_ID = :bid";
            cmd.Parameters.Add(":bid", buildingsID);
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listVisitor.Add(new Visitor(Convert.ToInt32(dr["ID"]), getVisitorCoordinates(Convert.ToInt32(dr["ID"]))));
                }
            }
            return listVisitor;
        }

        public void updateStand(Stand stand)
        {
            List<Stand> staende = new List<Stand>();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "UPDATE stand SET name = '" + stand.name + "' WHERE nr = " + stand.nr;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }

        public List<Stand> selectStaendeUmkreis(Stand stand, int radius)
        {
            List<Stand> listStaende = new List<Stand>();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select nr, name from stand WHERE SDO_WITHIN_DISTANCE(stand.position,SDO_GEOMETRY(2001,NULL,SDO_POINT_TYPE(" + stand.position.X + ", " + stand.position.Y + ", NULL),NULL,NULL),'distance= " + radius +"') = 'TRUE'";
            
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listStaende.Add(new Stand(Convert.ToInt32(dr["nr"]), new Point(0, 0), Convert.ToString(dr["name"])));
                }
            }
            return listStaende;
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

        public List<Stand> selectStaende()
        {
            List<Stand> listStaende = new List<Stand>();

            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT nr,name, t.X, t.Y FROM stand v, TABLE(SDO_UTIL.GETVERTICES(v.position)) t";
            cmd.Connection = conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listStaende.Add(new Stand(Convert.ToInt32(dr["nr"]), new Point(Convert.ToInt32(dr["X"]), Convert.ToInt32(dr["Y"])), Convert.ToString(dr["name"])));
                }
            }
            return listStaende;
        }
    }
}
