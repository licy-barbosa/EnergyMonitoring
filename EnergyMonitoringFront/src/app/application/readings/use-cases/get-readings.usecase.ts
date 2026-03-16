import { inject, Injectable } from '@angular/core';
import { ReadingRepository } from 'src/app/domain/readings/repositories/reading.repository';

@Injectable({ providedIn: 'root' })
export class GetReadingsUseCase {
  private repo = inject(ReadingRepository);

  execute() {
    return this.repo.getAll();
  }
}