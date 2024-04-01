using LessonsManagement.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LessonsManagement.Data.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<EventType> EventType { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<FileImported> FileImported { get; set; }
        public DbSet<LessonImported> LessonImported { get; set; }

        //pra registrar os mappings via reflection.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define como varchar 100 pra campos strings não mapeados.
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

            //desabilita delete on cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;


            base.OnModelCreating(modelBuilder);
        }
    }
}
