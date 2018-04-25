using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace RDPLib
{
    public class RDP
    {
        //private Form1 rdpForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        public string RDPConnect()
        {
            string status = "first init";
            Thread thread = new Thread(
                () =>
                {
                    
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Form1 rdpForm = new Form1();
                    Application.Run(rdpForm);

                    status = rdpForm.Connect("192.168.56.2");

                    Console.WriteLine(status);
                    //Application.Exit();
                    if (rdpForm.InvokeRequired)
                    {
                        rdpForm.BeginInvoke(new MethodInvoker(() => rdpForm.Close()));
                        Application.Exit();
                    }
                    else
                    {
                        rdpForm.Close();
                        Application.Exit();
                    }

                    rdpForm.Exit();
                    rdpForm.Close();
                }
                );
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            
            Console.WriteLine(thread.ThreadState);
            return status;

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 rdpForm = new Form1();
            //rdpForm.Connect("192.168.56.2");

            //Application.Run(rdpForm);


        }
    }
}