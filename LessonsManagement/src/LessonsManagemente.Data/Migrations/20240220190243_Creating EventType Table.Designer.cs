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
    [Migration("20240220190243_Creating EventType Table")]
    partial class CreatingEventTypeTable
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

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("EventType");
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

                    b.Property<Guid>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Lesson");
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
#pragma warning restore 612, 618
        }
    }
}
