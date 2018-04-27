using System;
using NUnit.Framework;
using System.Threading;
using RDPLib;

namespace RDP_tests
{
    [TestFixture]
    public class RDPConnectionTests
    {
        [Test, TestCaseSource("testdata")]
        [STAThread]
        public void RDPConnectionTest(string IP)
        {
            //string IP = "10.0.109.127";
            string userName = "Tester";
            string password = "111111";


            RDPLib.RDP rdp = new RDP();
            Assert.AreEqual("1", rdp.RDPConnect(IP, userName, password));
        }
        
    }
}
