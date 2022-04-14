// Контроллер для Cars

using Microsoft.AspNetCore.Mvc;
using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
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

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]

        // Получаем информацию и переводим ее в html-шаблон
        public ViewResult List(string category) {

            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category)) {
                cars = _allCars.cars.OrderBy(i => i.id);
            }
            else {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.cars.Where(i => i.category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    currCategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.cars.Where(i => i.category.categoryName.Equals("Седан")).OrderBy(i => i.id);
                    currCategory = "Седан";

                }
            }

            var carObj = new CarsListViewModel {
                allCars = cars,
                currentCategory = currCategory
            };



            /*ViewBag.Title = "Страница с автомобилями";

            CarsListViewModel obj = new CarsListViewModel();

            obj.allCars = _allCars.cars;
            obj.currentCategory = "Автомобили";*/

            return View(carObj);
        }
    }
}
