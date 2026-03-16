export interface ReadingDto {
  id: string;
  timestamp: string;
  energyKwh: number;
  power?: number | null;
}