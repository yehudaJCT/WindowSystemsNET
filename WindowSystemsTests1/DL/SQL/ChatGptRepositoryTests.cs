using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.SQL;
using System;


namespace WindowSystems.DL.SQL.Tests
{
    [TestClass()]
    public class ChatGptRepositoryTests
    {

        [TestMethod()]
        public void ReadTest()
        {
            ChatGptRepository chatGptRepository = new ChatGptRepository(new MyDbContext());

            DL.DO.ChatGpt chatGpt1 = new DO.ChatGpt(1, "test prompt 1", "test responde 1");
            DL.DO.ChatGpt chatGpt2 = new DO.ChatGpt(2, "test prompt 2", "test responde 1");
            DL.DO.ChatGpt chatGpt3 = new DO.ChatGpt(3, "test prompt 3", "test responde 1");
            DL.DO.ChatGpt chatGpt4 = new DO.ChatGpt(4, "test prompt 4", "test responde 1");

            chatGptRepository.Create(chatGpt1);
            chatGptRepository.Create(chatGpt2);
            chatGptRepository.Create(chatGpt3);
            chatGptRepository.Create(chatGpt4);

            var v1 = chatGptRepository.Read(1);
            var v2 = chatGptRepository.Read(2);
            var v3 = chatGptRepository.Read(3);
            var v4 = chatGptRepository.Read(4);

        }

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReadAllTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ReadObjectTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void ObjectToIdTest()
        //{
        //    Assert.Fail();
        //}
    }
}