export interface LoginEmpleadoRequest {
  CorreoEmpresarial: string;
  Clave: string;
}

export interface LoginEmpleadoResponse {
  token: string;
}
