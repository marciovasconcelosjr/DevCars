﻿using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevCars.API.Persistence.Configurations
{
    public class CustomerDbConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder
               .HasKey(c => c.Id);

            builder
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.IdCustomer)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
