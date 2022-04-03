using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.mocks {
    public class MockCars : IAllCars {
        private readonly ICarsCategory _categoryCars = new MockCategory();

        public IEnumerable<Car> cars {
            get {
                return new List<Car> {
                    new Car { name = "Tesla",
                              shortDesc = "Электрический монстр",
                              longDesc = "Электромобиль от компани Tesla Mototors",
                              price = 45000,
                              isFavourite = true,
                              available = true,
                              category = _categoryCars.allCategories.First()
                    },
                    new Car { name = "Lada",
                              shortDesc = "Вроде даже едет",
                              longDesc = "Компания, разрабатывающая болты и гайки",
                              price = 100,
                              isFavourite = true,
                              available = true,
                              category = _categoryCars.allCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carId) {
            throw new NotImplementedException();
        }
    }
}
