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

            builder.Property(e => e.Location)
                .HasMaxLength(150);

            builder.Property(e => e.RatedPowerWatts)
                .HasComment("Potencia nominal");

            builder.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
