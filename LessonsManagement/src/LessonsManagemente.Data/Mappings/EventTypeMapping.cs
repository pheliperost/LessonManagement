using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class EventTypeMapping : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.EventTypeName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Price)
                 .IsRequired()
                 .HasColumnType("decimal");

            builder.Property(p => p.Notes)
                .HasColumnType("varchar(500)");

            builder.Property(p => p.DurationTimeInMinutes)
                .IsRequired()
                .HasColumnType("int");

            //has many
            builder.HasMany(p => p.Lessons)
                .WithOne(f => f.EventType)
                .HasForeignKey(f => f.EventTypeId);

            builder.ToTable("EventType");

        }
    }
}
