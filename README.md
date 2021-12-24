# IPT Project (Pakwheel Clone)

## Project Description:
The project aims to design a clone application of Pakwheels – a platform used for buying/selling all the accessories and parts associated with cars and motorbikes in Pakistan. In this clone application, my team intends to replicate very little functionality of this reference system i.e. Pakwheels, the purpose of implementing limited functionalities is to learn all the core concepts taught to us in the course of Information Processing Techniques in C# .NET framework like Windows Services, Web Services, API, Azure Function, Web Scraping and much more.
  
  
## Concepts Used:
The core concepts/functionalities implemented in C# for this project includes the use of:
- Web Service
- Windows Service
- Azure Function
- Desktop Application using .NET Framework
- MSSQL Database integration with C# application
- Web Application using .NET Framework
- Web Scraping

## Project Features:
The project aims to replicate some limited features of Pakwheels application, the feature set includes:
- Car Buying:
  This feature aims to list all the ads currently available in our database to the users.
- Car Selling:
This feature aims to allow the admin to list an ad for sale by uploading the ad to the database via a desktop application.
- Car Categorization with respect to make, model year, engine capacity, etc.
This feature aims to allow the user to search all the products listed in the database in the form of features i.e. view all the cars with the brand name of “Toyota”, view all the cars listed having model year in the range of “2016-2019”, or maybe all cars with engine capacity “less than 1300cc”.
- Search result filtering with respect to preferences
This feature aims to allow the user to put filters on cars obtained as a result of user query in order to reduce search space.
- Live car price update(s):
This feature allows the user to get the current car price(s) of all the cars available on Toyota motor websites, if the user wishes to view the details, the website redirects the user to the webpage of Toyota.

## Technologies:
- C#  language
- ASP.NET
- Web Scraping
- MSSQL Database
- Azure functions
## Interfaces:
- Web Application (for viewing ads and view current car price updates)
- Desktop Application (only for listing of cars and plain data grid view of ads listed on database)
## Implementation Strategy:
The system works in the following way:
- The system has a database to store adsData in localhost MSSQL Server
- The system first generates test data by scraping data from Pakwheels website which is implemented as a console app and can be used as a timed WebService which keeps hitting the website of Pakwheels on certain intervals to generate updated data.
- The scrapping results in the generation of csv file of the overview of ads scrapped from pakwheels website
- After a csv file is generated a windows service is present which uploads the ads gathered after scrapping the website to the database at regular intervals
- Once the database is filled with the windows service, the user can access the database via a web application to view all the ads.
- If a user clicks on an ad, the web application makes a request to the Azure function deployed on clouds to get details of the ad by providing the service with the details url of the ad available in the database for each ad.
- The web application then waits for the Azure function to return the details of the ad which includes other images, car features and seller comment.
- For getting live car price update(s), an Azure function is deployed on cloud which serves as a scrapper for getting car price updates from Toyota website 
- The desktop application can be used to view currently listed products in the form of datagrid view as well as list new ads.





## How to Use the Designed System:
The system can be used locally by following the below mentioned steps:
- Create a database in your local storage by the script provided
- Run the web scraper to scrap list of some ads from pakwheels website
- Install the windows service
- Run the windows service to update the database
- Now you can use both the web and desktop application
- Alter the database connection string credentials and necessary file path(s) in the app.config file for windows service, web application, and desktop application

