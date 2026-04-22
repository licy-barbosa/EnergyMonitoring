export interface CreateDeviceType {
  name: string;
  minVoltage: number;
  maxVoltage: number;
  minCurrent: number;
  maxCurrent: number;
  minPowerWatts: number;
  maxPowerWatts: number;
}