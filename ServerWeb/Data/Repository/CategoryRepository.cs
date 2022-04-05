using Microsoft.EntityFrameworkCore;
using ServerWeb.Data.Interfaces;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.Repository {
    public class CategoryRepository : ICarsCategory {

        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent) {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Category> allCategories => appDBContent.Category;
    }
}
