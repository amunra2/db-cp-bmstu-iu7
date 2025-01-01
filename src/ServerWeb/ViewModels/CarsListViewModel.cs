// Выделение объекта для объединения более мелких объектов
// (передается как единый объект в html)

using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.ViewModels {
    public class CarsListViewModel {

        public IEnumerable<Car> allCars { get; set; }

        public string currentCategory { get; set; }
    }
}
