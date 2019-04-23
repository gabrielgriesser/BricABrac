# BricABrac
A Simple website made with .NET Core

## Description :
https://hackmd.io/JTdif-u7SV-gkTepiyHbzA?view

## How to install the project :

### Dependance : 
* ASP.NET Core 2.2
	* If not go to : https://dotnet.microsoft.com/download/dotnet-core/2.2
* MySQL on the local machine
* MySQL Connector/NET install on the local machine
	* If not go to : https://dev.mysql.com/downloads/connector/net/

The projet required some Nugets Package for working, if it does not install with the project it will be necessary to add them by yourself :

1. In Solution Explorer, right-click References and choose **Manage NuGet Packages**.
![](https://i.imgur.com/NIZLvAH.png)

2. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Pomelo.EntityFrameworkCore.MySql**, select that package in the list, and select **Install**:

![](https://i.imgur.com/qbRsF8n.png)

3. Accept any license prompts.


### Database
Now we need to connect the database to Visual Studio

To create a connection to an **EXISTING** MySQL database (**you need to create the database in your SQL first with the name bricabracdb**) , perform the following steps:

1. Start Visual Studio and open the Server Explorer by clicking **View** and then **Server Explorer** from the main menu.

2. Right-click the Data Connections node and then click **Add Connection**.

3. From the Add Connection window, click Change to open the Change Data Source dialog, then do the following: 

![](https://i.imgur.com/A6JtHU8.png)


4. Type a value for each of the following connection settings: 

![](https://i.imgur.com/AcKtiMF.png)


5. Click OK to create and store the new connection. The new connection with its tables, views, stored procedures, stored functions, and UDFs now appears within the Data Connections list of Server Explorer. 

![](https://i.imgur.com/IA2x0u1.png)

After the connection is successfully established, all settings are saved for future use. When you start Visual Studio for the next time, open the connection node in Server Explorer to establish a connection to the MySQL server again.
