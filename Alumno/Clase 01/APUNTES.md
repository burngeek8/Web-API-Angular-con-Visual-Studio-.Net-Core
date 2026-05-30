Crea un nuevo proyecto ASP.NET Core Web API llamado `WebApiConCommandoControlador` y configura la plantilla para usar controladores.
`dotnet new webapi -n WebApiConCommandoControlador --use-controllers`

Compila el proyecto actual para verificar que el código no tenga errores de compilación.
`dotnet build`

Ejecuta el proyecto actual para levantar la aplicación.
`dotnet run`

Publica el proyecto en modo Release directamente en la carpeta `D:\desarrollo\Clase\Publicacion\WeatherForecastAPI`.
`dotnet publish -c Release -o D:\desarrollo\Clase\Publicacion\WeatherForecastAPI`

La ruta de publicación también puede quedar guardada en el archivo `.csproj` usando la propiedad `PublishDir`.
`<PublishDir>D:\desarrollo\Clase\Publicacion\WeatherForecastAPI\</PublishDir>`
