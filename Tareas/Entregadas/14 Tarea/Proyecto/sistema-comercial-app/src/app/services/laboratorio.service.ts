import { Injectable } from '@angular/core';
import { Material } from '../models/material';
import { Publicacion, Revista } from '../models/publicacion';

interface Autor {
  nombre: string;
  edad: number;
  activo: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class LaboratorioService {
  titulo: string = 'Cien años de soledad';
  anioPublicacion: number = 1967;
  disponible: boolean = true;
  generos: string[] = ['Realismo mágico', 'Novela', 'Drama'];

  autor: Autor = {
    nombre: 'Gabriel García Márquez',
    edad: 87,
    activo: false
  };

  datoVariable: string | number | boolean = 'Biblioteca central';

  libro: Publicacion = new Publicacion(
    'TypeScript desde cero',
    'Programación',
    120
  );

  revista: Revista = new Revista('Tech Hoy', 'Tecnología', 45, 12);

  materiales: Material[] = [
    {
      nombre: 'Lápiz',
      codigo: 'MAT-001',
      stock: 50,
      ubicacion: 'Estante A'
    },
    {
      nombre: 'Cuaderno',
      codigo: 'MAT-002',
      stock: 30,
      ubicacion: 'Estante B'
    },
    {
      nombre: 'Marcador',
      codigo: 'MAT-003',
      stock: 20
    }, 
    {
      nombre: 'Folder',
      codigo: 'MAT-004',
      stock: 10, 
      ubicacion: 'Estante C'
    }
  ];

  formatearTitulo(
    tituloLibro: string,
    subtitulo?: string,
    estilo: 'simple' | 'completo' = 'completo'
  ): string {
    if (estilo === 'simple') {
      return tituloLibro;
    }

    if (subtitulo) {
      return `${tituloLibro}: ${subtitulo}`;
    }

    return tituloLibro;
  }

  mostrarMaterial(material: Material): string {
    return `Nombre: ${material.nombre} | Código: ${material.codigo} | Stock: ${material.stock} | Ubicación: ${material.ubicacion ?? 'No registrada'}`;
  }
}
