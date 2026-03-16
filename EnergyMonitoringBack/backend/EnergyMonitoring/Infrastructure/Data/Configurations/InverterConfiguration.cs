using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class InverterConfiguration : IEntityTypeConfiguration<Inverter>
    {
        public void Configure(EntityTypeBuilder<Inverter> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Brand)
                .HasMaxLength(100);

            builder.Property(e => e.Model)
                .HasMaxLength(150);

            builder.Property(e => e.Platform)
                .HasMaxLength(200)
                .HasComment("Plataforma de monitoreo");

            builder.Property(e => e.InstallationDate)
                .IsRequired();

            // 🔥 Relación correcta con SolarPlant
            builder.HasOne(e => e.SolarPlant)
                .WithMany(p => p.Inverters)
                .HasForeignKey(e => e.SolarPlantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
