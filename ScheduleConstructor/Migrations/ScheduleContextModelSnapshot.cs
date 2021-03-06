﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleConstructor.Data;

namespace ScheduleConstructor.Migrations
{
    [DbContext(typeof(ScheduleContext))]
    partial class ScheduleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScheduleConstructor.Models.Audience", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.ToTable("Audience");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Lesson", b =>
                {
                    b.Property<int>("LessonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasKey("LessonID");

                    b.HasIndex("TeacherID");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AudienceNumber")
                        .HasColumnType("int");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("LessonID")
                        .HasColumnType("int");

                    b.Property<int>("NumberInDay")
                        .HasColumnType("int");

                    b.Property<int>("NumberInWeek")
                        .HasColumnType("int");

                    b.HasKey("SubjectID");

                    b.HasIndex("AudienceNumber");

                    b.HasIndex("GroupID");

                    b.HasIndex("LessonID");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Teacher", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Group", b =>
                {
                    b.HasOne("ScheduleConstructor.Models.Department", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Lesson", b =>
                {
                    b.HasOne("ScheduleConstructor.Models.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleConstructor.Models.Subject", b =>
                {
                    b.HasOne("ScheduleConstructor.Models.Audience", "Audience")
                        .WithMany("Subjects")
                        .HasForeignKey("AudienceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleConstructor.Models.Group", "Group")
                        .WithMany("Subjects")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleConstructor.Models.Lesson", "Lesson")
                        .WithMany("Subjects")
                        .HasForeignKey("LessonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
