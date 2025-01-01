using Microsoft.AspNetCore.Mvc;
using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using ServerWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Contrtollers {
    public class ShopCartController : Controller {

        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRep, ShopCart shopCart) {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItem = items;

            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };

            return View(obj);
        }


        public RedirectToActionResult addToCart (int id) {
            var item = _carRep.cars.FirstOrDefault(i => i.id == id);

            if (item != null) {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }


}
