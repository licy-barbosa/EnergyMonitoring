export interface SolarPanel {
    id: string | null;
    solarPlantId : string;
    brand : string;
    model : string;
    powerWatts : number;
    quantity : number;
}

export interface CreateSolarPanel{
    serialNumber: string;
    powerW: number;
}