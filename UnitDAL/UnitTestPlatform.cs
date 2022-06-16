using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServerING.Models;
using ServerING.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL {
    public class UnitTestPlatform {

        [Fact]
        public void TestPlatformGetById() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlatformRepository platformRepository = new PlatformRepository(context);
                var platform = platformRepository.GetByID(1);

                Assert.Equal(1, platform.Id);
                Assert.Equal("Platform1", platform.Name);
                Assert.Equal(50, platform.Popularity);
                Assert.Equal(50000, platform.Cost);
            }
        }


        [Fact]
        public void TestPlatformAdd() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            // Step - Compare
            using (var context = new AppDBContent(options)) {
                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                };

                platformRepository.Add(expectedPlatform);

                Platform actualPlatform = context.Platform.Find(1);

                Assert.Equal(expectedPlatform.Id, actualPlatform.Id);
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }


        [Fact]
        public void TestPlatformDelete() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }


            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {
                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                };

                Platform actualPlatform = platformRepository.Delete(1);

                Assert.Equal(expectedPlatform.Id, actualPlatform.Id);
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }


        [Fact]
        public void TestPlatformUpdate() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "PlatformChanged",
                    Popularity = 100,
                    Cost = 1000000
                };

                platformRepository.Update(expectedPlatform);

                Platform actualPlatform = context.Platform.Find(1);

                Assert.Equal(expectedPlatform.Id, actualPlatform.Id);
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }


        [Fact]
        public void TestPlatformGetByName() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                };

                Platform actualPlatform = platformRepository.GetByName("Platform1");

                Assert.Equal(expectedPlatform.Id, actualPlatform.Id);
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }


        [Fact]
        public void TestPlatformGetByPopularity() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                };

                IEnumerable<Platform> platforms = platformRepository.GetByPopularity(50);

                foreach (Platform platform in platforms) {
                    Assert.Equal(expectedPlatform.Id, platform.Id);
                    Assert.Equal(expectedPlatform.Name, platform.Name);
                    Assert.Equal(expectedPlatform.Popularity, platform.Popularity);
                    Assert.Equal(expectedPlatform.Cost, platform.Cost);
                }
            }
        }


        [Fact]
        public void TestPlatformGetByCost() {

            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            // Step 1 - Connect to InMemory Database
            var options = new DbContextOptionsBuilder<AppDBContent>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;


            // Step 2 - Add data
            using (var context = new AppDBContent(options)) {

                context.Platform.Add(new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                });

                context.SaveChanges();
            }

            // Step 3 - Compare
            using (var context = new AppDBContent(options)) {

                PlatformRepository platformRepository = new PlatformRepository(context);

                Platform expectedPlatform = new Platform {
                    Id = 1,
                    Name = "Platform1",
                    Popularity = 50,
                    Cost = 50000
                };

                IEnumerable<Platform> platforms = platformRepository.GetByCost(50000);

                foreach (Platform platform in platforms) {
                    Assert.Equal(expectedPlatform.Id, platform.Id);
                    Assert.Equal(expectedPlatform.Name, platform.Name);
                    Assert.Equal(expectedPlatform.Popularity, platform.Popularity);
                    Assert.Equal(expectedPlatform.Cost, platform.Cost);
                }
            }
        }
    }
}
