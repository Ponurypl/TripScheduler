using Example.TripScheduler.Domain.Journeys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.TripScheduler.Persistence.Configuration;

internal sealed class ParticipantSqliteConfiguration : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.ToTable("participants");

        builder.Property(x => x.Id)
               .IsRequired()
               .HasColumnName("id")
               .HasConversion(id => id.Value, value => new ParticipantId(value));

        builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("firstname");

        builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastname");

        builder.OwnsOne(x => x.ContactInformation)
               .Property(x => x.Email)
               .HasMaxLength(60)
               .HasColumnName("email");

        builder.OwnsOne(x => x.ContactInformation)
               .Property(x => x.PhoneNumber)
               .HasMaxLength(20)
               .HasColumnName("phone_number");

        builder.Property<ScheduledJourneyId>("journey_id")
               .HasConversion(id => id.Value, value => new ScheduledJourneyId(value));

        builder.HasKey(x => x.Id);
        builder.HasOne<ScheduledJourney>().WithMany().HasForeignKey("journey_id");
    }
}