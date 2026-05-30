export interface LoginRequest {
    NombreUsuario: string;
    Password: string;
};


export interface LoginResponse {
    token: string;
}