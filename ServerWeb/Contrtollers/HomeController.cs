using Microsoft.AspNetCore.Mvc;
using ServerWeb.Data.Interfaces;
using ServerWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Contrtollers {
    public class HomeController : Controller {

        private readonly IAllCars _carRep;
        private readonly ICarsCategory _allCategories;

        public HomeController(IAllCars carRep) {
            _carRep = carRep;
        }

        public ViewResult Index() {
            var homeCars = new HomeViewModel {
                favCars = _carRep.getFavCars
            };

            return View(homeCars);
        }
    }
}
