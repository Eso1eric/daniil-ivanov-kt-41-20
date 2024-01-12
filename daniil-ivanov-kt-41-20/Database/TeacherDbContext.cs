using daniil_ivanov_kt_41_20.Database.Configurations;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;

namespace daniil_ivanov_kt_41_20.Database;

public class TeacherDbContext : DbContext
{
    public TeacherDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Workload> Workloads { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DegreeConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
    }
}