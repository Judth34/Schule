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
using ClassLibrary;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleTree tree = new SimpleTree();
        LoadRekursiv load = new LoadRekursiv();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, RoutedEventArgs e) // Load CSV-File Button
        {
            tbUserMessage.Text = "Load CSV-File wurde gedrückt" + "\n" + tbUserMessage.Text;

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";            // Default file name
            dlg.DefaultExt = ".txt";             // Default file extension
            dlg.Filter = "Comma separated value files (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                tree = load.LoadCSV(dlg.FileName);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e) // Load BIN-File Button
        {
            tbUserMessage.Text = "Load BIN-File wurde gedrückt" + "\n" + tbUserMessage.Text;

            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";            // Default file name
            dlg.DefaultExt = ".bin";             // Default file extension
            dlg.Filter = "Comma separated value files (.bin)|*.bin"; // Filter files by extension

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                tree = load.LoadBIN(dlg.FileName);
            }

        }




        private void button_Click(object sender, RoutedEventArgs e) // Add Button
        {
            try
            {
                if (textBox.Text == "")
                {
                    throw new Exception("Das Inputfeld ist leer!");
                }

                tree.Add(double.Parse(textBox.Text));
                tbUserMessage.Text += textBox.Text.ToString() + "\n";
                textBox.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e) //Add value
        {
            double eingabe;
            try
            {
                if (!(double.TryParse(textBox.Text, out eingabe)) && textBox.Text != "")
                {
                    throw new Exception("Sie können NUR Zahlen hinzufügen!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Clear();
            }
        }

        

       
       

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e) // Search value
        {
            double eingabe;
            try
            {
                if (!(double.TryParse(textBox1.Text, out eingabe)) && textBox1.Text != "")
                {
                    throw new Exception("Sie können NUR Zahlen suchen!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox1.Clear();
            }
        }


        

        private void button2_Click_1(object sender, RoutedEventArgs e) // Search Button
        {
            try
            {
                if (textBox1.Text == "")
                {
                    throw new Exception("Sie haben keine Zahl eingegeben");
                }

                if (tree.search(double.Parse(textBox1.Text)))
                {
                    textBox2.Text = "Die Zahl " + textBox1.Text + " wurde erfolgreich gefunden.";
                }
                else
                {
                    textBox2.Text = "Die Zahl " + textBox1.Text + " konnte nicht gefunden werden.";
                }
                textBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
        }

        private void tbUserMessage_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
