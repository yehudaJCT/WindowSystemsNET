using WindowSystems.DL.SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.DO;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.SQL.Tests
{
    [TestClass()]
    public class MapRepositoryTests
    {
        MyRepository mapRepository = new MyRepository(new MyDbContext());



        [TestMethod()]
        public void CreateTest()
        {
            var location = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 =new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location("350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location("10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location("1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);




            mapRepository.Create(1, map1);
            mapRepository.Create(2, map2);
            mapRepository.Create(3, map3);
            mapRepository.Create(4, map4);
        }

        [TestMethod()]
        public void ReadTest()
        {
            DO.Map map1 = mapRepository.Read(1);
            DO.Map map2 = mapRepository.Read(2);
            DO.Map map3 = mapRepository.Read(3);
            DO.Map map4 = mapRepository.Read(4);
        }

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DeleteTest()
        //{
        //    mapRepository.Delete(1);
        //    mapRepository.Delete(2);
        //    mapRepository.Delete(3);
        //    mapRepository.Delete(4);
        //}

        [TestMethod()]
        public void ReadAllTest()
        {
            var maps = mapRepository.ReadAll();
        }

        [TestMethod()]
        public void ReadObjectTest()
        {
            var location3 = new Location("10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            DO.Map map = mapRepository.ReadObject(m => m.Value.URL == map3.URL);
        }
    }
}