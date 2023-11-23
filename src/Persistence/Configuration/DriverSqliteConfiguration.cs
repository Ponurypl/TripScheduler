using Example.TripScheduler.Domain.Drivers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.TripScheduler.Persistence.Configuration;

internal sealed class DriverSqliteConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("drivers");

        builder.Property(x => x.Id)
               .IsRequired()
               .ValueGeneratedOnAdd()
               .HasColumnName("id")
               .HasConversion(id => id.Value, value => new DriverId(value));

        builder.Property(x => x.FirstName)
               .IsRequired()
               .HasMaxLength(30)
               .HasColumnName("firstname");

        builder.Property(x => x.LastName)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("lastname");

        builder.Property(x => x.Gender)
               .IsRequired()
               .HasPrecision(1)
               .HasColumnName("gender");

        builder.Property(x => x.Rating)
               .IsRequired()
               .HasPrecision(2, 1)
               .HasColumnName("rating");

        builder.Property(x => x.DriverLicenseSince)
                .IsRequired()
                .HasColumnName("driver_license_since");

        builder.HasKey(x => x.Id);
    }
}