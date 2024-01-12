using daniil_ivanov_kt_41_20.Database.Helpers;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_ivanov_kt_41_20.Database.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    private const string TableName = "cs_subjects";
    
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName($"pk_{TableName}_subject_id");
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(50)
            .HasColumnName("c_name")
            .HasComment("Название дисциплины");
        
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
    }
}