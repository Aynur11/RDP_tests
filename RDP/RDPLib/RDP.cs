using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace RDPLib
{
    public class RDP
    {
        public static string Status = "empty";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public string RDPConnect(string IP, string userName, string password)
        {
            Thread thread = new Thread(
                () =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form1 rdpForm = new Form1(IP, userName, password);
                    //rdpForm.Close();
                    //rdpForm.Load += RdpForm_Load;
                    Application.Run(rdpForm);
        }
                );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            Thread.Sleep(5000);
            thread.Abort();
            return Status;
        }


        //private void RdpForm_Load(object sender, EventArgs e)
        //{
        //    var form = (Form)sender;
        //    form.Opacity = 0;
        //    form.ShowInTaskbar = false;
        //}
    }
}