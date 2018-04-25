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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = txtServer.Text;
                rdp.UserName = txtUserName.Text;
                rdp.AdvancedSettings8.EnableCredSspSupport = true;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = txtPassword.Text;
                rdp.Connect();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + txtServer.Text + " Error:  " + Ex.Message,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Connect(string IP)
        {
            try
            {
                rdp.Server = IP;
                rdp.UserName = "Test";
                rdp.AdvancedSettings8.EnableCredSspSupport = true;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rdp.GetOcx();
                secured.ClearTextPassword = "111111";
                rdp.Connect();
                Exit();
                return (rdp.Connected.ToString());
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error Connecting", "Error connecting to remote desktop " + txtServer.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + txtServer.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "-1";
            }
        }

        public void Exit()
        {
            
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if connected before disconnecting
                if (rdp.Connected.ToString() == "1")
                    rdp.Disconnect();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Disconnecting", "Error disconnecting from remote desktop " + txtServer.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}