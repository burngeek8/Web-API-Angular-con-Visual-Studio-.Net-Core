function main(): void {

// 1) Variables tipadas de la publicacion
const titulo: string = "Cien años de soledad";
const anioPublicacion: number = 1967; 
const disponible: boolean = true;
const generos: string[] = ["Realismo magico", "Novela", "Drama"];


// 2) Objeto con datos del autor
const autor: { nombre: string; edad: number; activo: boolean } = {
  nombre: "Gabriel Garcia Marquez",
  edad: 87,
  activo: false,
};

// 3) Variable con tipo union
let datoVariable: string | number | boolean = "Biblioteca central";
datoVariable = 25;
datoVariable = true;

// 4) Funcion con parametro opcional y valor por defecto
function formatearTitulo(
  tituloLibro: string,
  subtitulo?: string,
  estilo: "simple" | "completo" = "completo"
): string {
  if (estilo === "simple") {
    return tituloLibro;
  }

  if (subtitulo) {
    return `${tituloLibro}: ${subtitulo}`;
  }

  return tituloLibro;
}

// 5) Clase base de una publicacion
class Publicacion {
  titulo: string;
  categoria: string;
  paginas: number;

  constructor(titulo: string, categoria: string, paginas: number) {
    this.titulo = titulo;
    this.categoria = categoria;
    this.paginas = paginas;
  }

  calcularLectura(minutosExtra: number = 0): number {
    const minutosBase = this.paginas * 2;
    return minutosBase + minutosExtra;
  }

  describir(): string {
    return `Publicacion: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas}`;
  }
}

const libro = new Publicacion("TypeScript desde cero", "Programacion", 120);


// 6) Clase hija que hereda de Publicacion
class Revista extends Publicacion {
  numeroEdicion: number;

  constructor(
    titulo: string,
    categoria: string,
    paginas: number,
    numeroEdicion: number
  ) {
    super(titulo, categoria, paginas);
    this.numeroEdicion = numeroEdicion;
  }

  describir(): string {
    return `Revista: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas} | Edicion: ${this.numeroEdicion}`;
  }
}

const revista = new Revista("Tech Hoy", "Tecnologia", 45, 12);

// 7) Interfaz para los materiales de la biblioteca
interface Material {
  nombre: string;
  codigo: string;
  stock: number;
  ubicacion?: string;
}

// 8) Arreglo de materiales
const materiales: Material[] = [
  {
    nombre: "Lapiz",
    codigo: "MAT-001",
    stock: 50,
    ubicacion: "Estante A",
  },
  {
    nombre: "Cuaderno",
    codigo: "MAT-002",
    stock: 30,
    ubicacion: "Estante B",
  },
  {
    nombre: "Marcador",
    codigo: "MAT-003",
    stock: 20,
  },
];

// 9) Funcion para mostrar cada material
function mostrarMaterial(material: Material): string {
  return `Nombre: ${material.nombre} | Codigo: ${material.codigo} | Stock: ${material.stock} | Ubicacion: ${material.ubicacion ?? "No registrada"}`;
}

// 10) Recorrido del arreglo con forEach
const materialesFormateados: string[] = [];
materiales.forEach((material) => {
  materialesFormateados.push(mostrarMaterial(material));
});

}

main();
