using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BricABrac.Models;

namespace BricABrac.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ModuleModel> Modules { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<TodoModel> Todos { get; set; }
        public DbSet<StudentGradeModel> StudentGrades { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<StudentGradeModel>();

            modelBuilder.Entity<GradeModel>().Property(p => p.Grade).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<GradeModel>().Property(p => p.Coefficient).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<SubjectModel>().Property(p => p.Coefficient).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<ModuleModel>().ToTable("module");
            modelBuilder.Entity<SubjectModel>().ToTable("subject");
            modelBuilder.Entity<GradeModel>().ToTable("grade");
            modelBuilder.Entity<TodoModel>().ToTable("todo");
        }
    }
}
