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
            }catch(Exception ex)
            {
                this.txtMessage.Text = ex.ToString();
            }
            
        }

        private void insertBlobsInList()
        {
            List<DataAccess.Blob> blobs = this.dataAccess.get();
            foreach(DataAccess.Blob b in blobs)
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
                openFileDialog.InitialDirectory = @"C:\Users\Marcel Judth\Documents\GitHub\Schule\5.AHIFS\NVS\Programs\001_ImageFilter\001_ImageFilter\bin\Debug\Data";
                openFileDialog.Title = "Browse images";
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Image files Pdf Files |*.pdf";
                var result = openFileDialog.ShowDialog();
                if (result == true)
                {
                    this.dataAccess.insert(openFileDialog.FileName);
                    this.txtMessage.Text = "succesfully inserted!";
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
                DataAccess.Blob selectedBlob = (DataAccess.Blob)this.listBlobs.SelectedItem;
                if (selectedBlob == null)
                    throw new Exception("No File selected in List!");
                this.txtMessage.Text = "saving File into " + selectedBlob.filename;
                this.dataAccess.save(selectedBlob);
                this.txtMessage.Text = "saved sucessfully";
            }catch(Exception ex)
            {
                this.txtMessage.Text = ex.Message;
            }
        }
    }
}
