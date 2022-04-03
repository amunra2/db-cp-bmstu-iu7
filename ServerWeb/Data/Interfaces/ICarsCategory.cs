using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ServerWeb.Data.Interfaces {
    public interface ICarsCategory {
        IEnumerable<Category> allCategories { get; }
    }
}
