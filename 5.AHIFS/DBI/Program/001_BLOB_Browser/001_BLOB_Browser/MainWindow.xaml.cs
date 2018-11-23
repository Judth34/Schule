using _001_BLOB_Browser_Lib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace _001_BLOB_Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataAccess dataAccess;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                this.dataAccess = new DataAccess();
                this.insertBlobsInList();
                this.fillCmBLocations();
            }catch(Exception ex)
            {
                this.txtMessage.Text = ex.ToString();
            }
            
        }

        private void fillCmBLocations()
        {
            List<DataAccess.Location> locs = this.dataAccess.getLocations();

            foreach(DataAccess.Location location in locs)
            {
                this.cmBLocations.Items.Add(location);
            }

            this.cmBLocations.SelectedIndex = 0;
        }

        private void insertBlobsInList()
        {
            this.listBlobs.Items.Clear();
            List<DataAccess.Blob> blobs = this.dataAccess.get();
            foreach(DataAccess.Blob b in blobs)
            {
                this.listBlobs.Items.Add(b);
            }
        }

        private void insertBlobsInList(string searchtext)
        {
            this.listBlobs.Items.Clear();
            List<DataAccess.Blob> blobs = this.dataAccess.SearchInDoc(searchtext);
            foreach (DataAccess.Blob b in blobs)
            {
                this.listBlobs.Items.Add(b);
            }
        }

        private void btnFileDialog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.txtMessage.Text = "select file!";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"C:";
                openFileDialog.Title = "Browse images";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                var result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    this.dataAccess.insert(openFileDialog.FileName, openFileDialog.SafeFileName, (DataAccess.Location) this.cmBLocations.SelectedItem);
                    this.txtMessage.Text = "succesfully inserted!";
                    this.insertBlobsInList();
                }
            }catch(Exception ex)
            {
                this.txtMessage.Text = ex.Message;
            }
        }

        private void listBlobs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                DataAccess.Blob b = (DataAccess.Blob)this.listBlobs.SelectedItem;
            }catch(Exception ex)
            {
                this.txtMessage.Text = ex.ToString();
            }
        }

        private void btnSaveBlob_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.txtMessage.Text = "select file!";
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = @"C:";
                openFileDialog.Title = "Browse images";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                var result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    DataAccess.Blob selectedBlob = (DataAccess.Blob)this.listBlobs.SelectedItem;
                    if (selectedBlob == null)
                        throw new Exception("No File selected in List!");
                    this.txtMessage.Text = "saving File into " + selectedBlob.filename;
                    this.dataAccess.save(selectedBlob, openFileDialog.FileName);
                    this.txtMessage.Text = "saved sucessfully";
                }
            }
            catch (Exception ex)
            {
                this.txtMessage.Text = ex.Message;
            }
        }

        private void txtSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                insertBlobsInList(this.txtMessage.Text);
            }
            catch (Exception ex)
            {
                this.txtMessage.Text = ex.ToString();
            }
        }
    }
}
