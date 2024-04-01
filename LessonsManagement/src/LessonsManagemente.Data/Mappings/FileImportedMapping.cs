using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class FileImportedMapping : IEntityTypeConfiguration<FileImported>
    {
        public void Configure(EntityTypeBuilder<FileImported> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.FileDescription)
                .HasColumnType("varchar(40)");

            builder.Property(p => p.FilePath)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.StartDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.EndDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.ToTable("FileImported");

            //EF
            builder.HasMany(p => p.LessonsImported)
                .WithOne(f => f.FileImported)
                .HasForeignKey(f => f.FileImportedId);

            builder.ToTable("FileImported");

        }
    }
}
