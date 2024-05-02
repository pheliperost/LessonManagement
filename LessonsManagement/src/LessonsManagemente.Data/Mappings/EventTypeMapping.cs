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
                .HasColumnType(DataBaseTypes.Varchar());

            builder.Property(p => p.Price)
                 .IsRequired()
                 .HasColumnType(DataBaseTypes.Decimal());

            builder.Property(p => p.Notes)
                .HasColumnType(DataBaseTypes.Varchar(500));

            builder.Property(p => p.DurationTimeInMinutes)
                .IsRequired()
                .HasColumnType(DataBaseTypes.Int());

            //has many
            builder.HasMany(p => p.Lessons)
                .WithOne(f => f.EventType)
                .HasForeignKey(f => f.EventTypeId);

            builder.ToTable("EventType");

        }
    }
}
