using daniil_ivanov_kt_41_20.Database.Helpers;
using daniil_ivanov_kt_41_20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace daniil_ivanov_kt_41_20.Database.Configurations;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    private const string TableName = "cs_positions";
    
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName($"pk_{TableName}_position_id");
        
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .HasComment("Идентификатор должности")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnType(ColumnType.String).HasMaxLength(50)
            .HasColumnName("c_name")
            .HasComment("Название должности");
    }
}