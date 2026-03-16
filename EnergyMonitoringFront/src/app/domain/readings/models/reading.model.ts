export interface Reading {
  id: string;
  timestamp: Date;
  energyKwh: number;
  power?: number | null;
}