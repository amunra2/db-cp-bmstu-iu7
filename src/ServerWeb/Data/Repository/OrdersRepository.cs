using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using System;

namespace ServerWeb.Data.Repository {
    public class OrdersRepository : IAllOrders {

        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart) {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        public void createOrder (Order order) {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.listShopItem;

            foreach (var elem in items) {
                var orderDetail = new OrderDetail {
                    carId = elem.car.id,
                    orderId = order.id,
                    price = elem.car.price
                };

                appDBContent.OrderDetail.Add(orderDetail);
            }

            appDBContent.SaveChanges();
        }
    }
}
