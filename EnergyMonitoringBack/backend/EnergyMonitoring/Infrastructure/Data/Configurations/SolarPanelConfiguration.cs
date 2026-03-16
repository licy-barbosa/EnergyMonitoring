using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class SolarPanelConfiguration : IEntityTypeConfiguration<SolarPanel>
    {
        public void Configure(EntityTypeBuilder<SolarPanel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Brand)
                .HasMaxLength(100)
                .HasComment("Marca del panel");

            builder.Property(e => e.Model)
                .HasMaxLength(150)
                .HasComment("Modelo");

            builder.Property(e => e.PowerWatts)
                .IsRequired()
                .HasComment("Potencia nominal en watts");

            builder.Property(e => e.Quantity)
                .IsRequired()
                .HasComment("Cantidad de paneles del mismo modelo");

            builder.HasOne(e => e.SolarPlant)
                .WithMany(p => p.Panels)
                .HasForeignKey(e => e.SolarPlantId)
                .OnDelete(DeleteBehavior.Cascade);

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
        }
    }
}
