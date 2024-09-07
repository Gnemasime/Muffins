using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Muffins.Models
{
    //2
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("Muffinss") { }

        public DbSet<Orders> orders { get; set; }
        public DbSet<MuffinItems> muffinItems { get; set; }
    }
}