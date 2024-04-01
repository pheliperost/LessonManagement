﻿// <auto-generated />
using System;
using LessonsManagement.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LessonsManagement.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20240315045606_fix filepath character length - fileimported")]
    partial class fixfilepathcharacterlengthfileimported
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LessonsManagement.Business.Models.EventType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DurationTimeInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.FileImported", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FileDescription")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("FilePath")
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("FileImported");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventTypeId");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.LessonImported", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("EventTypeId");

                    b.Property<DateTime>("ExecutionDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("FileImportedId");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("FileImportedId");

                    b.HasIndex("StudentId");

                    b.ToTable("LessonImported");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.Lesson", b =>
                {
                    b.HasOne("LessonsManagement.Business.Models.EventType", "EventType")
                        .WithMany("Lessons")
                        .HasForeignKey("EventTypeId");

                    b.HasOne("LessonsManagement.Business.Models.Student", "Student")
                        .WithMany("Lessons")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("LessonsManagement.Business.Models.LessonImported", b =>
                {
                    b.HasOne("LessonsManagement.Business.Models.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId");

                    b.HasOne("LessonsManagement.Business.Models.FileImported", "FileImported")
                        .WithMany("LessonsImported")
                        .HasForeignKey("FileImportedId");

                    b.HasOne("LessonsManagement.Business.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");
                });
#pragma warning restore 612, 618
        }
    }
}
