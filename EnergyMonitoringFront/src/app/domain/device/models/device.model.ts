export interface Device {
    id: string;
    name: string;
    description: string;
    ratedPowerWatts: number;
    isActive: boolean;
    solarPlantId: string;
    deviceTypeId: number ;
}