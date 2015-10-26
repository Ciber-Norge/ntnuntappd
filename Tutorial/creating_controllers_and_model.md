# Setting up and adding migrations #
1. View -> Other Windows -> Package Manager Console
2. Enable-Migrations (Only do this once)
3. Add-Migration nameOfMigration (Provide a descriptive name for the migration, the name will be used as a class name, dont use spaces or weird characters)
4. Update-Database (Will receive error first time, complete the two steps below and run the update command again)
	1. Log into azure and select the database
	2. "Set up Windows Azure firewall rules for this IP address", then click YES

# Creating a new data model #
1. Right click "Models" -> Add -> new Item -> Code -> Class
	- Name it something, e.g BeerModels. (the plural s is because a table named BeerModels will be generated)
	- Create some properties for it
	- Build project

# Adding a controller #
1. Right click Controllers -> Add -> Controller -> MVC 5 Controller with views, using Entity Framework
	- Select the model class created earlier, e.g BeerModels
	- Data context class: ApplicationDbContext
	- Optionally change the name of the controller, however the name should end with Controller
2. Build project
3. Add new migration
	- View -> Other Windows -> Package Manager Console
	- Add-Migration descriptiveName
	- Update-Database

# Notes #
- The database tables should not be changed using Azure, only through code inside Visual Studio
- Every time a model is changed, a new migration should be added and updated for the database to reflect the changes
- A model will not be included if it is not used by a controller


