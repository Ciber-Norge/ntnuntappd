# Adding new model view controller #
## Adding a Beer model ##
Right click "Models" -> add -> new item -> Code -> Class
  + name it something, e.g BeerModels
  + Create properties for it. The id-property should be an int.
  + Build project.

## Create controller ##
Right click "Controllers" -> add -> controller -> MVC5 Controller with views, using Entity Framework
  + Model class: BeerModel
  + Data context class: ApplicationDbcontext
  + Controller name: Give it a different name, e.g BeerController instread of BeerModels1Controller
  + Press add and wait a little bit

## Add beer link ##
"Shared" -> -Layout.cshtml:
  + Copy add new action link (line 35?), replace info appropriately. This displays a Beer link on the front page.

## Update the azure database with the Beer model ##
View -> Other windows -> Package Manager console:
  + Add-Migration nameOfMigration
  + Update-Database
