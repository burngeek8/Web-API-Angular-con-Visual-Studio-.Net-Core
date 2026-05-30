import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Usuario } from '../models/usuario';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService {

  private http = inject(HttpClient);
  private apiUrl = 'http://localhost:7777/api/usuario/df47136a-adc4-48be-a1ba-08e8fe4b66f5';
  private token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImQwZDk5NTNkLTlhNmQtNDMwNC05MzQ5LWU0ZmY1MTEyNjI3NCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJ0ZXN0IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiRG9jZW50ZSIsImV4cCI6MTc3OTMyOTgxNywiaXNzIjoic2VndXJpZGFkLWFwaSIsImF1ZCI6InNlZ3VyaWRhZC1jbGllbnQifQ.GURnnJocVAqcNZsbXGoTtUNarHf4ZwmE_LATfA-pNZg'


  obtenerUsuarios(): Observable<Usuario[]> { 
    const headers = new HttpHeaders({
        Authorization : `Bearer ${this.token}`
    });
    return this.http.get<Usuario | Usuario[]>(this.apiUrl, { headers })
      .pipe(
        map(res => Array.isArray(res) ? res : [res])
      );
  }

}