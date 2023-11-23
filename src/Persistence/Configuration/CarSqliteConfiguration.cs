using Example.TripScheduler.Domain.Cars;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.TripScheduler.Persistence.Configuration;

internal sealed class CarSqliteConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("cars");

        builder.Property(x => x.Id)
               .IsRequired()
               .ValueGeneratedOnAdd()
               .HasColumnName("id")
               .HasConversion(id => id.Value, value => new CarId(value));

        builder.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("brand");

        builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("model");

        builder.Property(x => x.ProductionYear)
                .IsRequired()
                .HasPrecision(4,0)
                .HasColumnName("production_year");

        builder.Property(x => x.PassengerSeats)
                .IsRequired()
                .HasPrecision(2,0)
                .HasColumnName("passenger_seats");

        builder.HasKey(x => x.Id);
    }
}