using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data {
    public class DBObjects {

        public static void Initial(AppDBContent content) {

            if (!content.Category.Any()) {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any()) {
                content.AddRange(
                    new Car {
                        name = "Tesla",
                        shortDesc = "Электрический монстр",
                        longDesc = "Электромобиль от компани Tesla Mototors",
                        img = "/img/tesla.jpg",
                        price = 45000,
                        isFavourite = true,
                        available = true,
                        category = Categories["Электромобили"]
                    },
                    new Car {
                        name = "Lada",
                        shortDesc = "Вроде даже едет",
                        longDesc = "Компания, разрабатывающая болты и гайки",
                        img = "/img/lada.jpg",
                        price = 100,
                        isFavourite = true,
                        available = true,
                        category = Categories["Седан"]
                    }
                );
            }

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories {
            get {
                if (category == null) {
                    var list = new Category[] {
                        new Category { categoryName = "Электромобили", description = "Современные машины"},
                        new Category { categoryName = "Седан", description = "Классическая машина с двигателем внутреннего сгорания" }
                    };

                    category = new Dictionary<string, Category>();

                    foreach (Category el in list) {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;
            }
        }
    }
}
