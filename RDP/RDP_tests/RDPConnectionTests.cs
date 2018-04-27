using System;
using NUnit.Framework;
using System.Threading;
using RDPLib;

namespace RDP_tests
{
    [TestFixture]
    public class RDPConnectionTests
    {
        [Test]
        [STAThread]
        public void RDPConnectionTest()
        {
            string IP = TestContext.Parameters["IP"];
            string userName = TestContext.Parameters["UserName"];
            string password = "111111";


            RDPLib.RDP rdp = new RDP();
            Assert.AreEqual("1", rdp.RDPConnect(IP, userName, password));
        }
        
    }
}
