# PwcAssignment
Pwc Assignment project
  
# Requirements  
  1.Dot net 6.0 SDK
  2.Visual Studio 2022

# This tools provide Forcast details with current weather 
 
  1. To run this project download main project folder which is pwcAssignment
  2. Double click on PwcAssignment.sln and open it with visual stdio 2022
  3. When project load completely simply click F5 to start with debugger or Ctrl+F5 without debugger
  4. When program build and run successfully you will see swagger screen where you see two endpoints click on first endpoint and then click on try it out
      provide latitude & longitude you can select current_weather true or false and provide version 1 and click on execute this will provide you result
      
# Application Flow
  1. When program start i added a coravel scheduler to update data source which is a static variable use to fetch data.This scheduler runs once on application start        and every night 12 am so user can get latest details whenever application admin update data file. 
  2. I added a service file which is called to update, add and fetch data from data source (static variable)
  3. I added a version control in this project to provide desire output as project requirement.
  
# Folder Structure
  1. Controller - For user Endpoint 
  2. Models - Stores all model class which is used by application
  3. Helper - Where i put scheduler file 
  4. Datasource - Where i put data source file from which we fetch data.
  5. wwwroot - Where i put json file to read data on application start and update datasource at every given time.
