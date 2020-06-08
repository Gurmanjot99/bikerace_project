using Microsoft.VisualStudio.TestTools.UnitTesting;
using bikerace_project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bikerace_project.Tests
{
    [TestClass()]
    public class RaceTests
    {
        [TestMethod()]
        public void speedTest()
        {
            Race obj = new Race();
            int y = obj.speed();
            if (y<45) {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void PlayerTest()
        {
            Player obj = new Player();
            int y = obj.result(1);
            if (y>0)
            {
                Assert.IsTrue(true);
            }
        }

    }
}