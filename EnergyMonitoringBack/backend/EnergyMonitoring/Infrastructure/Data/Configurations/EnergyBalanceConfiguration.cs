using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Merkcon.Infrastructure.Data.Configurations
{
    public class EnergyBalanceConfiguration : IEntityTypeConfiguration<EnergyBalance>
    {
        public void Configure(EntityTypeBuilder<EnergyBalance> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TotalGeneratedKWh)
                .HasComment("Total generado");

            builder.Property(e => e.TotalConsumedKWh)
                .HasComment("Total consumido");

            builder.Property(e => e.NetBalanceKWh)
                .HasComment("Balance neto");

            builder.Property(e => e.PeriodStart)
                .HasComment("Inicio periodo");

            builder.Property(e => e.PeriodEnd)
                .HasComment("Fin periodo");

            builder.HasOne(e => e.SolarPlant)
                .WithMany()
                .HasForeignKey(e => e.SolarPlantId);
        }
    }
}
