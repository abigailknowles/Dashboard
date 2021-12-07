# PatientWarning back-end code
## Instalations
	1. Ensure you have .NET core 3.1 run time installed - https://dotnet.microsoft.com/download/dotnet/3.1
	2. Ensure you are running the application in visual studio 2019 or above, if not download the latest version - https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022
## Config
	1. In the solutions explorer of vs 2019, right click on PatientWarningApp.Api project. In the menu that appears, 
	select 'Properties' at the bottom. That should then open the properties pane for the project
	2. Then select 'Debug' in the left-hand navigation of the properties pane. In the properties section that appears, scroll down to
    the bottom until you see 'App URL'
	3. You then need to change the app url to be http://<your_ip_goes_here>:5000, once this is done save your changes
## Running the solution
	1. Make sure you it is the 'PatientWarningApp.Api' solution you are trying to run
Once this is done and you are running the PatientWarningApp.Api solution - and you should see swagger appear, we use this to test our APIs

If you want to test the react web dashboard or mobile app you need to run those projects seperatly and follow the required steps, each of those
have their own read me that includes a how to guide

# Database
## Instalation
	1. Ensure you have MySQL installed - and workbench if you'd like - https://www.mysql.com/products/workbench/
## Set up
	1. Included in the uploaded files is an exported database file with populated with test data, you need to import this into your 
	chosen database manager
	2. Once the above is done you need to update the app settings.json file found in the PatientWarningApp.Api project to use your database
	username and password config
	3. You should now re run the 'PatientWarningApp.Api' solution
Once all the above steps are done you should have a database populated with tables and data that our APIs can interact with.

