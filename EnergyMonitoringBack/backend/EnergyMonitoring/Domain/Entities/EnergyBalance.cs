namespace EnergyMonitoring.Domain.Entities
{
        /// <summary>
        /// Represents aggregated energy balance.
        /// Representa el balance energético de un periodo.
        /// </summary>
        public class EnergyBalance
        {
            /// <summary>
            /// Unique identifier.
            /// Identificador único.
            /// </summary>
            public Guid Id { get; set; }

            /// <summary>
            /// Solar plant reference.
            /// Planta solar asociada.
            /// </summary>
            public Guid SolarPlantId { get; set; }

            /// <summary>
            /// Total generated energy.
            /// Total de energía generada.
            /// </summary>
            public decimal TotalGeneratedKWh { get; set; }

            /// <summary>
            /// Total consumed energy.
            /// Total de energía consumida.
            /// </summary>
            public decimal TotalConsumedKWh { get; set; }

            /// <summary>
            /// Net energy balance.
            /// Balance neto de energía.
            /// </summary>
            public decimal NetBalanceKWh { get; set; }

            /// <summary>
            /// Period start date.
            /// Inicio del periodo.
            /// </summary>
            public DateTime PeriodStart { get; set; }

            /// <summary>
            /// Period end date.
            /// Fin del periodo.
            /// </summary>
            public DateTime PeriodEnd { get; set; }

            public SolarPlant SolarPlant { get; set; } = default!;
        }
    }
