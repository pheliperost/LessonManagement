using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonsManagement.Data.Mappings
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.StudentName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Notes)
                .IsRequired()
                .HasColumnType("varchar(500)");

            //has many
            builder.HasMany(p => p.Lessons)
                .WithOne(f => f.Student)
                .HasForeignKey(f => f.StudentId)
                .IsRequired(false);

            builder.ToTable("Student");

        }
    }
}
