using WindowSystems.DL.SQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.DO;
using WindowSystems.DL.WEB;

namespace WindowSystems.DL.SQL.Tests
{
    [TestClass()]
    public class MapRepositoryTests
    {




        [TestMethod()]
        public void CreateTest()
        {
            MapRepository mapRepository = new MapRepository(new MyDbContext());

            var location = new Location(1, "1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 =new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location(2, "350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location(3, "10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location(4, "1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);

            mapRepository.Create(map1);
            mapRepository.Create(map2);
            mapRepository.Create(map3);
            mapRepository.Create(map4);
        }

        [TestMethod()]
        public void ReadTest()
        {
            MapRepository mapRepository = new MapRepository(new MyDbContext());

            var location = new Location(1, "1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 = new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location(2, "350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location(3, "10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location(4, "1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);

            mapRepository.Create(map1);
            mapRepository.Create(map2);
            mapRepository.Create(map3);
            mapRepository.Create(map4);

            DO.Map map11 = mapRepository.Read(map1.id);
            DO.Map map22 = mapRepository.Read(map2.id);
            DO.Map map33 = mapRepository.Read(map3.id);
            DO.Map map44 = mapRepository.Read(map4.id);
        }

        //[TestMethod()]
        //public void UpdateTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void DeleteTest()
        {
            MapRepository mapRepository = new MapRepository(new MyDbContext());

            var location = new Location(1, "1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 = new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location(2, "350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location(3, "10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location(4, "1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);

            mapRepository.Create(map1);
            mapRepository.Create(map2);
            mapRepository.Create(map3);
            mapRepository.Create(map4);

            mapRepository.Delete(map1.id);
            mapRepository.Delete(map2.id);
            mapRepository.Delete(map3.id);
            mapRepository.Delete(map4.id);
        }

        [TestMethod()]
        public void ReadAllTest()
        {
            MapRepository mapRepository = new MapRepository(new MyDbContext());

            var location = new Location(1, "1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 = new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location(2, "350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location(3, "10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location(4, "1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);

            mapRepository.Create(map1);
            mapRepository.Create(map2);
            mapRepository.Create(map3);
            mapRepository.Create(map4);

            var maps = mapRepository.ReadAll();
        }

        [TestMethod()]
        public void ReadObjectTest()
        {
            MapRepository mapRepository = new MapRepository(new MyDbContext());

            var location = new Location(1, "1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var map1 = new Map(location, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.084614,37.4217636&z=10&size=650,450&lang=en_US", 10);

            var location2 = new Location(2, "350 5th Ave, New York, NY", 40.748817, -73.985428);
            var map2 = new Map(location2, "https://static-maps.yandex.ru/1.x/?l=map&ll=-73.985428,40.748817&z=10&size=650,450&lang=en_US", 10);

            var location3 = new Location(3, "10 Downing St, Westminster, London", 51.5033, -0.1276);
            var map3 = new Map(location3, "https://static-maps.yandex.ru/1.x/?l=map&ll=-0.1276,51.5033&z=10&size=650,450&lang=en_US", 10);

            var location4 = new Location(4, "1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);
            var map4 = new Map(location4, "https://static-maps.yandex.ru/1.x/?l=map&ll=-122.0305,37.3317&z=10&size=650,450&lang=en_US", 10);

            mapRepository.Create(map1);
            mapRepository.Create(map2);
            mapRepository.Create(map3);
            mapRepository.Create(map4);

            DO.Map map33 = mapRepository.ReadObject(m => m.URL == map3.URL);
        }
    }
}