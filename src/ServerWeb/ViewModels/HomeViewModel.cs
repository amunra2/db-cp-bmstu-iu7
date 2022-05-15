using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ServerWeb.ViewModels {
    public class HomeViewModel {

        public IEnumerable<Car> favCars { get; set; }
    }
}
