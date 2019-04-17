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

        public DbSet<Modules> Modules { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<StudentGradeModel> StudentGrades { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<StudentGradeModel>();

            modelBuilder.Entity<Grades>().ToTable("grade");
            modelBuilder.Entity<Modules>().ToTable("module");
            modelBuilder.Entity<Subjects>().ToTable("subject");


            //modelBuilder.Entity<ModuleModel>().ToTable("module");
            //modelBuilder.Entity<SubjectModel>().ToTable("subject");
            //modelBuilder.Entity<GradeModel>().ToTable("grade");
        }
    }
}
