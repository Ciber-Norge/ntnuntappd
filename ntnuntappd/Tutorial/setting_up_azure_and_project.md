# Setting up the SQL database in Azure #
1. Log in to manage.windowsazure.com
2. Select "SQL DATABASES" in the column on the left
3. Press "+ NEW" in the bottom left corner, then "QUICK CREATE"
4. Fill in the information as wanted, then press "CREATE SQL DATABASE"

# Setting up the Web App in Azure #
1. Select "WEB APPS" in the column on the left
2. Press "+ NEW" in the bottom left corner, then "QUICK CREATE"
3. Fill in the information as wanted, then press "CREATE WEB APP"
4. After the new web app has finished its setup click on its name
5. Select the "LINKED RESOURCES" tab, then "LINK A RESOURCE"
6. "LINK AN EXISTING RESOURCE"
7. "SQL DATABASE"
8. Select the database created earlier and enter the login password associated with it

# Setting up the project in Visual Studio #
1. New Project
2. Create a ASP MVC project, give it a name (can be the same as the Web App name created in Azure)
3. Make sure the MVC template is selected, then press OK
4. In the next window ("Configure Microsoft Azure Web App"), press cancel. This will be setup a little later.
5. In the "Solution Explorer", right click the project folder and select publish.
	- Profile: Microsoft Azure Web Apps -> In the "Existing Web Apps" dropdown, select the Web App created in Azure
	- Settings: Copy the entire "DefaulConnection" string
	- Press publish, wait for publish to finish.
6. Open Web.config, which is located inside the main project filder (probably the file on the bottom of the solution explorer)
	- Replace the entire connectionString value (at line 14) with the string copied in step 5. The application will now connect to the SQL database when running the program locally rather than having a separate local database.

The project is now setup to publish to the Azure webapp and to use the database associated with the web app.
