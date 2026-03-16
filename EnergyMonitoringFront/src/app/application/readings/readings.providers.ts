import { ReadingRepository } from "src/app/domain/readings/repositories/reading.repository";
import { ReadingRepositoryImpl } from "src/app/infrastructure/services/readings/reading.repository.impl";


export const provideReadingsFeature = () => [
  {
    provide: ReadingRepository,
    useClass: ReadingRepositoryImpl
  }
];