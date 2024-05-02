using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class FileImportedMapping : IEntityTypeConfiguration<FileImported>
    {
        public void Configure(EntityTypeBuilder<FileImported> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.FileDescription)
                .HasColumnType(DataBaseTypes.Varchar(40));

            builder.Property(p => p.FilePath)
                .HasColumnType(DataBaseTypes.Varchar(1000));

            builder.Property(p => p.StartDate)
                .IsRequired()
                .HasColumnType(DataBaseTypes.DateTime());

            builder.Property(p => p.EndDate)
                .IsRequired()
                .HasColumnType(DataBaseTypes.DateTime());

            builder.ToTable("FileImported");

            //EF
            builder.HasMany(p => p.LessonsImported)
                .WithOne(f => f.FileImported)
                .HasForeignKey(f => f.FileImportedId);

            builder.ToTable("FileImported");

        }
    }
}
