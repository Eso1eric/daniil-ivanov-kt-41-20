using daniil_ivanov_kt_41_20.Database.Helpers;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_ivanov_kt_41_20.Database.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    private const string TableName = "cd_teachers";
    
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName($"pk_{TableName}_teacher_id");
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(50)
            .HasColumnName("c_name")
            .HasComment("Имя");
        
        builder.Property(e => e.Surname)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(50)
            .HasColumnName("c_surname")
            .HasComment("Фамилия");
        
        builder.Property(e => e.Lastname)
            .IsRequired(false)
            .HasColumnType(ColumnType.String).HasMaxLength(50)
            .HasColumnName("c_lastname")
            .HasComment("Отчество");
        
        builder.Property(e => e.isHeadTeacher)
            .IsRequired()
            .HasColumnType(ColumnType.Bool)
            .HasColumnName("b_isHeadTeacher")
            .HasComment("Заведующий кафедры");

        builder.ToTable(TableName)
            .HasOne(e => e.Degree)
            .WithMany()
            .HasForeignKey(e => e.DegreeId)
            .HasConstraintName("fk_f_degree_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.DegreeId, $"idx_{TableName}_fk_f_degree_id");

        builder.Navigation(e => e.Degree)
            .AutoInclude();
        
        builder.ToTable(TableName)
            .HasOne(e => e.Position)
            .WithMany()
            .HasForeignKey(e => e.PositionId)
            .HasConstraintName("fk_f_position_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.PositionId, $"idx_{TableName}_fk_f_position_id");

        builder.Navigation(e => e.Position)
            .AutoInclude();
        
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
    }
}