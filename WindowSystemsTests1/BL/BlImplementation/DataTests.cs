using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.BL.BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowSystems.BL.BlImplementation;
using WindowSystems.BL.BLApi;

namespace WindowSystems.BL.BlImplementation.Tests
{
    [TestClass()]
    public class DataTests
    {
        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    IBl bl = new Bl();
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void getAllItemsTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetDataTest()
        {
            IBl bl = new Bl();
            var v = bl.data.GetData("Jerusalem", 8, 5);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            IBl bl = new Bl();
            bl.data.Delete(2);

        }

        [TestMethod()]
        public void GetRespondeTest()
        {
            IBl bl = new Bl();

            var v = bl.data.GetData("1600 Amphitheatre Parkway, Mountain View, CA", 8, 1);

            bl.data.GetResponde(1, "promt test");
        }

        [TestMethod()]
        public void validateAddressTest()
        {
            IBl bl = new Bl();

            var v1 = bl.data.validateAddress("Jerusalem");

            var v2 = bl.data.validateAddress("c8936cge9");
        }
    }
}