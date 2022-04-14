using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.Model {
    public class ShopCart {

        private readonly AppDBContent appDBContent;

        public ShopCart(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> listShopItem { get; set; }


        public static ShopCart GetCart(IServiceProvider services) { // добавить корзину или корзина уже есть
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session; // создать сессию

            var context = services.GetService<AppDBContent>();

            string shopCarId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCarId);

            return new ShopCart(context) { ShopCartId = shopCarId };
        }

        // добавлять в корзину
        public void AddToCart(Car car) {
            this.appDBContent.ShopCartItem.Add(new ShopCartItem {
                ShopCartId = ShopCartId,
                car = car,
                price = car.price
            });

            appDBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems() {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
