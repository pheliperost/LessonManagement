using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class LessonsMapping : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.ExecutionDate)
                .IsRequired()
                .HasColumnType(DataBaseTypes.DateTime());

            builder.Property(p => p.Notes)
                .IsRequired()
                .HasColumnType(DataBaseTypes.Varchar(500));

            builder.ToTable("Lesson");

        }
    }
}
