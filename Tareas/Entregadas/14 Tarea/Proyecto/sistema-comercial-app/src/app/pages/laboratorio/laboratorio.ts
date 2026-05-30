import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { NavbarComponent } from '../../components/navbar/navbar';
import { LaboratorioService } from '../../services/laboratorio.service';

@Component({
  selector: 'app-laboratorio',
  imports: [CommonModule, NavbarComponent],
  templateUrl: './laboratorio.html',
  styleUrl: './laboratorio.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LaboratorioComponent {
  private demoService = inject(LaboratorioService);

  titulo = this.demoService.titulo;
  anioPublicacion = this.demoService.anioPublicacion;
  disponible = this.demoService.disponible;
  generos = this.demoService.generos;
  autor = this.demoService.autor;
  datoVariable = this.demoService.datoVariable;
  libro = this.demoService.libro;
  revista = this.demoService.revista;
  materiales = this.demoService.materiales;

  tituloCompleto = this.demoService.formatearTitulo(
    this.titulo,
    'Una historia inolvidable'
  );

  tituloSimple = this.demoService.formatearTitulo(
    this.titulo,
    'Una historia inolvidable',
    'simple'
  );

  mostrarMaterial(index: number): string {
    return this.demoService.mostrarMaterial(this.materiales[index]);
  }
}
