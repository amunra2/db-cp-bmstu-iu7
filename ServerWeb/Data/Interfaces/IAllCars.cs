using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.Interfaces {
    public interface IAllCars {
        IEnumerable<Car> cars { get; }

        IEnumerable<Car> getFavCars { get; set; }

        Car getObjectCar(int carId);
    }
}
