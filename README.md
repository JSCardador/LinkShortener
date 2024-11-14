# LinkShortener - Acortador de enlaces con Redis

Este proyecto es un **acortador de enlaces** desarrollado con **ASP.NET Core** y utilizando **Redis** como base de datos para almacenar las URLs originales y sus versiones acortadas. La API permite crear enlaces acortados mediante una petición `POST` y redirigir a la URL original mediante una petición `GET`.

## Características

- **POST /Link**: Recibe una URL original y devuelve un enlace acortado único.
- **GET /Link/{shortUrl}**: Recibe un enlace acortado y redirige al usuario a la URL original almacenada en Redis.
- Utiliza **Redis** para almacenar las URLs acortadas, lo que permite una gestión rápida y eficiente de los datos.

## Requisitos

- **.NET Core SDK 6.0 o superior**: Asegúrate de tener el SDK de .NET Core instalado en tu sistema.
- **Redis**: Redis debe estar instalado y ejecutándose en tu máquina local o en un servidor accesible para la aplicación. Si lo necesitas en tu máquina local, puedes instalar Redis en Mac usando Homebrew con el comando `brew install redis`.
