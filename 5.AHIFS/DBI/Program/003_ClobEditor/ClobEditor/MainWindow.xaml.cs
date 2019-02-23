
using DataAccess;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace ClobEditor
{
    public partial class MainWindow : Window
    {
        Database db;


        public MainWindow()
        {
            InitializeComponent();
            InitializeDependency();
        }

        private void InitializeDependency()
        {
            // connect
            db = new Database();
            db.connect();



            // load files
            listBox_files.ItemsSource = db.loadFiles();

            Log("Connected", "#000000");
        }

        

        public void OnChange(object sender, OracleNotificationEventArgs eventArgs)
        {
            Log("Database changed", "#000000");
            Dispatcher.Invoke(() =>
            {
                try
                {
                    listBox_files.ItemsSource = db.loadFiles();
                    string filename = listBox_files.SelectedItem as string;
                    if (filename != null)
                    {
                        string content = db.LoadContent(filename);
                        Display(filename, content);
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message + ex.StackTrace, "#000000");
                }
            });
        }

        


        private void Log(string text, string hexcolor)
        {
            Dispatcher.Invoke(() =>
            {
                Run r = new Run();
                r.Text = "[" + DateTime.Now + "] " + text + "\n";
                r.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom(hexcolor));
                textBlock_messages.Inlines.Add(r);
                scrollViewer_messages.ScrollToEnd();
            });
        }

        private void button_addFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.Filter = "Text | *.txt";

                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    string path = dlg.FileName;
                    string filename = dlg.SafeFileName;
                    string content = File.ReadAllText(path);

                    Log(path, "#000000");

                    db.addFile(filename, content);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace, "#000000") ;
            }
        }

        private void listBox_files_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                if (listBox_files.SelectedItem != null)
                {
                    string title = listBox_files.SelectedItem as string, 
                        content = db.LoadContent(title);

                    Display(title, content);
                }
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace, "#000000");
            }
        }

        private void Display(string title, string content)
        {
            Dispatcher.Invoke(() =>
            {
                label_title.Content = title;
                textBox_content.Text = content;
            });

            Log("Now viewing " + title, "#000000");
        }

        private void button_edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox_files.SelectedIndex < 0)
                Log("Select a file first", "#000000");
            else
            {
                try
                {
                    db.edit(listBox_files.SelectedItem as string);

                    button_save.IsEnabled = true;
                    button_edit.IsEnabled = false;
                    textBox_content.IsReadOnly = false;

                    Log("Now editing " + listBox_files.SelectedItem as string, "#000000");
                }
                catch(Exception ex)
                {
                    Log("somebody else is already editing " + listBox_files.SelectedItem as string, "#000000");
                    db.rollback();
                    Log(ex.Message + ex.StackTrace, "#000000");
                }
            }
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filename = label_title.Content as string,
                    content = textBox_content.Text;

                db.save(filename, content);

                db.synchIdx();


                button_save.IsEnabled = false;
                button_edit.IsEnabled = true;
                textBox_content.IsReadOnly = true;

                Log("Saved.", "#000000");
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace, "#000000");
            }
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            FilterFiles(textBox_search.Text);
        }

        void FilterFiles(string search)
        {
            try
            {
                

                listBox_files.ItemsSource = db.filterFiles(search);
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace, "#000000");
            }
        }

        private void textBox_search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (textBox_search.Text == "")
                db.loadFiles();
            else
                FilterFiles(textBox_search.Text);
        }
    }
}
