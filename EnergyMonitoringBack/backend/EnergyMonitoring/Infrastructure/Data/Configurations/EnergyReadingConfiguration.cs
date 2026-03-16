using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class EnergyReadingConfiguration : IEntityTypeConfiguration<EnergyReading>
    {
        public void Configure(EntityTypeBuilder<EnergyReading> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.GeneratedKWh)
                .HasColumnType("decimal(18,3)")
                .HasComment("Energía generada");

            builder.Property(e => e.ConsumedKWh)
                .HasColumnType("decimal(18,3)")
                .HasComment("Energía consumida");

            builder.Property(e => e.ExportKWh)
                .HasColumnType("decimal(18,3)")
                .HasComment("Energía exportada");

            builder.Property(e => e.ImportKWh)
                .HasColumnType("decimal(18,3)")
                .HasComment("Energía importada");

            builder.Property(e => e.Timestamp)
                .HasComment("Fecha de la lectura");

            // 🔹 Índice para analytics
            builder.HasIndex(e => e.Timestamp);

            // 🔹 Relación correcta con SolarPlant
            builder.HasOne(e => e.SolarPlant)
                .WithMany(p => p.EnergyReadings)
                .HasForeignKey(e => e.SolarPlantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.RecordedByUser)
                .WithMany()
                .HasForeignKey(e => e.RecordedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
