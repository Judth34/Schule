using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SPO_Geometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = null;
        List<Building> allBuildings = new List<Building>();
        public MainWindow()
        {
            try {
               db = new Database(this);
            }
            catch (Exception ex) {
                MessageBox.Show("error:" + ex.Message);
            }
            InitializeComponent();

        }

        

        private void bttnDrawCurch_Click(object sender, RoutedEventArgs e)
        {

            try {
                allBuildings = db.getBuildings();
                if (allBuildings.Count == 0)
                    throw new Exception("no buildings in db");

                drawPolyBuildingWithInsideVisitors(allBuildings);
            }
            catch (Exception ex) {
                MessageBox.Show("error:" + ex.Message);
            }
            
        }

        private void drawPolyBuildingWithInsideVisitors(List<Building> allBuildings)
        {
            myCan.Children.Clear();
            txtBlockCurch.Text = "";
            txtBlockVisitors.Text = "";

            foreach (Building b in allBuildings) {
                txtBlockCurch.Text += "id: " + b.Id + "\nname: " + b.Name + "\nmaxNumOfVisitors: " + b.NumberOfVisitors + "\ncoordinates: " + b.Coordinates+ "\n";

                Polygon p = new Polygon();
                p.Stroke = Brushes.Black;
                p.Fill = Brushes.LightBlue;
                p.StrokeThickness = 1;
                p.HorizontalAlignment = HorizontalAlignment.Left;
                p.VerticalAlignment = VerticalAlignment.Center;
                p.Points = b.Coordinates;
                myCan.Children.Add(p);

                int idx =0;
                for (idx = 0; idx < b.allVisitors.Count && idx <= b.NumberOfVisitors; idx++)
                {       
                    Visitor v = b.allVisitors[idx];
                    drawPoint(Convert.ToInt32(v.coordinate.X), Convert.ToInt32(v.coordinate.Y));                
                }
                if (b.allVisitors.Count > b.NumberOfVisitors)
                    txtBlockVisitors.Text += "visitors INSIDE " + b.Name + ": " + b.NumberOfVisitors + "\nnumberWhoWaitingToComeIn:" + (b.allVisitors.Count-b.NumberOfVisitors +"\n");
                else
                    txtBlockVisitors.Text += "visitors INSIDE " + b.Name + " : " + idx +" and nobody is outside waiting\n";
            }
        }
        

        public void Refresh()
        {
            try
            {
                MessageBox.Show("trigger has been activated! data will change IF visitor is waiting or is already inside the building!");
                allBuildings = db.getBuildings();
                if (allBuildings.Count == 0)
                    throw new Exception("no buildings in db");

                drawPolyBuildingWithInsideVisitors(allBuildings);
            }
            catch (Exception e)
            {
                MessageBox.Show("refresh err: " + e.Message);
            }
           
        }

        private void drawPoint(int xCoo, int yCoo)
        {
            Ellipse el = new Ellipse();
            el.Width = 10;
            el.Height = 10;
            el.SetValue(Canvas.LeftProperty, (Double)xCoo);
            el.SetValue(Canvas.TopProperty, (Double)yCoo);
            el.Fill = Brushes.Black;
            myCan.Children.Add(el);
        }
    }
}
