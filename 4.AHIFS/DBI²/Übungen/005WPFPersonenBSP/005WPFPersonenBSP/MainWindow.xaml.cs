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

namespace _005WPFPersonenBSP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database db;
        public MainWindow()
        {
            db = new Database();
            InitializeComponent();
                loadPersons();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.listPersons.SelectedItem == null)
                    throw new Exception("Please select a Person!");
                string name = this.txtName.Text;
                string date = this.txtDate.Text;
                int sal;
                if (this.txtSal.Text == "")
                    sal = -1;
                else
                    sal = Int32.Parse(this.txtSal.Text);
                Person p = (Person)this.listPersons.SelectedItem;

                if (name != p.Name && name != "")
                    db.update_Person("update person set name ='" + name + "'  where nr = " + p.nr);

                if (!date.Equals(p.date) && date != "")
                    db.update_Person("update person set GEB_DAT = to_date('" + date + "', 'DD-MM-YYYY') where nr = " + p.nr);

                if (sal != p.gehalt && sal >= 0)
                    db.update_Person("update person set GEHALT = " + sal + " where nr = " + p.nr);
                loadPersons();
                this.lblMessage.Text = p.ToString() + " updated!";
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
        }


        private void loadPersons()
        {
            listPersons.Items.Clear();
            db.Connect();

            List<Person> allPersons = db.get_Person("Select * from Person");
            foreach (Person p in allPersons)
                this.listPersons.Items.Add(p);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.listPersons.SelectedItem == null)
                    throw new Exception("Please select a Person!");
                Person p = (Person)this.listPersons.SelectedItem;

                db.delete_Person("delete from person where nr = " + p.nr);

                loadPersons();
                this.lblMessage.Text = p.ToString() + " deleted!";
            }catch(Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.txtName.Text == "" || this.txtDate.Text == "" || this.txtSal.Text == "")
                    throw new Exception("Please fill in all lines!");
                string nr = this.txtNr.Text;
                string name = this.txtName.Text;
                string date = this.txtDate.Text;
                int sal = Int32.Parse(this.txtSal.Text);

                db.insert_Person("insert into person values(" + nr + ", ' " + name + "', to_date('" + date +  "', 'DD-MM-YYYY'), " + sal +")");

                loadPersons();
                this.lblMessage.Text =  "Person inserted!";
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
        }

        private void btnreadCommited_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.setTransactionReadComitted();
            }catch(Exception ex)
            {
                this.lblMessage.Text = ex.ToString();
            }
        }

        private void btnSerializeable_Click(object sender, RoutedEventArgs e)
        {
            db.setTransactionSerializeable();
        }
    }
}
