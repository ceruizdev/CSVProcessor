# CSV Project
##### _Upload, Read and modify csv files_

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Minimal API built with .Net 6.0
## Requirements
-  [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/) 
-  [Visual Code](https://code.visualstudio.com/) (optional)
-  [SQL SERVER](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)
-  [Node.js](https://nodejs.org/)

## Execution Guide
- git clone 
### Backend
- Create enviroment variable called "CSVConnectionString" with value example "Server=YOUR_SQL_INSTANCE;Database=CSVProjectDB;Trusted_Connection=true;"
- Execute "Backend/CSVApplication.sln"
- Open nuget console 
- Execute "Add-migration initial"
- Execute "Update-database"