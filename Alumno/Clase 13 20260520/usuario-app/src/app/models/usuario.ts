export interface Usuario {
  id: string;
  nombresPersona: string;
  apellidoPaterno: string;
  apellidoMaterno?: string;
  password?: string;
  fechaNacimiento: Date;
  correoElectronico?: string;
  pais: string;
  departamento: string;
  provincia: string;
  distrito: string;
  calle: string;
  nombreRol: string;
  fechaUltimoCambio: Date;
  estado: string;
}