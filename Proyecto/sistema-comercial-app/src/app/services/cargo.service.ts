import { inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Cargo } from '../models/cargo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {
  private http = inject(HttpClient);
  private apiUrl =
    'https://siscom-chd6bkbjfugxdpam.westcentralus-01.azurewebsites.net/api/cargos';

  listar(q?: string) {
    let params = new HttpParams();

    if (q?.trim()) {
      params = params.set('q', q.trim());
    }

    return this.http
      .get<{ value: Cargo[] }>(this.apiUrl, { params })
      .pipe(map((response) => response.value));
  }
}
