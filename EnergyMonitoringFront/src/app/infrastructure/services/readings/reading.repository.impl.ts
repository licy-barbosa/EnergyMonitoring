import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { ENVIRONMENT } from "@core/config";
import { map, Observable } from "rxjs";
import { ReadingDto } from "src/app/domain/readings/dtos/reading.dto";
import { mapReadingDtoToModel } from "src/app/domain/readings/mappers/reading.mapper";
import { Reading } from "src/app/domain/readings/models/reading.model";
import { ReadingRepository } from "src/app/domain/readings/repositories/reading.repository";

@Injectable({ providedIn: 'root' })
export class ReadingRepositoryImpl implements ReadingRepository {

  private http = inject(HttpClient);
  private env = inject(ENVIRONMENT);

  getAll(): Observable<Reading[]> {
    return this.http
      .get<ReadingDto[]>(`${this.env.apiUrl}/readings`)
      .pipe(map(dtos => dtos.map(mapReadingDtoToModel)));
  }
}