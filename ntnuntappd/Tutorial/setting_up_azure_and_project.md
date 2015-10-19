# Initial screen #
1. new project -> ASP.NET Web Application
  - Name: Wabby
2. ASP.NET 4.5.2 templates -> MVC
  (check host in the cloud if unchecked. Use website)


# Next screen
## (VS 2015) #
(yelow means not allowed)
App service plan -> create new -> wabbyap
Resource group -> Create new Resource group -> wabbyresgroup
Region -> North Europe
Database server -> create new
  + Database server -> wabbybase  (must be lower case)
  + Database username -> wabby
  + Database Passoword -> Qwerty123!

## VS 2013 ##
Site name -> name
Subscriprtion? -> Trial?
Region -> North Europe
Databse servers -> create new server
  + Database username -> wabby
  + Database password -> Qwerty123!

# Press OK #
Overall status failed will/can be displayed, not to worry

# Setting up publishing details #
Solution explorer -> Wabby (right click) -> publish:
### Profile ###
Microsoft Azure Webapp (websites? VS2013) -> Exisiting Web Apps -> Wabby
### Connection ###
Validate connection //is okay
### Settings ###
DefaultConnection -> press the "..." button -> rename Wabby_db to wabbybase -> Test connection (will/can fail)
### Publish! ###
Press the publish button
## Azure website ##
Log on to azure. Manage -> SQL Databases -> +New -> Quick create
  - Database name : wabbybase
  - server: wabbybase

Select the wabbybase sql database -> Design your SQL database -> Set up Windows Azure firewall rules for this IP address -> yes
  + Back into Solution Explorer -> Publish -> Settings -> test connection should work
  + publish (not sure if necessary...)

### Fix connection string ###
In Web.config, replace the connection string with the connection string from Publish -> Settings -> "...", Remove Integrated Security or set it to false.

# Push database to server #
View -> Other windows -> Package Manage console:
  - Enable-Migrations (autocomplete fo show)
  - Add-Migration chooseNameOfMigration
  - Update-Database
