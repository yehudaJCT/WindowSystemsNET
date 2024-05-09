using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.BL.BlImplementation;
using OpenAI_ChatGPT;
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

        private readonly IChatCompletionService _chatCompletionService;

        [TestMethod()]
        public void GetDataTest()
        {
            IBl bl = new Bl(_chatCompletionService);
            var v = bl.data.GetData("Jerusalem", 8, 5);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            IBl bl = new Bl(_chatCompletionService);
            bl.data.Delete(2);

        }

        [TestMethod()]
        public void GetRespondeTest()
        {
            //IBl bl = new Bl(_chatCompletionService);

            //var v = bl.data.GetData("1600 Amphitheatre Parkway, Mountain View, CA", 8, 1);

            //bl.data.GetResponde(1, "promt test");
        }

        [TestMethod()]
        public void validateAddressTest()
        {
            IBl bl = new Bl(_chatCompletionService);

            var v1 = bl.data.validateAddress("Jerusalem");

            var v2 = bl.data.validateAddress("c8936cge9");
        }

        [TestMethod()]
        public void getAllItemsTest1()
        {
            IBl bl = new Bl(_chatCompletionService);

            var v1 = bl.data.GetData("Jerusalem", 8);
            var v2 = bl.data.GetData("Gaza", 12);
            var v3 = bl.data.GetData("London", 9);
            var v4 = bl.data.GetData("Jerusalem", 10);

            var vs = bl.data.getAllItems();
        }
    }
}