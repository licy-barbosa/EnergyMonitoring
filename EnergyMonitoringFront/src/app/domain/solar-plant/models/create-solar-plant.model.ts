import { CreateSolarPanel } from "@domain/solar-panel/models/solar-panel.model";

export interface CreateSolarPlant {
  name: string;
  location: string;
  panelCount: number;
  totalPowerKw: number;
  panelPowerW: number;
  createdAt: string;
  isActive: boolean;
  panels?: CreateSolarPanel[];
}