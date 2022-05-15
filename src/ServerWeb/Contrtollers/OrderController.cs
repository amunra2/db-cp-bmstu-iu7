using Microsoft.AspNetCore.Mvc;
using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;

namespace ServerWeb.Contrtollers {
    public class OrderController : Controller {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart) {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout () { // для принятия данных из формы
            return View();
        }


        [HttpPost] // при отправке формы вызывается функция
        public IActionResult Checkout(Order order) { // для принятия данных из формы

            shopCart.listShopItem = shopCart.getShopItems();

            if (shopCart.listShopItem.Count == 0) {
                ModelState.AddModelError("", "У вас должны быть товары"); // выдать ошибку пользователю
            }

            if (ModelState.IsValid) { // если все поля пройдут проверку
                allOrders.createOrder(order);

                return RedirectToAction("Complete");
            }

            return View(order); // проверить без передачи Order
        }

        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан";

            return View();
        }
    }
}
