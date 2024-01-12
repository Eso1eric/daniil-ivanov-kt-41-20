using daniil_ivanov_kt_41_20.Database.Helpers;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_ivanov_kt_41_20.Database.Configurations;

public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
{
    private const string TableName = "cd_workloads";
    
    public void Configure(EntityTypeBuilder<Workload> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName($"pk_{TableName}_workload_id");
        
        builder.Property(e => e.Hours)
            .IsRequired()
            .HasColumnType(ColumnType.Int)
            .HasColumnName("n_hours")
            .HasComment("Кол-во часов");
        
        builder.ToTable(TableName)
            .HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .HasConstraintName("fk_f_department_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.DepartmentId, $"idx_{TableName}_fk_f_department_id");

        builder.Navigation(e => e.Department)
            .AutoInclude();
        
        builder.ToTable(TableName)
            .HasOne(e => e.Teacher)
            .WithMany()
            .HasForeignKey(e => e.TeacherId)
            .HasConstraintName("fk_f_teacher_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.TeacherId, $"idx_{TableName}_fk_f_teacher_id");

        builder.Navigation(e => e.Teacher)
            .AutoInclude();
        
        builder.ToTable(TableName)
            .HasOne(e => e.Subject)
            .WithMany()
            .HasForeignKey(e => e.SubjectId)
            .HasConstraintName("fk_f_subject_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.SubjectId, $"idx_{TableName}_fk_f_subject_id");

        builder.Navigation(e => e.Subject)
            .AutoInclude();
    }
}