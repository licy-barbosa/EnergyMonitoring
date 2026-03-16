import { Observable } from 'rxjs';
import { Reading } from '../models/reading.model';

export abstract class ReadingRepository {
  abstract getAll(): Observable<Reading[]>;
}