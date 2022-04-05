﻿using Microsoft.EntityFrameworkCore;
using ServerWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ServerWeb.Data {
    public class AppDBContent : DbContext {

        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) {

        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
