# Lector de Códigos de Barras para Windows 📦

### Descripción
Aplicación de escritorio desarrollada con **.NET 10** y **MAUI**. Diseñada para la gestión de inventario en Windows, permitiendo la captura de códigos de barras de productos mediante la cámara y el rellenado de información por voz.

### Tecnologías Usadas
* **.NET 10 / MAUI**: Framework para la interfaz y lógica de la aplicación.
* **ZXing.Net.Maui**: Control para el escaneo de códigos de barras.
* **Windows Media Speech**: API de Windows para el reconocimiento de voz.
* **Fody / PropertyChanged**: Para la actualización automática de la interfaz (MVVM).

### Interfaz Natural Implementada 🎤
El proyecto utiliza métodos de entrada naturales para mejorar la velocidad de uso:
* **Lector de códigos de barras**: Identificación automática de productos mediante la cámara.
* **Reconocimiento de voz**: Dictado directo de texto en los campos de nombre y descripción para no usar el teclado.

### La aplicación gestiona la información de los productos siguiendo el modelo CRUD (Create, Read, Update, Delete) de forma local
**CREATE (Crear)**: Se generan nuevos registros al combinar el escaneo de la cámara con el dictado por voz y pulsar "Guardar".
**READ (Leer)**: Los productos se visualizan en tiempo real dentro de la pestaña de Historial mediante un CollectionView vinculado a una ObservableCollection.
**UPDATE (Actualizar/Corregir)**: La lógica del botón "Reintentar Escaneo" permite resetear el estado del formulario para corregir capturas erróneas antes de su inserción.
**DELETE (Borrar)**: Se ha implementado una funcionalidad de borrado individual en el historial para eliminar registros de la memoria de la App.

### Instrucciones para probarlo
1. **Configuración**: Asegúrate de tener el micrófono activado en los ajustes de privacidad de Windows.
3. **Escaneo**: Coloca un código frente a la cámara. Al detectarlo, el sistema lo mostrará en pantalla y parará el visor.
4. **Dictado**: Pulsa el botón del micrófono 🎤 y habla para rellenar el nombre o la descripción.
5. **Reiniciar**: Si quieres volver a escanear, pulsa el botón azul **"REINTENTAR ESCANEO"**.
6. **Historial**: Al pulsar "Guardar", el producto aparecerá en la lista de la pantalla de Historial.

  **Clonar el repositorio:** 
  Abre el archivo .sln utilizando Visual Studio y asegúrate de tener instalada la carga de trabajo de .NET MAUI y el SDK de .NET 10 y pulsa F5 para compilar y ejecutar.
   ```bash
   git clone https://github.com/jesusgxmez/LectorCodigosBarras.git
