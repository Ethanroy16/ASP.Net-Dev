
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using System;
using System.Linq;

namespace RP1.Tests
{
    public class AddGolfBallsRecordTest
    {
        private GolfBall GolfBallsRecord_One;
        private GolfBall GolfBallsRecord_Two;

        public AddGolfBallsRecordTest()
        {
            GolfBallsRecord_One = new GolfBall()
            {
                Id = 1000,
                Name = "Test Golf Ball 1",
                Price = 9.99f
            };

            GolfBallsRecord_Two = new GolfBall()
            {
                Id = 2000,
                Name = "Test Golf Ball 2",
                Price = 19.99f
            };
        }

        [Test]
        public void SaveGolfBalls_Record_One_CheckValuesFromDB()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GolfDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new GolfDBContext(options))
            {
                context.GolfBalls.Add(GolfBallsRecord_One);
                context.SaveChanges();
            }

            using (var context = new GolfDBContext(options))
            {
                var golfBallFromDB = context.GolfBalls.FirstOrDefault(u => u.Id == 1000);

                ClassicAssert.AreEqual(GolfBallsRecord_One.Id, golfBallFromDB.Id);
                Assert.That(golfBallFromDB.Name, Is.EqualTo(GolfBallsRecord_One.Name));
            }
        }

        [Test]
        public void SaveGolfBalls_Record_Two_CheckValuesFromDB()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GolfDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new GolfDBContext(options))
            {
                context.GolfBalls.Add(GolfBallsRecord_Two);
                context.SaveChanges();
            }

            using (var context = new GolfDBContext(options))
            {
                var golfBallFromDB = context.GolfBalls.FirstOrDefault(u => u.Id == 2000);

                ClassicAssert.AreEqual(GolfBallsRecord_Two.Id, golfBallFromDB.Id);
                Assert.That(golfBallFromDB.Name, Is.EqualTo(GolfBallsRecord_Two.Name));
            }
        }
    }
}