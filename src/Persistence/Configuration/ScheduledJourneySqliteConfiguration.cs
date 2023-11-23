using Example.TripScheduler.Domain.Cars;
using Example.TripScheduler.Domain.Drivers;
using Example.TripScheduler.Domain.Journeys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.TripScheduler.Persistence.Configuration;

internal sealed class ScheduledJourneySqliteConfiguration : IEntityTypeConfiguration<ScheduledJourney>
{
    public void Configure(EntityTypeBuilder<ScheduledJourney> builder)
    {
        builder.ToTable("scheduledjourneys");

        builder.Property(x => x.Id)
               .IsRequired()
               .HasColumnName("id")
               .HasConversion(id => id.Value, value => new ScheduledJourneyId(value));

        builder.Property(x => x.Driver)
                .IsRequired()
                .HasColumnName("driver_id")
                .HasConversion(id => id.Value, value => new DriverId(value));

        builder.Property(x => x.Car)
                .IsRequired()
                .HasColumnName("car_id")
                .HasConversion(id => id.Value, value => new CarId(value));

        builder.Property(x => x.Origin)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("origin");

        builder.Property(x => x.Destination)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("destination");

        builder.Property(x => x.DepartureTime)
                .IsRequired()
                .HasColumnName("departure_time");


        builder.HasKey(x => x.Id);
        builder.HasOne<Driver>().WithMany().HasForeignKey(x => x.Driver);
        builder.HasOne<Car>().WithMany().HasForeignKey(x => x.Car);
        builder.HasMany(x => x.Participants).WithOne(x => x.ScheduledJourney);
    }
}