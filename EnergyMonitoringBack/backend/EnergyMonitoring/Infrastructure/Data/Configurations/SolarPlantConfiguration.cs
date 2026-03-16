using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class SolarPlantConfiguration : IEntityTypeConfiguration<SolarPlant>
    {
        public void Configure(EntityTypeBuilder<SolarPlant> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired()
                .HasComment("Nombre de la planta solar");

            builder.Property(e => e.Location)
                .HasMaxLength(200)
                .HasComment("Ubicación");

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.HasOne(p => p.Company)
                .WithMany(c => c.SolarPlants)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.InstallationDate)
                .IsRequired()
                .HasComment("Fecha de instalación del sistema");

            builder.Property(e => e.CreatedAt)
                .IsRequired()
                .HasComment("Fecha de creación del registro");

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(450)
                .IsRequired()
                .HasComment("Usuario que creó el registro");

            builder.Property(e => e.UpdatedAt)
                .HasComment("Fecha de última modificación");

            builder.Property(e => e.UpdatedBy)
                .HasMaxLength(450)
                .HasComment("Usuario que modificó el registro");

            builder.HasMany(e => e.Panels)
                .WithOne(p => p.SolarPlant)
                .HasForeignKey(p => p.SolarPlantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}