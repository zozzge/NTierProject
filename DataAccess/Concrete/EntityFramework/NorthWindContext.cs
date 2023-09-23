using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //context: associating the db tables with project classes
    public class NorthWindContext:DbContext
    {
        //indicating the database we are working with
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // @: getting rid of the need for 2\\
            // usually the Server is an IP address
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");

        }
        public DbSet<Product> Products   { get; set; }
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
