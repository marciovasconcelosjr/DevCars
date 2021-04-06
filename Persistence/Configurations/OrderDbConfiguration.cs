using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DevCars.API.Persistence.Configurations
{
    public class OrderDbConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {

            builder
                .HasKey(o => o.Id);

            builder
                .HasMany(o => o.ExtraItens)
                .WithOne()
                .HasForeignKey(e => e.IdOrder)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(o => o.Car)
                .WithOne()
                .HasForeignKey<Orders>(o => o.IdCar)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
