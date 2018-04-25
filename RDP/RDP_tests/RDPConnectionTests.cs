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
            //Thread rdpThread = new Thread(RDPLib.RDP.RDPConnect());
            //RDPLib.RDP.RDPConnect();

            RDPLib.RDP rdp = new RDP();
            Assert.AreEqual("1", rdp.RDPConnect());
        }
    }
}
