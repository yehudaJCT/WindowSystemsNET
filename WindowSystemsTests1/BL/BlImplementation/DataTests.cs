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
            var v = bl.data.GetData("Jerusalem", 12,5);
            //Assert.Fail();
        }

        //[TestMethod()]
        //public void GetRespondeTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void validateAddressTest()
        //{
        //    Assert.Fail();
        //}
    }
}