import { ReadingDto } from '../dtos/reading.dto';
import { Reading } from '../models/reading.model';

export const mapReadingDtoToModel = (dto: ReadingDto): Reading => ({
  id: dto.id,
  timestamp: new Date(dto.timestamp),
  energyKwh: dto.energyKwh,
  power: dto.power ?? null
});