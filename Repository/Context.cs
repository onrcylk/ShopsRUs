using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<CustomerRole> CustomerRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"User ID=sa;Password=123;Server=.;Database=Shop;Integrated Security=true;Pooling=true;");
            }
        }
    }
}
