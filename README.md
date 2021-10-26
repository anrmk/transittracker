# Transit Tracker - test

By Aziz Nurmukhamedov

![image](https://user-images.githubusercontent.com/5101579/138818097-0b5f0f28-1446-4a28-94c6-8cb4e818d05e.png)

## Technologies used
- ASP.NET MVC
- JavaScript
- HTML
- Bootstrap (CSS)
- JQuery

## Description
This browser application allows the user get estimated arrival times for a requested bus stop.
### Server-side service
- There are 10 bus stops (Stops 1 - 10)
- Each stop is serviced by three routes: Routes 1, 2, and 3.
- Each stop is serviced every 15 minutes per route, 24 hours per day, and each route starts running 2 minutes after the previous one.
- Each stop is 2 minutes away from the previous one.

Example schedule for:
1. Stop 1: Route 1 12:00, 12:15, 12:30, 12:45 ... Route 2 12:02, 12:17, 12:32, 12:47 ... Route 3 12:04, 12:19, 12:34, 12:49 ... etc..
2. Stop 2: Route 1 12:02, 12:17, 12:32, 12:47 ... Route 2 12:04, 12:19, 12:34, 12:49 ... Route 3 12:06 12:21 12:36 12:51 ... etc..

The API should return to the consumer the next 2 arrival times per route for the requested stop.

Example:
1. Get/Retrieve for Stop ID 1

Would return 2 arrival times each for route 1, 2, and 3

### Web-based, client-side app 
Create a web-based app in the modern framework of your choice to interact with the API for stops 1 and 2. It should output the updated prediction times every minute until stopped.

Example output when running the app at 3:01PM:
1. Stop 1: Route 1 in 14 mins and 29 mins Route 2 in 1 mins and 16 mins Route 3 in 3 mins and 18 mins
2. Stop 2: Route 1 in 1 mins and 16 mins Route 2 in 3 mins and 18 mins Route 3 in 5 mins and 20 mins

## Setup/Installation Requirements
- Clone this repository to your desktop
- Navigate to the top level of the directory
- Use Visual Studio 2019 (or more) to open project `TransitTracker.sln`
- Befor start app, you need to `Restore Nuget Packages` and `Client-Side Libraries`
- Start application (Swagger: https://localhost:44379/swagger; WebApp: https://localhost:44379/home)

![image](https://user-images.githubusercontent.com/5101579/138814507-e9b0830d-9209-4293-997a-4fa3a394a6cc.png)
