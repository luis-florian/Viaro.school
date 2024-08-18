using Microsoft.EntityFrameworkCore;
using School.Core.Entities;

namespace School.DataAccess;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> op) : DbContext(op)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<GradeStudent> GradeStudents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Teacher)
            .WithMany(g => g.Grades)
            .HasForeignKey(g => g.TeacherId);

        //modelBuilder.Entity<GradeStudent>()
        //    .HasKey(gs => new { gs.StudentId, gs.GradeId });

        modelBuilder.Entity<GradeStudent>()
            .HasOne(g => g.Student)
            .WithMany(g => g.GradeStudents)
            .HasForeignKey(g => g.StudentId);

        modelBuilder.Entity<GradeStudent>()
            .HasOne(g => g.Grade)
            .WithMany(g => g.GradeStudents)
            .HasForeignKey(g => g.GradeId);
    }
}
