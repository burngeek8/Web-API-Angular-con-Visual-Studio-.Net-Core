# SistemaComercialApp

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.2.11.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Azure Static Web Apps

To deploy the compiled Angular app to Azure Static Web Apps, first generate the build:

```bash
ng build
```

Then run the deployment command from the project root:

```powershell
swa deploy .\dist\sistema-comercial-app\browser --env production --app-name siscomstatic --resource-group siscom --deployment-token "5e9a5d517d0b1439cb68697b776908f4f9775cda67e6020bf4f0f0cfcdde60df07-699877a5-b6de-4fce-aba6-4d1c9d4ede9301e093100af6e51e" --verbose=silly
```

Notes:

- Run the command from the project root, not from inside `dist\...\browser`.
- Keep `public\staticwebapp.config.json` in the project so Angular routes can reload correctly in Azure Static Web Apps.
- If a deployment token is exposed, rotate it from Azure before using it again.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.
