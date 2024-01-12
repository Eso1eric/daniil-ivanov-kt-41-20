using daniil_ivanov_kt_41_20.Database.Helpers;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_ivanov_kt_41_20.Database.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    private const string TableName = "cs_departments";
    
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName($"pk_{TableName}_department_id");
        
        builder.Property(e => e.ShortName)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(10)
            .HasColumnName("c_shortname")
            .HasComment("Краткое наименование");
        
        builder.Property(e => e.FullName)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasColumnName("c_fullname")
            .HasComment("Полное наименование");
        
        builder.Property(e => e.CreateDate)
            .IsRequired()
            .HasColumnType(ColumnType.Date)
            .HasColumnName("d_createdate")
            .HasComment("Дата основания");
        
        builder.ToTable(TableName)
            .HasOne(e => e.HeadTeacher)
            .WithMany()
            .HasForeignKey(e => e.HeadTeacherId)
            .HasConstraintName("fk_f_headteacher_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(TableName)
            .HasIndex(e => e.HeadTeacherId, $"idx_{TableName}_fk_f_headteacher_id");

        builder.Navigation(e => e.HeadTeacher)
            .AutoInclude();
    }
}