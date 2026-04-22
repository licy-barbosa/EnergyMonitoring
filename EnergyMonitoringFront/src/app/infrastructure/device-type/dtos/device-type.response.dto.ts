export interface DeviceTypeDto {
    id: number;
    name: string;
    minVoltage: number;
    maxVoltage: number;
    minCurrent: number;
    maxCurrent: number;
    minPowerWatts: number;
    maxPowerWatts: number;
}