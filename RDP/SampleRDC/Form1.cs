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
        public Form1()
        {
            InitializeComponent();
        }

        public string Connect(string IP)
        {
            string status = "first init";
            try
            {
                rdp.Server = IP;
                rdp.UserName = "Tester";
                //rdp.AdvancedSettings8.EnableCredSspSupport = true;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = "111111";
                rdp.Connect();
                if (rdp.Connected.ToString() != "0")
                    while(rdp.Connected.ToString() != "1")
                    {
                        Console.WriteLine(rdp.ConnectingText);
                    }
                //System.Threading.Thread.Sleep(3000);

                status = rdp.Connected.ToString();
                //if (rdp.Connected.ToString() == "1")
                //    rdp.Disconnect();
                return (status);
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Connecting, Error connecting to remote desktop {1}", Ex.Message);
                //MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + txtServer.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }
    }
}