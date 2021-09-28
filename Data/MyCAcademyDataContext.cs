using Microsoft.EntityFrameworkCore;
using MyWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApi.Data
{
    public interface IMyCAcademyDataContext
    {
        DbSet<Faculty> Faculty { get; set; }
        DbSet<Student> Student { get; set; }
        DbSet<Subject> Subject { get; set; }
        DbSet<Article> Article { get; set; }
        DbSet<ArticleType> ArticleType { get; set; }
        DbSet<StudentSubject> StudentSubject { get; set; }
        int SaveChanges();
    }
    public class MyCAcademyDataContext : DbContext, IMyCAcademyDataContext
    {
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Student> Student { get ; set ; }
        public DbSet<Subject> Subject { get ; set ; }
        public DbSet<Article> Article { get ; set ; }
        public DbSet<ArticleType> ArticleType { get ; set ; }
        public DbSet<StudentSubject> StudentSubject { get ; set ; }

        public MyCAcademyDataContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Faculty>()
                .HasMany<Student>(f => f.Students)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Faculty>()
                .HasMany<Subject>(f => f.Subjects)
                .WithOne(sub => sub.Faculty)
                .HasForeignKey(sub => sub.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Faculty>()
                .HasMany<Article>(f => f.Articles)
                .WithOne(s => s.Faculty)
                .HasForeignKey(s => s.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Student>()
                .HasMany<Article>(s => s.Articles)
                .WithOne(a => a.Student)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Article>()
                .HasOne<ArticleType>(a => a.ArticleType)
                .WithMany(at => at.Articles)
                .HasForeignKey(a => a.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Student>()
                .HasMany<StudentSubject>(s => s.StudentSubjects)
                .WithOne(ss => ss.Student)
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Subject>()
                .HasMany<StudentSubject>(s => s.StudentSubjects)
                .WithOne(ss => ss.Subject)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
