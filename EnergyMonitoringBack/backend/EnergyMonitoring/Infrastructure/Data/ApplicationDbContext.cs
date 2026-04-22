using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Domain.Common;
using EnergyMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Merkcon.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly ICurrentUserService _currentUser;

        public Guid CurrentCompanyId => _currentUser.CompanyId ?? Guid.Empty;

        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        ICurrentUserService currentUser) : base(options)
        {
            _currentUser = currentUser;
        }

        // =============================
        // Solar System
        // =============================
        public DbSet<SolarPlant> SolarPlants => Set<SolarPlant>();
        public DbSet<SolarPanel> SolarPanels => Set<SolarPanel>();
        public DbSet<Inverter> Inverters => Set<Inverter>();

        // =============================
        // Devices
        // =============================
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<DeviceType> DeviceTypes => Set<DeviceType>();
        public DbSet<DeviceMeasurement> DeviceMeasurements => Set<DeviceMeasurement>();

        // =============================
        // Energy
        // =============================
        public DbSet<EnergyReading> EnergyReadings => Set<EnergyReading>();
        public DbSet<EnergyBalance> EnergyBalances => Set<EnergyBalance>();

        public override async Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            var userId = _currentUser.UserId ?? "system";

            var entries = ChangeTracker
                .Entries<AuditableEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.SetCreated(userId);
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.SetUpdated(userId);
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ICompanyEntity).IsAssignableFrom(entityType.ClrType))
                {
                    builder.Entity(entityType.ClrType)
                        .HasQueryFilter(CreateCompanyFilterExpression(entityType.ClrType));
                }
            }

            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }

        private LambdaExpression CreateCompanyFilterExpression(Type entityType)
        {
            var parameter = Expression.Parameter(entityType, "e");

            var property = Expression.Property(parameter, nameof(ICompanyEntity.CompanyId));

            var companyId = Expression.Property(
                Expression.Constant(this),
                nameof(CurrentCompanyId)
            );

            var body = Expression.Equal(property, companyId);

            return Expression.Lambda(body, parameter);

        }
    }
}