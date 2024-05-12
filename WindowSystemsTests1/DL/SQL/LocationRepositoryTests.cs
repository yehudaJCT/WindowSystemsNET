using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowSystems.DL.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowSystems.DL.DO;

namespace WindowSystems.DL.SQL.Tests
{
    [TestClass()]
    public class LocationRepositoryTests
    {

        [TestMethod()]
        public void Test()
        {
            LocationRepository LocationRepository = new LocationRepository(new MyDbContext());

            var location1 = new Location("1600 Amphitheatre Parkway, Mountain View, CA", 37.4223, -122.084);
            var location2 = new Location("350 5th Ave, New York, NY", 40.748817, -73.985428);
            var location3 = new Location("10 Downing St, Westminster, London", 51.5033, -0.1276);
            var location4 = new Location("1 Infinite Loop, Cupertino, CA", 37.3317, -122.0305);

            LocationRepository.Create(location1);
            LocationRepository.Create(location2);
            LocationRepository.Create(location3);
            LocationRepository.Create(location4);

            var v1 = LocationRepository.Read(1);
            var v2 = LocationRepository.Read(2);
            var v3 = LocationRepository.Read(3);
            var v4 = LocationRepository.Read(4);

            LocationRepository.Delete(1);
            LocationRepository.Delete(2);
            LocationRepository.Delete(3);
            LocationRepository.Delete(4);

        }



    }
}