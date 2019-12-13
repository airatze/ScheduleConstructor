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

        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<Subject>().ToTable("Subject");
        }
    }
}
