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
using StraßenNetzLib;

namespace StraßenNetz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        public MainWindow()
        {
            InitializeComponent();
            db.Connect();
            cmB_Abschnitte.Items.Add("Gesamtes Straßennetz");
            foreach(Abschnitt a in db.getAbschnitte())
                this.cmB_Abschnitte.Items.Add(a);
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Teilstrecke> allTeilstrecken = db.getAllTeilstrecken();
                _drawNetzAndFillList(allTeilstrecken);
            }catch(Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
        }

        private void _drawPoint(int xCoo, int yCoo)
        {
            Ellipse el = new Ellipse();
            el.Width = 10;
            el.Height = 10;
            el.SetValue(Canvas.LeftProperty, (Double)xCoo);
            el.SetValue(Canvas.TopProperty, (Double)yCoo);
            el.Fill = Brushes.Black;
            cNetz.Children.Add(el);
        }

        private void _drawLine(int xCoo1, int yCoo1, int xCoo2, int yCoo2, SolidColorBrush color)
        {
            Line line = new Line();
            line.Stroke = color;

            line.X1 = xCoo1;
            line.X2 = xCoo2;
            line.Y1 = yCoo1;
            line.Y2 = yCoo2;

            line.StrokeThickness = 2;
            cNetz.Children.Add(line);
        }

        private void _drawTextBlock(string text, int xCoo, int yCoo)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = Brushes.Black;
            Canvas.SetLeft(textBlock, xCoo);
            Canvas.SetTop(textBlock, yCoo);
            cNetz.Children.Add(textBlock);
        }

        private void cmB_Abschnitte_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Abschnitt a = null;
            List<Teilstrecke> allTeilstrecken = null;
            try
            {
                a = (Abschnitt)this.cmB_Abschnitte.SelectedItem;
            }catch(Exception) { }
            if (a != null)
            {
                string select = "select teilstrecke.ID, teilstrecke.XA, teilstrecke.YA, teilstrecke.XE, teilstrecke.YE from netz"
                                 + " left join teilstrecke on teilstrecke.ID = netz.ID_CHILD"
                                 + " where id is not null"
                                 + " connect by prior ID_CHILD = ID_PARENT"
                                 + " start with ID_PARENT = '?'"
                                 + " order by id_parent";

                allTeilstrecken = db.getTeilstrecke(select.Replace("?", a.id));
                this.lblMessage.Text = a.id + " is now shown.";
            }
            else
            {
                string select = "select teilstrecke.ID, teilstrecke.XA, teilstrecke.YA, teilstrecke.XE, teilstrecke.YE from teilstrecke";
                allTeilstrecken = db.getTeilstrecke(select);
                this.lblMessage.Text = "Complete network is now shown.";
            }
            _drawNetzAndFillList(allTeilstrecken);
        }

        private void _drawNetzAndFillList(List<Teilstrecke> allTeilstrecken)
        {
            cNetz.Children.Clear();
            this.listTeilstrecken.Items.Clear();
            double length = 0;
            foreach (Teilstrecke t in allTeilstrecken)
            {
                length += t.getLength();
                this.listTeilstrecken.Items.Add(t);
                int xCoo1 = t.startPoint.xCoo / 2;
                int yCoo1 = t.startPoint.yCoo / 2;
                int xCoo2 = t.endPoint.xCoo / 2;
                int yCoo2 = t.endPoint.yCoo / 2;
                _drawPoint(xCoo1, yCoo1);
                _drawTextBlock("x:" + xCoo1 + " y:" + xCoo1, xCoo1 + 10, yCoo1 + 10);
                _drawPoint(xCoo2, yCoo2);
                _drawTextBlock("x:" + xCoo2 + " y:" + xCoo2, xCoo2 + 10, yCoo2 + 10);
                if (t.name[0] == 'B')
                    _drawLine(xCoo1 + 5, yCoo1 + 5, xCoo2 + 5, yCoo2 + 5, Brushes.Yellow);
                else
                    _drawLine(xCoo1 + 5, yCoo1 + 5, xCoo2 + 5, yCoo2 + 5, Brushes.LightSteelBlue);
                int xCoo = (xCoo2 - xCoo1) / 2;
                int yCoo = (yCoo2 - yCoo1) / 2;
                _drawTextBlock(t.name, xCoo + xCoo1, yCoo1 + yCoo);
            }
            this.txtLength.Text = length.ToString() + "km";
        }
    }
}
