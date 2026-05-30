import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Cargo } from '../models/cargo';

@Injectable({
  providedIn: 'root'
})
export class CargoService {
  private http = inject(HttpClient);
  private apiUrl =
    'https://siscom-chd6bkbjfugxdpam.westcentralus-01.azurewebsites.net/api/cargos';

  listar() {
    return this.http.get<Cargo[]>(this.apiUrl);
  }
}
