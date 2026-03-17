using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired()
                .HasComment("Nombre del dispositivo");

            builder.Property(e => e.Description)
                .HasMaxLength(300)
                .HasComment("Descripción");

            builder.Property(e => e.RatedPowerWatts)
                .HasComment("Potencia nominal");

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

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

            builder.HasOne(e => e.SolarPlant)
                .WithMany(sp => sp.Devices)
                .HasForeignKey(e => e.SolarPlantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Company>()
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}