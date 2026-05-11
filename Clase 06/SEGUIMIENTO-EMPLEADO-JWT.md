# Seguimiento Clase 06 - Empleado JWT

## Lo que se hizo hoy

Se avanzó solo el controller de `Empleado` en:

- `Clase 06/Empleado/Empleado.Api/Controllers/EmpleadoController.cs`

Cambios aplicados:

1. Se reemplazó el controller MVC vacio por un API controller real.
2. Se agregaron endpoints:
   - `POST /api/empleados`
   - `PUT /api/empleados/{id}`
   - `GET /api/empleados/{id}`
   - `GET /api/empleados`
3. Se incorporó regla de bootstrap para primera creacion:
   - Si no hay empleados, permite crear sin autenticacion.
   - En ese primer registro exige `NombreCargo = "Gerente General"`.
4. Para creaciones posteriores:
   - Si no esta autenticado, `POST` responde `401 Unauthorized`.
5. `PUT` y `GET` quedaron con `[Authorize]` (listos para JWT).

## Verificacion hecha

Se ejecutó compilacion del API:

- `dotnet build Clase 06/Empleado/Empleado.Api/Empleado.Api.csproj`

Resultado: compila sin errores.

## Estado actual

El controller ya contempla la logica inicial solicitada, pero todavia falta completar la infraestructura de autenticacion JWT y el flujo de login.

## Hacia donde vamos (proxima sesion)

Orden de trabajo recomendado:

1. JWT base en infraestructura y API
   - `JwtOptions`
   - `IJwtTokenGenerator` (Aplicacion)
   - `JwtTokenGenerator` (Infrastructure)
   - Configurar `AddAuthentication().AddJwtBearer(...)`
   - Agregar seccion `Jwt` en `appsettings.json`
   - Activar `UseAuthentication()` en `Program.cs`

2. Login de empleado
   - Definir command/handler de login en Aplicacion.
   - Buscar empleado por correo empresarial.
   - Validar clave.
   - Generar token con claims.

3. Modelo de credencial
   - Agregar campo de clave en `Empleado` (ideal: hash, no texto plano).
   - Configuracion EF y migracion.

4. Regla de cargo en primera creacion
   - Resolver en capa de aplicacion el caso:
     - "si no existe cargo, crearlo primero"
   - Mantener la regla de bootstrap coherente con transaccion.

## Nota para exposicion

Mensaje corto para explicar en clase:

"Hoy dejamos el API de Empleado listo con endpoints reales y una regla de bootstrap para crear el primer empleado sin token, forzando cargo de Gerente General. Manana seguimos con JWT completo (configuracion, login y validacion de credenciales)."

