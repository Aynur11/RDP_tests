using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSTSCLib;

namespace RDPLib
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Конструктор дополнительно инициализирует объект для работы с RDP
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public Form1(string IP, string userName, string password)
        {
            InitializeComponent();

            rdp.Server = IP;
            rdp.UserName = userName;
            IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
            secured.ClearTextPassword = password;
            rdp.AdvancedSettings8.EnableCredSspSupport = true;

            this.Opacity = 0;
            this.ShowInTaskbar = false;
        }
        
        public string GetStatus
        {
            get
            {
                return rdp.Connected.ToString();
            }
        }

        public void Connect()
        {
            try
            {
                //rdp.Server = IP;
                //rdp.UserName = "Tester";
                //rdp.AdvancedSettings8.EnableCredSspSupport = true;
                //IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                //secured.ClearTextPassword = "111111";
                rdp.Connect();
                //if (rdp.Connected.ToString() == "1")
                //    rdp.Disconnect();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Connecting, Error connecting to remote desktop {0}", Ex.Message);
                //MessageBox.Show(" Error:  " + Ex.Message);
            }
            //finally
            //{
            //    if (rdp.Connected.ToString() == "1")
            //        rdp.Disconnect();
            //}
        }
        
        private void rdp_Connect(object sender, EventArgs e)
        {
            Connect();
            //MessageBox.Show("Connecting...current status is " + GetStatus);
        }

        private void rdp_ConnectedStatus(object sender, EventArgs e)
        {
            //MessageBox.Show("Connected. Current status is " + GetStatus);
            RDP.Status = GetStatus;
            this.Close();
        }
        

    }
}