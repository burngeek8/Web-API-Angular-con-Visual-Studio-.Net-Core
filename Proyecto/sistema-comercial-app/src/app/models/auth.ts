export interface LoginEmpleadoRequest {
  CorreoEmpresarial: string;
  Clave: string;
}

export interface LoginEmpleadoResponse {
  accessToken: string;
}
