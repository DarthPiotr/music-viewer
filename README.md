# Music Viewer

A simple database for artists and their music. 

The main goal of the Music Viewer is to keep following architecture:
 - A library project that handles a database and provides a BLC (Business Logic Controller) interface,
 - Depending on the config, the library can use a SQLite database or a mock in-memory objects as a data source,
 - An ASP.NET Core web application which uses the library to manage the data,
 - A .NET MAUI desktop application which uses the library to manage the data

Final project for visual programming course at University of Technology.

## Features
 - ASP.NET Core
 - Entity Framework
 - .NET MAUI
 - Razor pages
 - Unit tests
