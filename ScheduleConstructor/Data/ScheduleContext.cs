using Microsoft.EntityFrameworkCore;
using ScheduleConstructor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleConstructor.Data
{
    public class ScheduleContext : DbContext
    {
       public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
       { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        //переименовывание таблиц (пример: Groups -> Group)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<Subject>().ToTable("Subject");
            modelBuilder.Entity<Audience>().ToTable("Audience");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
