"use strict";
function main() {
    // 1) Variables tipadas de la publicacion
    const titulo = "Cien años de soledad";
    const anioPublicacion = 1967;
    const disponible = true;
    const generos = ["Realismo magico", "Novela", "Drama"];
    // console.log("=== 1) VARIABLES TIPADAS ===");
    // console.log(`Titulo: ${titulo}`);
    // console.log(`Anio de publicacion: ${anioPublicacion}`);
    // console.log(`Disponible: ${disponible}`);
    // console.log(`Generos: ${generos.join(", ")}`);
    // return; 
    // 2) Objeto con datos del autor
    const autor = {
        nombre: "Gabriel Garcia Marquez",
        edad: 87,
        activo: false,
    };
    // console.log("=== 2) OBJETO AUTOR ===");
    // console.log(
    //   `Autor: ${autor.nombre} | Edad: ${autor.edad} | Activo: ${autor.activo}`
    // );
    // return; 
    // 3) Variable con tipo union
    let datoVariable = "Biblioteca central";
    // console.log("=== 3) TIPO UNION ===");
    // console.log("Valor 1:", datoVariable);
    // datoVariable = 25;
    // console.log("Valor 2:", datoVariable);
    // datoVariable = true;
    // console.log("Valor 3:", datoVariable);
    // return; 
    // 4) Funcion con parametro opcional y valor por defecto
    function formatearTitulo(tituloLibro, subtitulo, estilo = "completo") {
        if (estilo === "simple") {
            return tituloLibro;
        }
        if (subtitulo) {
            return `${tituloLibro}: ${subtitulo}`;
        }
        return tituloLibro;
    }
    // console.log("=== 4) PRUEBAS DE formatearTitulo ===");
    // console.log(formatearTitulo(titulo, "Una historia inolvidable"));
    // console.log(formatearTitulo(titulo,  "Una historia inolvidable", "simple"));
    // console.log(formatearTitulo(titulo));
    // return; 
    // 5) Clase base de una publicacion
    class Publicacion {
        constructor(titulo, categoria, paginas) {
            this.titulo = titulo;
            this.categoria = categoria;
            this.paginas = paginas;
        }
        calcularLectura(minutosExtra = 0) {
            const minutosBase = this.paginas * 2;
            return minutosBase + minutosExtra;
        }
        describir() {
            return `Publicacion: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas}`;
        }
    }
    const libro = new Publicacion("TypeScript desde cero", "Programacion", 120);
    // console.log("=== 5) PRUEBAS DE Publicacion ===");
    // console.log(libro.describir());
    // console.log(`Tiempo de lectura con extra: ${libro.calcularLectura(10)} minutos`);
    // console.log(`Tiempo de lectura sin extra: ${libro.calcularLectura()} minutos`);
    // return; 
    // 6) Clase hija que hereda de Publicacion
    class Revista extends Publicacion {
        constructor(titulo, categoria, paginas, numeroEdicion) {
            super(titulo, categoria, paginas);
            this.numeroEdicion = numeroEdicion;
        }
        describir() {
            return `Revista: ${this.titulo} | Categoria: ${this.categoria} | Paginas: ${this.paginas} | Edicion: ${this.numeroEdicion}`;
        }
    }
    const revista = new Revista("Tech Hoy", "Tecnologia", 45, 12);
    // 8) Arreglo de materiales
    const materiales = [
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
    // console.log("=== 8) ARREGLO DE MATERIALES ===");
    // console.log(materiales);
    // return;
    // 9) Funcion para mostrar cada material
    function mostrarMaterial(material) {
        console.log(`Nombre: ${material.nombre} | Codigo: ${material.codigo} | Stock: ${material.stock} | Ubicacion: ${material.ubicacion ?? "No registrada"}`);
    }
    console.log("=== 9) PRUEBA DE mostrarMaterial ===");
    mostrarMaterial(materiales[0]);
    // 10) Recorrido del arreglo con forEach
    console.log("=== 10) RECORRIDO CON forEach ===");
    materiales.forEach((material) => mostrarMaterial(material));
}
main();
//# sourceMappingURL=laboratorio.js.map