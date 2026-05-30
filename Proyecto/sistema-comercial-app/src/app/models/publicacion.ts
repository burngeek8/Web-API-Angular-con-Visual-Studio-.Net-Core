export class Publicacion {
  constructor(
    public titulo: string,
    public categoria: string,
    public paginas: number
  ) {}

  calcularLectura(minutosExtra: number = 0): number {
    const minutosBase = this.paginas * 2;
    return minutosBase + minutosExtra;
  }

  describir(): string {
    return `Publicacion: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas}`;
  }
}

export class Revista extends Publicacion {
  constructor(
    titulo: string,
    categoria: string,
    paginas: number,
    public numeroEdicion: number
  ) {
    super(titulo, categoria, paginas);
  }

  override describir(): string {
    return `Revista: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas} | Edicion: ${this.numeroEdicion}`;
  }
}
