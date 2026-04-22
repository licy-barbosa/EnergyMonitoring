using EnergyMonitoring.Application.Common.Interfaces;
using EnergyMonitoring.Application.Common.Services;
using EnergyMonitoring.Application.Interfaces;
using EnergyMonitoring.Infrastructure.Identity;
using EnergyMonitoring.Infrastructure.Services;

namespace EnergyMonitoring.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IDeviceMeasurementService, DeviceMeasurementService>();
            services.AddScoped<IEnergyAnalyticsService, EnergyAnalyticsService>();
            services.AddScoped<ICostCalculationService, CostCalculationService>();
            services.AddScoped<ISolarPlantService, SolarPlantService>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IDeviceTypeService, DeviceTypeService>();

            return services;
        }
    }
}