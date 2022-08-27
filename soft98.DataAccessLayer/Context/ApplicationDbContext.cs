using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using soft98.DataAccessLayer.Entities;

namespace soft98.DataAccessLayer.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Matlab> Matlabs { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerFactor> BannerFactors { get; set; }
    }
}
