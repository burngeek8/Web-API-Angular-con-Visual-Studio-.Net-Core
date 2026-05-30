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


  obtenerUsuarios(): Observable<Usuario[]> { 
   
    return this.http.get<Usuario | Usuario[]>(this.apiUrl)
      .pipe(
        map(res => Array.isArray(res) ? res : [res])
      );
  }

}