using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;




namespace autoUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForUpdates();
        }

        public void CheckForUpdates()
        {       // The link of version.txt at dropbox edited edited with dl=1 ends for auto download
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.dropbox.com/s/kto3l410r8kdb4e/version.txt?dl=1");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            string newestversion = sr.ReadToEnd();
            string currentversion = Application.ProductVersion;
            lblNewest.Text = newestversion;
            if (newestversion.Contains(currentversion))
            {
                // You can change enables or visible settings of elements of login page.
                lblLogin.Text = "Successfully logged in!";
                versionNumber.Text = Application.ProductVersion;
            }
            else
            {

                MessageBox.Show("Please download the new version!\n(We advice you to download new version instead of open it.)");
                // The link of exe file at dropbox edited with dl=1 ends for auto download
                webBrowser1.Navigate("https://www.dropbox.com/s/fy6wgligohahs8p/autoUpdater.exe?dl=1");
                lblLogin.Text = "Logging is failed!";
                versionNumber.Text = Application.ProductVersion;
            }

        }


    }
}
