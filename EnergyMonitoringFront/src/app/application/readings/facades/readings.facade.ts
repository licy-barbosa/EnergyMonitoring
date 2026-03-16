import { inject, Injectable } from "@angular/core";
import { GetReadingsUseCase } from "../use-cases/get-readings.usecase";

@Injectable({ providedIn: 'root' })
export class ReadingsFacade {

  private getReadings = inject(GetReadingsUseCase);

  load() {
    return this.getReadings.execute();
  }
}