using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class LessonImportedMapping : IEntityTypeConfiguration<LessonImported>
    {
        public void Configure(EntityTypeBuilder<LessonImported> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.ExecutionDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Price)
               .IsRequired()
               .HasColumnType("decimal");

            builder.ToTable("LessonImported");
        }
    }
}
