using SistemaComercial.Aplicacion.Abstractions.Messaging;

namespace SistemaComercial.Aplicacion.Ventas.GetVentaBySerieNumero;

public sealed record GetVentaBySerieNumeroQuery(
    string Serie,
    int Numero) : IQuery<GetVentaBySerieNumeroResponse>;
