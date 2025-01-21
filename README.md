Planificación:

Primer hito: Creación de la base de la solución, es decir, la creación de los proyectos involucrados.
Segundo hito: Creación del modelo y la base de datos mediante entityframework. Aqui se creó el motor de persistencia.
Tercer hito: Implementación de los patrones de repositorio y UnitOfWork.
Cuarto hito: Implementación del patron CQRS.
Quinto hito: Creación de los servicios basandonos en la logica creada en la implementación CQRS.
Secto hito: Creación de las pruebas unitarias.

Arquitectura utilizada

Para desarrollar esta API se eligió la Arquitectura DDD, en esta arquitectura el centro del proyecto es el dominio. Partiendo de esta base, el area de conocimiento, las reglas de negocio y su logica se definen con la finalidad de crear, almacenar, modificar y consultar los datos de dicho dominio. En este caso el dominio es unicamente las acciones, como se indicó en los requerimientos de la prueba tecnica.
Para completar la Arquitectura DDD se utilizaron distintos patrones de diseño de software con la finalidad de llevar a cabo una aplicación flexible y escalable, y en caso de que crezca se evita el codigo espaguetti, muy común en desarrollos monoliticos.
Los patrones que se utilizaron fueron:
- Patron de repositorio: Es un patrón de diseño utilizado en el desarrollo de software que proporciona una forma de administrar la lógica de acceso a los datos en una ubicación centralizada. Consiste en la combinación entre interfaces, que indican que debe hacer una acción dada (llamar a un registro por su id) y una clase, la cual contiene el cuerpo necesario para que la acción se lleve a cabo.
- Patron Unit Of Work: Este patron es un orquestador de repositorios.
- Patron CQRS: es un patrón de diseño de software que nos muestra cómo separar la lógica de nuestras aplicaciones para separar las lecturas de las escrituras.

Estos patrones permiten que cada actividad llevada a cabo  por la entidad, en este caso, las acciones, tengan su propia linea de desarrollo sin interferir entre si. Es decir, la creación de una acción, es desarrollada independiente de la actualización de la acción, garantizando asi la separación de logica de negocio. 
La aplicación de estos patrones garantiza una buena practica, que es la de crear servicios (a nivel de los controllers) limpios de cualquier tipo de logica, dejando las reglas de negocios en otras capas.

La solución se dividió en distintos proyectos, los cuales son:

-  La API, contiene los servicios que será consumidos por los clientes.
-  Application y Models, que se encuentran en una carpeta llamada Core. Se llama Core, porque es el centro real de la solución. Application contiene definidas las reglas de negocio, mientras que Models contiene las entidades a utilizar como tal, modelos de las tablas que se encuentran en la base de datos.Esta capa viene siendo la de de servicoos o logicas de negocios.
- Infraestrure. Este proyecto, representa la capa que contiene el motor de persistencia, y contiene la base de la logica utilizada en el proyecto application. Esta capa viene siendo la  de acceso a datos.
- Test. En este proyecto se llevan a cabo las pruebas unitarias para evaluar la logica creada como tal en la capa de servicios. En este caso se toma en cuenta la estructura de archivos y métodos creados basados en el patron de diseño CQRS, utilizado en dicha capa de servicios.

Requisitos

Aunque mucho de los requisitos no funcionales fueron señalados de manera indirecta en el parrafo anterior, se detallarán a continuación:

- Implementación de distintos patrones de diseño con la finalidad de crear una aplicación flexible y escalable. Y un código desacoplado y facil de entender.
- Se desarrolló una aplicación con un manejo detallado de excepciones.
- Se dearrolló una API que devuelve, según sea el tipo de respuesta (200, 400, 401, 404, 500, etc), un formato con 4 propiedades, como por ejemplo:
{
    "success": true,
    "codeResult": "200",
    "message": "Login succesful",
    "data": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJncmVnb3JkdWFydGVtYXJ0aW5lekBnbWFpbC5jb20iLCJqdGkiOiI3NmM1MzhkMy1lNDA0LTQ3ZGUtYWRmNC00ZjNmZmM0NDc0NjYiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsImV4cCI6MTczNzQzMTIyMCwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzA3MS8iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MDcxLyJ9.mkvMaXbEEEsUOjKtS3baRlb3qWanXyRR1nHXdx49OEE"
}

Este ejemplo muestra las propiedades que contiene la respuesta, success, que indica si el servicio se ejecutó correctamente de cara a la logica del negocio, coderesult, el cual tendrá el statuscode de la respuesta, message, que tiene un mensaje de ayuda para guiar al cliente y data, que contiene como tal la información que se ha solicitado, en caso de sea una respuesta statuscode 200.

Otro ejemplo.

{
    "success": false,
    "codeResult": "404",
    "message": "No se encontró data",
    "data": null
}

en este caso es una respuesta donde no se encontró datos que coincidieran con la solicitud.

Requisitos funcionales

- Creación de los servicios:

- Creación de acción
- Actualizar Acción
- Eliminar Acción (solo será utilizado por el usuario Admin. Explicado mas abajo.)
- Cambiar Estado
- Listar Acciones
- Listar Acciones por Estado
- Listar Acciones por descripción de acción

Todos los servicios para poder ser utilizados deben utilizar un token, que se genera con el servicio siguiente:

- Login para generar Token.

Se crearon por base de datos dos usuarios que serán los unicos que tendrá el sistema:

{
  "email": "gregorduartemartinez@gmail.com",
  "password": "Barcelona576*",
  "role": "Admin"
}
 y

 {
  "email": "gabrielduartemartinez@gmail.com",
  "password": "Cine576*",
  "role": "Reader"
}

El usuario con role Admin, podrá consumir cualquiera de los servicios, mientras que el usuario con role Reader, tendrá restricciones para ejecutar el servicio de eliminar acción.


Requerimientos Técnicos

Se utilizó .Net 8. como framework.
Se utilizó C# como lenguaje de programación.
Se utilizó Visual Studio como IDE para desarrollar la aplicación.
Para la creación de la base de datos se utilizó SQL Server en Azure.

Docker

La versión de docker utilizada es 27.4.0
la versión de docker Compose es v2.31.0-desktop.2

El archivo docker-compose.yml levanta tanto la Api como la base de datos SQL Server.

Para poder ejecutar el contenedor con el comando  localmente, será necesario, primero, clonar la aplicación desde eñ
respositorio, mediante esta url https://github.com/gregorbuda/PruebaGregor.git. Luego
ir a power shell o a la linea de comandos y colocarnos en la raiz del proyecto (ejemplo: C:\Users\Lenovo\source\repos\PruebaGregor) y ejecutar el comando docker-compose up -d. 

Luego se recomienda utilizar Postman para hacer uso de los servicios.

Gestión de repositorios (GIT)

Se siguieron las indicaciones. 
Se hicieron Commits limpios y descriptivos y se hizo uso de branches para organizar el trabajo.





