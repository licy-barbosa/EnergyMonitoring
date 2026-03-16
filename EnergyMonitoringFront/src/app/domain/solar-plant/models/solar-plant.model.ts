import { SolarPanel } from "@domain/solar-panel/models/solar-panel.model";

export interface SolarPlant {
    id: string;  
    name: string;   
    installationDate: string; 
    totalPowerKw: number; 
    isActive: boolean;  
    panels?: SolarPanel[]; 
    location: string; 
}