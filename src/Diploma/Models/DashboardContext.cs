using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Diploma.Models
{
    public class DashboardContext : IdentityDbContext<User>
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<SubjectGroups> SubjectGroup { get; set; }
        public DbSet<SubjectTeacher> SubjectTeacher { get; set; }
        public DbSet<TeacherGroup> TeacherGroup { get; set; }
        public DbSet<UserRoles> Roles { get; set; }
        public DbSet<CalendarEvent> Events { get; set; }

        public DashboardContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString = Startup.Configuration["Data:DashboardContextConnection"];
            optionsBuilder.UseSqlServer(conString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //-----------------many_to_many-for groups and teachers---------------------------
            modelBuilder.Entity<TeacherGroup>()
                .HasKey(t => new { t.TeacherId, t.GroupId });

            modelBuilder.Entity<TeacherGroup>()
                .HasOne(pt => pt.Group)
                .WithMany(p => p.Teachers)
                .HasForeignKey(pt => pt.GroupId);

            modelBuilder.Entity<TeacherGroup>()
                .HasOne(pt => pt.Teacher)
                .WithMany(t => t.Groups)
                .HasForeignKey(pt => pt.TeacherId);

            //-----------------many_to_many-for teachers and subjects------------------------
            modelBuilder.Entity<SubjectTeacher>()
                .HasKey(t => new { t.TeacherId, t.SubjectId });

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(pt => pt.Subject)
                .WithMany(p => p.Teachers)
                .HasForeignKey(pt => pt.SubjectId);

            modelBuilder.Entity<SubjectTeacher>()
                .HasOne(pt => pt.Teacher)
                .WithMany(t => t.Subjects)
                .HasForeignKey(pt => pt.TeacherId);

            //-----------------many_to_many-for groups and subjects------------------------
            modelBuilder.Entity<SubjectGroups>()
                .HasKey(t => new { t.GroupId, t.SubjectId });

            modelBuilder.Entity<SubjectGroups>()
                .HasOne(pt => pt.Subject)
                .WithMany(p => p.Groups)
                .HasForeignKey(pt => pt.SubjectId);

            modelBuilder.Entity<SubjectGroups>()
                .HasOne(pt => pt.Group)
                .WithMany(t => t.Subjects)
                .HasForeignKey(pt => pt.GroupId);            
        }
    }
}
