// Контроллер для Cars

using Microsoft.AspNetCore.Mvc;
using ServerWeb.Data.Interfaces;
using ServerWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerWeb.Contrtollers {
    public class CarsController : Controller {

        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCateg) {
            _allCars = iAllCars;
            _allCategories = iCarsCateg;
        }

        // Получаем информацию и переводим ее в html-шаблон
        public ViewResult List() {

            ViewBag.Title = "Страница с автомобилями";

            CarsListViewModel obj = new CarsListViewModel();

            obj.allCars = _allCars.cars;
            obj.currentCategory = "Автомобили";

            return View(obj);
        }
    }
}
