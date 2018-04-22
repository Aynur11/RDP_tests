using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SampleRDC
{
     public static class RDP
    {
        public static Form1 rdpForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            rdpForm = new Form1();
            rdpForm.Connect("192.168.56.2");

            Application.Run(rdpForm);


        }
    }
}