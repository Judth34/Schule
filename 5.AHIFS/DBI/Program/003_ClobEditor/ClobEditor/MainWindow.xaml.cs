
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
        const string TABLE = "ctxsys.documents_06";

        OracleConnection connection;
        OracleDependency dependency;
        OracleTransaction transaction;

        public MainWindow()
        {
            InitializeComponent();
            InitializeDependency();
        }

        private void InitializeDependency()
        {
            // connect
            connect();

            // create dependency
            OracleCommand command = new OracleCommand("select * from " + TABLE + "", connection);
            dependency = new OracleDependency(command);
            dependency.QueryBasedNotification = false;
            command.Notification.IsNotifiedOnce = false;

            dependency.OnChange += new OnChangeEventHandler(OnChange);
            command.ExecuteNonQuery();

            // load files
            LoadFiles();

            Log("Connected", "#000000");
        }

        private void connect()
        {
            try
            {
                connection = new OracleConnection("Data Source=192.168.128.152:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d5a06;Password=d5a");
                connection.Open();
            }
            catch (OracleException e)
            {
                connection = new OracleConnection("Data Source=212.152.179.117:1521/ora11g;PERSIST SECURITY INFO=True;User ID=d5a06;Password=d5a");
                connection.Open();
            }
        }

        private void OnChange(object sender, OracleNotificationEventArgs eventArgs)
        {
            Log("Database changed", "#000000");
            Dispatcher.Invoke(() =>
            {
                try
                {
                    LoadFiles();
                    string filename = listBox_files.SelectedItem as string;
                    if (filename != null)
                    {
                        string content = LoadContent(filename);
                        Display(filename, content);
                    }
                }
                catch (Exception ex)
                {
                    Log(ex.Message + ex.StackTrace, "#000000");
                }
            });
        }

        private void LoadFiles()
        {
            List<string> filenames = new List<string>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT filename FROM " + TABLE + "";
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
                filenames.Add(reader.GetString(0));

            listBox_files.ItemsSource = filenames;
        }

        private string LoadContent(string filename)
        {
            string content = "";
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT text FROM " + TABLE + " WHERE filename = :filename";
            command.Parameters.Add(new OracleParameter(":filename", filename));
            OracleDataReader reader = command.ExecuteReader();

            if (reader.Read())
                content = reader.GetString(0);


            return content;
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

                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO " + TABLE + " VALUES(:filename, :filedata)";
                    command.Parameters.Add(new OracleParameter(":filename", OracleDbType.Varchar2, filename, ParameterDirection.Input));
                    command.Parameters.Add(new OracleParameter(":filedata", OracleDbType.Clob, content, ParameterDirection.Input));
                    command.ExecuteNonQuery();
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
                        content = LoadContent(title);

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
                    transaction = connection.BeginTransaction(IsolationLevel.Serializable);

              
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM " + TABLE + " WHERE filename = :fn FOR UPDATE NOWAIT";
                    command.Parameters.Add(":fn", listBox_files.SelectedItem as string);
                    command.Transaction = transaction;
                    command.ExecuteNonQuery();

                    button_save.IsEnabled = true;
                    button_edit.IsEnabled = false;
                    textBox_content.IsReadOnly = false;

                    Log("Now editing " + listBox_files.SelectedItem as string, "#000000");
                }
                catch(Exception ex)
                {
                    Log("somebody else is already editing " + listBox_files.SelectedItem as string, "#000000");
                    transaction.Rollback();
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

                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE " + TABLE + " SET text = :content WHERE filename = :filename";
                command.Parameters.Add(new OracleParameter(":content", OracleDbType.Clob, content, ParameterDirection.Input));
                command.Parameters.Add(new OracleParameter(":filename", OracleDbType.Varchar2, filename, ParameterDirection.Input));
                command.Transaction = transaction;
                command.ExecuteNonQuery();

                transaction.Commit();

                syncIndex();


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
                List<string> filenames = new List<string>();
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT filename FROM " + TABLE + " WHERE CONTAINS(text, :searchstr, 1) > 0";
                command.Parameters.Add(new OracleParameter(":searchstr", search));

                OracleDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    filenames.Add(reader.GetString(0));

                listBox_files.ItemsSource = filenames;
            }
            catch (Exception ex)
            {
                Log(ex.Message + ex.StackTrace, "#000000");
            }
        }

        private void textBox_search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (textBox_search.Text == "")
                LoadFiles();
            else
                FilterFiles(textBox_search.Text);
        }

        private void syncIndex()
        {
            OracleCommand cmd = connection.CreateCommand();
            //cmd.Transaction = transaction;
            cmd.CommandText = "ctx_ddl.sync_index";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("indexnameparam", "DOCS_IDX_06");
            cmd.Parameters.Add("indexsizeparam", "2M");
            cmd.ExecuteNonQuery();
        }
    }
}
