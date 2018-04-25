using System;
using NUnit.Framework;
using RDPLib;

namespace RDP_tests
{
    [TestFixture]
    public class RDPTests
    {
        [Test]
        public void RDPTest()
        {
            //string IP = "10.0.109.127";
            //RDP_lib.RDP.RDPconnect(IP);
            RDPLib.RDP.Main();
        }
    }
}
