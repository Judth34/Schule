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

namespace _008Village
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database db;

        public MainWindow()
        {
            InitializeComponent();
            this.db = new Database(this);
            this.inItOtherThings();
        }        
        

        private void inItOtherThings()
        {
            try
            {
                this.db.Connect();
                this.lblMessage.Text = "Connected!";
                refresh();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
        }

        

        #region draw-Methods
        private void draw(Village village)
        {
            Polygon p = new Polygon();
            p.Stroke = Brushes.Black;
            p.Fill = Brushes.LightBlue;
            p.StrokeThickness = 1;
            p.HorizontalAlignment = HorizontalAlignment.Left;
            p.VerticalAlignment = VerticalAlignment.Center;
            p.Points = village.coordinates;
            this.canvas.Children.Add(p);
        }

        private void draw(List<Visitor> allVisitor)
        {
            foreach (Visitor v in allVisitor)
                draw(v.coordinate);
        }

        private void draw(Point p)
        {
            Ellipse el = new Ellipse();
            el.Width = 10;
            el.Height = 10;
            el.SetValue(Canvas.LeftProperty, p.X * 5);
            el.SetValue(Canvas.TopProperty, p.Y * 5);
            el.Fill = Brushes.Black;
            this.canvas.Children.Add(el);
        }

        private void draw(List<Stand> allStaende)
        {
            this.canvas.Children.Clear();
            foreach (Stand v in allStaende)
                draw(v.position);
        }
        #endregion


        #region public-Methods
        public void refresh()
        {
            MessageBox.Show("hello");
            this.listBoxStaende.Items.Clear();
            List<Stand> allStaende = this.db.selectStaende();
            foreach (Stand s in allStaende)
                this.listBoxStaende.Items.Add(s);
            this.draw(allStaende);
        }
        #endregion

        private void btnUmkreis_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int umkreis = int.Parse(this.txtUmkreis.Text);
                this.listBoxUmkreis.Items.Clear();
                List<Stand> allStaende = this.db.selectStaendeUmkreis((Stand)this.listBoxStaende.SelectedItem, umkreis);
                foreach (Stand s in allStaende)
                    this.listBoxUmkreis.Items.Add(s);
            }catch(Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
            
        }

        private void btnReserve_Click(object sender, RoutedEventArgs e)
        {
            Stand currentStand = (Stand)this.listBoxStaende.SelectedItem;
            currentStand.name = this.txtNameReserve.Text;
            this.db.updateStand(currentStand);
            this.refresh();
        }

    }
}
