using System;
using Xunit;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Services;
using ServerING.Models;
using System.Collections.Generic;

namespace UnitDBL {
    public class UnitTestServicePlatform {

        [Fact]
        public void TestPlatformAdd() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 4,
                Name = "Platform4",
                Popularity = 4,
                Cost = 4000
            };

            platformService.AddPlatform(expectedPlatform);

            Platform actualPlatform = platformService.GetPlatformByID(4);

            Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
            Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
            Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
        }

        [Fact]
        public void TestPlatformPlatformUpdate() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 1,
                Name = "Platform1Changed",
                Popularity = 1,
                Cost = 1000
            };

            platformService.UpdatePlatform(expectedPlatform);

            Platform actualPlatform = platformService.GetPlatformByID(1);

            Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
            Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
            Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
        }


        [Fact]
        public void TestPlatformDelete() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 1,
                Name = "Platform1",
                Popularity = 1,
                Cost = 1000
            };

            Platform actualPlatform = platformService.DeletePlatform(expectedPlatform);

            Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
            Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
            Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
        }


        [Fact]
        public void TesPlatformGetByName() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 1,
                Name = "Platform1",
                Popularity = 1,
                Cost = 1000
            };

            Platform actualPlatform = platformService.GetPlatformByName("Platform1");

            Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
            Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
            Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
        }


        [Fact]
        public void TesPlatformGetByPopularity() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 1,
                Name = "Platform1",
                Popularity = 1,
                Cost = 1000
            };

            IEnumerable<Platform> actualPlatforms = platformService.GetPlatformByPopularity(1);

            foreach (Platform actualPlatform in actualPlatforms) {
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }


        [Fact]
        public void TesPlatformGetByCost() {
            IPlatformRepository platformRepository = new PlatformMock();
            PlatformService platformService = new PlatformService(platformRepository);

            Platform expectedPlatform = new Platform {
                Id = 1,
                Name = "Platform1",
                Popularity = 1,
                Cost = 1000
            };

            IEnumerable<Platform> actualPlatforms = platformService.GetPlatformByCost(1);

            foreach (Platform actualPlatform in actualPlatforms) {
                Assert.Equal(expectedPlatform.Name, actualPlatform.Name);
                Assert.Equal(expectedPlatform.Popularity, actualPlatform.Popularity);
                Assert.Equal(expectedPlatform.Cost, actualPlatform.Cost);
            }
        }
    }
}
