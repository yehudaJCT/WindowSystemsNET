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
            var v = bl.data.GetData("Jerusalem", 12, 5);
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

            var v = bl.data.GetData("Jerusalem", 12, 1);

            bl.data.GetResponde(1, "promt test");
        }


    }
}