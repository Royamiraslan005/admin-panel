﻿using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)  { }

        public DbSet<Category>categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImage> productsImage { get; set; }


    }
    
}
