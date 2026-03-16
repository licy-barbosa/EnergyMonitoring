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

            builder.Property(e => e.Timestamp)
                .HasComment("Fecha de medición");

            builder.HasOne(e => e.Device)
                .WithMany(d => d.Measurements)
                .HasForeignKey(e => e.DeviceId);
        }
    }
}
