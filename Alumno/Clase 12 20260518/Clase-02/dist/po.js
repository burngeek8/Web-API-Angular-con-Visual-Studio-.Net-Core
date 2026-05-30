"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const nombre = "Fernando";
const edad = 30;
const esDesarrollador = true;
const hobbies = ["Programar", "Viajar", "Jugar fútbol"];
const persona = {
    nombre: "Julio",
    edad: 20,
    esDesarrollador: true
};
let mix = "Hola";
mix = false;
mix = 42;
//console.log(nombre, edad, esDesarrollador, hobbies, persona, mix);
function formatearNombre(nombre, apellido, formato = "completo") {
    if (formato === "corto") {
        return `${nombre[0]}.${apellido}`;
    }
    return `${nombre}.${apellido}`;
}
// console.log(formatearNombre("Fernando", "García"));
// console.log(formatearNombre("Fernando", "García", "corto"));
class Empleado {
    nombre;
    salario;
    cargo;
    constructor(nombre, salario, cargo) {
        this.nombre = nombre;
        this.salario = salario;
        this.cargo = cargo;
    }
    calcularSueldo(bono = 0) {
        return this.salario + bono;
    }
}
const empleado = new Empleado("Ana", 50000, "Desarrolladora");
// console.log(empleado.calcularSueldo());
// console.log(empleado.calcularSueldo(5000));
class Vehiculo {
    marca;
    modelo;
    constructor(marca, modelo) {
        this.marca = marca;
        this.modelo = modelo;
    }
    mostrarInfo() {
        return `Marca: ${this.marca}, Modelo: ${this.modelo}`;
    }
}
class Camion extends Vehiculo {
    capacidadCarga;
    constructor(marca, modelo, capacidadCarga) {
        super(marca, modelo);
        this.capacidadCarga = capacidadCarga;
    }
    mostrarInfo() {
        return `${super.mostrarInfo()}, Capacidad de Carga: ${this.capacidadCarga} kg`;
    }
}
const camion = new Camion("Volvo", "FH16", 25000);
function mostrarProducto(producto) {
    console.log(`Producto: ${producto.nombre}, Precio: $${producto.precio}, Stock: ${producto.stock}, Categoria: ${producto.categoria ?? "No especificada"}`);
}
const productos = [
    { nombre: "Laptop", precio: 1200, stock: 10, categoria: "Electrónica" },
    { nombre: "Teléfono", precio: 800, stock: 20 },
    { nombre: "Tablet", precio: 600, stock: 15, categoria: "Electrónica" }
];
productos.forEach(mostrarProducto);
//# sourceMappingURL=po.js.map