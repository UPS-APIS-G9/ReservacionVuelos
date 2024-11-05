## PROYECTO FINAL DE LA MATERIA PATRONES DE DISEÑO DE SOFTWARE
### Integrantes:
- Ricardo Tipán
- Wilmer Caiza
- Guido Guerrero

### 1. Patrones implementados
- Singleton
- Builder
- Chain of responsability

### 2. Bloques pequeños de código mostrando evidencia de uso de principios SOLID
- Single Responsibility Principle
- Open-Closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle  
`
BuilderService builderService = new();
AsientoService asientoService = new(builderService);  
ResumenService resumenService = new();  
var emailHandler = new CorreoHandler(resumenService);  
var mostrarReservasHandler = new MostrarReservasHandler(asientoService);  
var seleccionAsientoHandler = new SeleccionAsientoHandler(builderService, asientoService);  
`
- Dependency Inversion Principle


### 3. Cómo ejecutar el código en ambiente local
1. Para ejecutar el aplicativo, es necesario tener instalado VS 2022, en cualquiera de sus distribuciones (Community, Proffesional, Enterprise).
2. Localizar la ubicación del archivo "ReservacionVuelos.sln" y abrirlo con Visual Studio.
3. Una vez cargado el proyecto y sus dependencias (las dependencias se descargarán automáticamente), presionar F5 en el teclado o click en el botón "ReservacionVuelos".
4. Los cambios en el archivo seat-selection.txt son permanentes y no desaparecerán en cada ejecución.
5. La ruta donde visualizar el archivo seat-selection.txt es: `{ruta archivo ReservacionVuelos.sln}\ReservacionVuelos\bin\Debug\net8.0\Files\`
