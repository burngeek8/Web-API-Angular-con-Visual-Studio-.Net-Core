const nombre : string = "Fernando";
const edad : number = 30;
const esDesarrollador : boolean = true;

const hobbies : string[] = ["Programar", "Viajar", "Jugar fútbol"];

const persona :  { nombre: string; edad: number; esDesarrollador: boolean } = { 
    nombre: "Julio",
    edad: 20,
    esDesarrollador: true
};

let mix : string | number | boolean = "Hola";
mix = false;
mix = 42;

//console.log(nombre, edad, esDesarrollador, hobbies, persona, mix);

function formatearNombre(nombre: string, apellido: string, formato : "completo" | "corto" = "completo"): string {
    if (formato === "corto") {
        return `${nombre[0]}.${apellido}`;
    }

    return `${nombre}.${apellido}`;
}


// console.log(formatearNombre("Fernando", "García"));
// console.log(formatearNombre("Fernando", "García", "corto"));


class Empleado {
    constructor(public nombre: string, public salario: number, public cargo: string) {}

    calcularSueldo(bono : number = 0) : number {
        return this.salario + bono;
    }
}

const empleado = new Empleado("Ana", 50000, "Desarrolladora");

// console.log(empleado.calcularSueldo());
// console.log(empleado.calcularSueldo(5000));

class Vehiculo {
    constructor(public marca: string, public modelo: string) {}

    mostrarInfo() : string {
        return `Marca: ${this.marca}, Modelo: ${this.modelo}`;
    }
}

class Camion extends Vehiculo {
    constructor(marca: string, modelo: string, public capacidadCarga: number) {
        super(marca, modelo);
    }

    override mostrarInfo() : string {
        return `${super.mostrarInfo()}, Capacidad de Carga: ${this.capacidadCarga} kg`;
    }
}

const camion = new Camion("Volvo", "FH16", 25000);
// console.log(camion.mostrarInfo());

interface Producto {
    nombre: string;
    precio: number;
    stock : number;
    categoria?: string; // Propiedad opcional
}

function mostrarProducto(producto: Producto) : void {
    console.log(`Producto: ${producto.nombre}, Precio: $${producto.precio}, Stock: ${producto.stock}, Categoria: ${producto.categoria ?? "No especificada"}`);
}

const productos : Producto[] = [
    { nombre: "Laptop", precio: 1200, stock: 10, categoria: "Electrónica" },
    { nombre: "Teléfono", precio: 800, stock: 20 },
    { nombre: "Tablet", precio: 600, stock: 15, categoria: "Electrónica" }
]

productos.forEach(mostrarProducto);