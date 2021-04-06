using DevCars.API.Entities;
using DevCars.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DevCars.API.Persistence
{
    public class DevCarsDbContext : DbContext
    {
        public DevCarsDbContext(DbContextOptions<DevCarsDbContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ExtraOrderItem> ExtraOrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CarDbConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomerDbConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderDbConfiguration());
            //modelBuilder.ApplyConfiguration(new ExtraOrderItemDbConfiguration());

            //ISSO TUDO ACIMA, FAZ O MESMO QUE O COMANDO ABAIXO

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
    }
}
