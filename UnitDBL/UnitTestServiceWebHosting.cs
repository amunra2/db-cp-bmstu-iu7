using System;
using Xunit;
using ServerING.Interfaces;
using ServerING.Mocks;
using ServerING.Services;
using ServerING.Models;
using System.Collections.Generic;

namespace UnitDBL {
    public class UnitTestServiceWebHosting {

        [Fact]
        public void TestWebHostingAdd() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 4,
                Name = "WH4",
                PricePerMonth = 4000,
                SubMonths = 4
            };

            webHostingService.AddWebHosting(expectedWebHosting);

            WebHosting actualWebHosting = webHostingService.GetWebHostingByID(4);

            Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
            Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
            Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
        }


        [Fact]
        public void TestWebHostingUpdate() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 1,
                Name = "WH1Changed",
                PricePerMonth = 1000,
                SubMonths = 1
            };

            webHostingService.UpdateWebHosting(expectedWebHosting);

            WebHosting actualWebHosting = webHostingService.GetWebHostingByID(1);

            Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
            Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
            Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
        }


        [Fact]
        public void TestUserDelete() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 1,
                Name = "WH1",
                PricePerMonth = 1000,
                SubMonths = 1
            };

            WebHosting actualWebHosting = webHostingService.DeleteWebHosting(expectedWebHosting);

            Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
            Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
            Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
        }


        [Fact]
        public void TestWebHostingGetByName() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 1,
                Name = "WH1",
                PricePerMonth = 1000,
                SubMonths = 1
            };

            WebHosting actualWebHosting = webHostingService.GetWebHostingByName("WH1");

            Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
            Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
            Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
        }


        [Fact]
        public void TestWebHostingGetByPricePerMonths() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 1,
                Name = "WH1",
                PricePerMonth = 1000,
                SubMonths = 1
            };

            IEnumerable<WebHosting> actualWebHostings = webHostingService.GetWebHostingByPricePerMonth(1000);

            foreach (WebHosting actualWebHosting in actualWebHostings) {
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }


        [Fact]
        public void TestWebHostingGetBySubMonths() {
            IWebHostingRepository webHostingRepository = new WebHostingMock();
            WebHostingService webHostingService = new WebHostingService(webHostingRepository);

            WebHosting expectedWebHosting = new WebHosting {
                Id = 1,
                Name = "WH1",
                PricePerMonth = 1000,
                SubMonths = 1
            };

            IEnumerable<WebHosting> actualWebHostings = webHostingService.GetWebHostingBySubMonths(1);

            foreach (WebHosting actualWebHosting in actualWebHostings) {
                Assert.Equal(expectedWebHosting.Name, actualWebHosting.Name);
                Assert.Equal(expectedWebHosting.PricePerMonth, actualWebHosting.PricePerMonth);
                Assert.Equal(expectedWebHosting.SubMonths, actualWebHosting.SubMonths);
            }
        }
    }
}
