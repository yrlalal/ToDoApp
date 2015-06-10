Tools
-----
Visual Studio 2010, 
MS SQL Server 2008

Technologies and Languages
--------------------------
C#, 
.NET framework 4.0, 
ASP.NET MVC 4.0, 
Unity IoC Container, 
Entity Framework, 
LINQ, 
T-SQL, 
JavaScript/jQuery, 
SASS, 
Responsive Web Design using CSS3 Media Queries, 
MSTest, 
Rhino Mocks, 
Bootstrap

Build Instructions
------------------
1) Open the solution in Visual Studio 2010.
2) Run the SQL script "CreateDatabase.sql" located in "TaskDb\Scripts" folder on MS SQL Server 2008. This will create a new database called "TaskDb".
3) Update the connection string in web.config.
4) Build the solution and run the application in Visual Studio Dev Server. To run in IIS, create a virtual directory and set the credentials. Add ASP.NET Impersonation 
element in web.config (<identity impersonate="true"/>).

