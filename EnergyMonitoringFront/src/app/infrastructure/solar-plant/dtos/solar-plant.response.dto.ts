import { SolarPanel } from "@domain/solar-panel/models/solar-panel.model";

export interface SolarPlantDto {
    id: string;
    name: string;
    location: string;
    installationDate: string;
    totalPowerKw: number;
    //panelCount: number;
    isActive: boolean;
    panels?: SolarPanel[];
}