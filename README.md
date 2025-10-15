# SmartMed
Back End code challenge of a simple REST API using C#

Code contains migration files to easily create the DB, however, you might need to go to medicationApi/appsettings.json and change the string on the "DefaultConnection". 
I followed the string:

"Data Source={PCNAME}\\SQLEXPRESS01;Initial Catalog={DATABASENAME};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" 

and my DB name is SmartMed

To Test:
On root folder run "dotnet test"

To Run: 
On medicationApi directory, run "dotnet watch run"

Swagger endpoint: http://localhost:5186/swagger/index.html
I used this throughout my entire development phase to test APIs

Database program used: SQL Server Managment Studio 21
