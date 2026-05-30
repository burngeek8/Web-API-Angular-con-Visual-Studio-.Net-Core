export interface Empleado {
  id: string;
  nombres: string;
  apellidoPaterno: string;
  apellidoMaterno?: string | null;
  numeroDocumento: string;
  tipoDocumento: string;
  correoEmpresarial: string;
  salarioMonto: number;
  salarioMoneda: string;
  codigoEmpleado: string;
  fechaIngreso: string;
  estado: string;
  nombreCargo: string;
}
