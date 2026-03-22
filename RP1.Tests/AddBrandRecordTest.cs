using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using MyProject_L00181476.DataAccess;
using MyProject_L00181476.Models.Models;
using System;
using System.Linq;

namespace RP1.Tests
{
    public class AddBrandRecordTest
    {
        private Brand BrandRecord_One;
        private Brand BrandRecord_Two;

        public AddBrandRecordTest()
        {
            BrandRecord_One = new Brand()
            {
                Id = 100,
                BrandName = "Test Brand 1"
            };

            BrandRecord_Two = new Brand()
            {
                Id = 200,
                BrandName = "Test Brand 2"
            };
        }

        [Test]
        public void SaveBrand_Brand_One_CheckValuesFromDB()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GolfDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new GolfDBContext(options))
            {
                context.Brands.Add(BrandRecord_One);
                context.SaveChanges();
            }

            using (var context = new GolfDBContext(options))
            {
                var brandFromDB = context.Brands.FirstOrDefault(u => u.Id == 100);

                ClassicAssert.AreEqual(BrandRecord_One.Id, brandFromDB.Id);
                Assert.That(brandFromDB.BrandName, Is.EqualTo(BrandRecord_One.BrandName));
            }
        }

        [Test]
        public void SaveBrand_Brand_Two_CheckValuesFromDB()
        {
            var dbName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<GolfDBContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            using (var context = new GolfDBContext(options))
            {
                context.Brands.Add(BrandRecord_Two);
                context.SaveChanges();
            }

            using (var context = new GolfDBContext(options))
            {
                var brandFromDB = context.Brands.FirstOrDefault(u => u.Id == 200);

                ClassicAssert.AreEqual(BrandRecord_Two.Id, brandFromDB.Id);
                Assert.That(brandFromDB.BrandName, Is.EqualTo(BrandRecord_Two.BrandName));
            }
        }
    }
}