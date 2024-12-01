using C_EgitimKampi301_11_EntityLayer.concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_EgitimKampi301_11_DataAccessLayer.Context
{
    public class CampContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        //^yukarıdaki gösterimde sınıfla tablo kısmını ayırmak için kullanılır
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
