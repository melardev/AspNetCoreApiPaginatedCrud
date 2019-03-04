# Introduction
This is a project mean to be used for learning basic CRUD operations and Pagination using
- AspNet Core Web Api
- Entity Framework Core


I have many other implementations of this server:
- [Spring Boot + Spring Data + Jersey](https://github.com/melardev/SpringBootJerseyApiPaginatedCrud)
- [Spring Boot + Spring Data](https://github.com/melardev/SpringBootApiJpaPaginatedCrud)
- [Spring Boot Reactive + Spring Data Reactive](https://github.com/melardev/ApiCrudReactiveMongo)
- [Go with Gin Gonic](https://github.com/melardev/GoGinGonicApiPaginatedCrud)
- [Laravel](https://github.com/melardev/LaravelApiPaginatedCrud)
- [Rails + JBuilder](https://github.com/melardev/RailsJBuilderApiPaginatedCrud)
- [Rails](https://github.com/melardev/RailsApiPaginatedCrud)
- [NodeJs Express + Sequelize](https://github.com/melardev/ExpressSequelizeApiPaginatedCrud)
- [NodeJs Express + Bookshelf](https://github.com/melardev/ExpressBookshelfApiPaginatedCrud)
- [NodeJs Express + Mongoose](https://github.com/melardev/ExpressApiMongoosePaginatedCrud)
- [Python Django](https://github.com/melardev/DjangoApiCrudPaginated)
- [Python Django + Rest Framework](https://github.com/melardev/DjangoRestFrameworkPaginatedCrud)
- [Python Flask](https://github.com/melardev/FlaskApiPaginatedCrud)


The next come are:
- NodeJs Express + Knex
- Flask + Flask-Restful
- Laravel + Fractal
- Laravel + ApiResources
- Go with Mux
- AspNet Web Api 2
- Jersey
- Elixir

# Commands used to build the project
```bash

# Install Sqlite Entity Framework provider
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
# or
Install-Package Microsoft.EntityFrameworkCore.Sqlite

# Install Route Analyzer
dotnet add package AspNetCore.RouteAnalyzer
# or
Install-Package AspNetCore.RouteAnalyzer

# Create Models, add migrations, and migrate
# with dotnet cli
dotnet ef migrations add InitialCreate
dotnet ef database update
# with Nuget Package Manager console(Powershell)
Add-Migration InitialCreate
Update-Database

```
# Follow me
- [Youtube Channel](https://youtube.com/melardev) I publish videos mainly on programming
- [Blog](http://melardev.com) Sometimes I publish the source code there before Github
- [Twitter](https://twitter.com/@melardev) I share tips on programming
