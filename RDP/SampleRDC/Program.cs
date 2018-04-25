using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace RDPLib
{
    public class RDP
    {
        //private Form1 rdpForm;
        volatile string status = "first init";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public string RDPConnect()
        {
            Thread thread = new Thread(
                () =>
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form1 rdpForm = new Form1();
                    //rdpForm.Visible = false;
                    rdpForm.Load += RdpForm_Load;
                    status = rdpForm.Connect("10.0.109.127");
                    //Application.Run(rdpForm);
                    rdpForm.Visible = false;
                    Console.WriteLine(status);
                    ////Application.Exit();
                    //if (rdpForm.InvokeRequired)
                    //    rdpForm.BeginInvoke(new MethodInvoker(() => rdpForm.Close()));
                    //else
                    //    rdpForm.Close();

                }
                );
            //thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            Thread.Sleep(3000);

            thread.Abort();
            //Console.WriteLine(thread.ThreadState);
            return status;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 rdpForm = new Form1();
            //rdpForm.Connect("192.168.56.2");

            //Application.Run(rdpForm);


        }

        private void RdpForm_Load(object sender, EventArgs e)
        {
            var form = (Form)sender;
            form.ShowInTaskbar = false;
            form.Opacity = 0;
        }
    }
}