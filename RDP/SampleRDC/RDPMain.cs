using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RDPLib
{
     public static class RDP
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            string IP = "10.0.109.127";
            Form1 rdpForm;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            rdpForm = new Form1();
            rdpForm.Connect(IP);

            Application.Run(rdpForm);
            //RDPconnect("10.0.109.127");
        }
        public static void RDPconnect(string IP)
        {
            Form1 rdpForm;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            rdpForm = new Form1();
            rdpForm.Connect(IP);

            Application.Run(rdpForm);


        }
    }
}