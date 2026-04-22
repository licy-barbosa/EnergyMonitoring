using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class DeviceMeasurementConfiguration : IEntityTypeConfiguration<DeviceMeasurement>
    {
        public void Configure(EntityTypeBuilder<DeviceMeasurement> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PowerWatts)
                .HasComment("Potencia en watts");

            builder.Property(e => e.Voltage)
                .HasComment("Voltaje");

            builder.Property(e => e.Current)
                .HasComment("Corriente");

            builder.Property(e => e.EnergyKWh)
                .HasComment("Consumo acumulado");

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

            builder.Property(x => x.Status)
                .HasConversion<int>();

            builder.HasOne(e => e.Device)
                .WithMany(d => d.Measurements)
                .HasForeignKey(e => e.DeviceId);
        }
    }
}
