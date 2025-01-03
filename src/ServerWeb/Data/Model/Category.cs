﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ServerWeb.Data.Model {
    public class Category {
        public int id { get; set; }

        public string categoryName { get; set; }

        public string description { get; set; }

        public List<Car> cars { get; set; }
    }
}
