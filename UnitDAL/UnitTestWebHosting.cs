using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerING.Models;
using ServerING.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL {
    public class UnitTestWebHosting {

        [Fact]
        public void TestWebHostingGetById() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                WebHostingRepository webHostingRepository = new WebHostingRepository(context);
                var webHosting = webHostingRepository.GetByID(1);

                Assert.Equal(1, webHosting.Id);
                Assert.Equal("WebHosting1", webHosting.Name);
                Assert.Equal(5000, webHosting.PricePerMonth);
                Assert.Equal(12, webHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingAdd() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step - Compare
            using (var context = new AppDBContent(options)) {
                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                webHostingRepository.Add(expectedWebHosting);

                WebHosting actualWebHosting = context.WebHosting.Find(1);

                Assert.Equal(expectedWebHosting.Id, actualWebHosting.Id);
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingDelete() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }


            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                WebHosting actualWebHosting = webHostingRepository.Delete(1);

                Assert.Equal(expectedWebHosting.Id, actualWebHosting.Id);
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingUpdate() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                webHostingRepository.Update(expectedWebHosting);

                WebHosting actualWebHosting = context.WebHosting.Find(1);

                Assert.Equal(expectedWebHosting.Id, actualWebHosting.Id);
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingGetByName() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                WebHosting actualWebHosting = webHostingRepository.GetByName("WebHosting1");

                Assert.Equal(expectedWebHosting.Id, actualWebHosting.Id);
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingGetByPricePerMonth() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                IEnumerable<WebHosting> webHostings = webHostingRepository.GetByPricePerMonth(5000);

                foreach (WebHosting webHosting in webHostings) {
                    Assert.Equal(expectedWebHosting.Id, webHosting.Id);
                    Assert.Equal(expectedWebHosting.Name, webHosting.Name);
                    Assert.Equal(expectedWebHosting.PricePerMonth, webHosting.PricePerMonth);
                    Assert.Equal(expectedWebHosting.SubMonths, webHosting.SubMonths);
                }
            }
        }


        [Fact]
        public void TestWebHostingGetBySubMonths() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.WebHosting.Add(new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                WebHostingRepository webHostingRepository = new WebHostingRepository(context);

                WebHosting expectedWebHosting = new WebHosting {
                    Id = 1,
                    Name = "WebHosting1",
                    PricePerMonth = 5000,
                    SubMonths = 12
                };

                IEnumerable<WebHosting> webHostings = webHostingRepository.GetBySubMonths(12);

                foreach (WebHosting webHosting in webHostings) {
                    Assert.Equal(expectedWebHosting.Id, webHosting.Id);
                    Assert.Equal(expectedWebHosting.Name, webHosting.Name);
                    Assert.Equal(expectedWebHosting.PricePerMonth, webHosting.PricePerMonth);
                    Assert.Equal(expectedWebHosting.SubMonths, webHosting.SubMonths);
                }
            }
        }
    }
}
