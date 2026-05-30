import { inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Empleado } from '../models/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private http = inject(HttpClient);
  private apiUrl =
    'https://siscom-chd6bkbjfugxdpam.westcentralus-01.azurewebsites.net/api/empleados';

  listar() {
    return this.http.get<Empleado[]>(this.apiUrl);
  }
}
