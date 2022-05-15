using Microsoft.EntityFrameworkCore;
using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.Repository {
    public class CarRepository : IAllCars {

        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> cars => appDBContent.Car.Include(c => c.category);

        public IEnumerable<Car> getFavCars => appDBContent.Car.Where(p => p.isFavourite).Include(c => c.category);

        public Car getObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
