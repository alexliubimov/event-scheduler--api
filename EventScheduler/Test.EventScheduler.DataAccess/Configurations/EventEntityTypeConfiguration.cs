using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.EventScheduler.DataAccess.Models;

namespace Test.EventScheduler.DataAccess.Configurations
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(1000);

            builder.Property(e => e.Location)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.OrganizerId)
                .IsRequired();

            builder.Property(e => e.StartTime)
                .IsRequired();

            builder.Property(e => e.EndTime)
                .IsRequired();

            builder.HasOne(e => e.EventOrganizer)
                .WithMany(u => u.OrganizedEvents)
                .HasForeignKey(e => e.OrganizerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Attendees)
                .WithMany(u => u.AttendedEvents)
                .UsingEntity(j => j.ToTable("Attendees"));
        }
    }
}
