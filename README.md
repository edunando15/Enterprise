# Enterprise Project N01
# Advanced Programming Paradigms - Enterprise Programming course.
1. The database's backup is in the "Database" Directory in the "Models" project. It is sufficient to import it into SQL SQL Server Management Studio, following the steps: right click on "Database" -> "Restore Database" -> from the "General" section -> select "Devices" -> select the three dots -> select add -> select the .bak file, which must be present in the directory designed by SQL Server Management Studio.
2. To run the solution, the user can open it with Visual Studio and select the "Web" project as startup project. The Swagger interface will automatically open.
3. Pay attention to the default-selected filters in the API: if not emptied (strings set to "" and objects set to null), results will be altered.
4. The only APIs available without authentication are those used to register and log-in.
