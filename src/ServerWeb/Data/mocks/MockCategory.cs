using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.mocks {
    public class MockCategory : ICarsCategory {
        public IEnumerable<Category> allCategories {
            get {
                return new List<Category>() {
                    new Category { categoryName = "Электромобили", description = "Современные машины"},
                    new Category { categoryName = "Седан", description = "Классическая машина с двигателем внутреннего сгорания" }
                };
            }
        }
    }
}
