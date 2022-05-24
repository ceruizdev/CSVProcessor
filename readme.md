# CSV Project
##### _Upload, Read and modify csv files_

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Minimal API built with .Net 6.0
## Requirements
-  [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) 
-  [Visual Code](https://code.visualstudio.com/) (optional)
-  [SQL SERVER](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
-  [Node.js](https://nodejs.org/)
-  [Angular Cli](https://angular.io/cli)

## Execution Guide
- git clone https://github.com/ceruizdev/CSVProcessor.git
### Backend
- Create enviroment variable called "CSVConnectionString" with value example "Server=YOUR_SQLSERVER_INSTANCE;Database=CSVProjectDB;Trusted_Connection=true;"
- Execute "Backend/CSVApplication.sln"
- Open nuget console 
- Set the layer project "CSVApplication.DataAccess" as default in the console
- Execute command "Add-migration initial"
- Execute command "Update-database"
- Check your SQL mangement to check the new database
- Run the project with layer CSVApplication.WebApi as startup project
If there's not errors and the database is ok, continue..

### Fronted
- In the fronted folder type the command "npm install"
- Make sure the file 'Frontend/src/environment/environment.ts' has the right port of backend project
- Run the command ng server

Note: With the migration you have two users for test the application

- Username: Administrator 
- Password: Test123
- Permission: Read, Create, Delete

- Username: carlos93
- Password: Test321
- Permission: Read

