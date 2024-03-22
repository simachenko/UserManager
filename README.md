# UserManager
### Running .NET 8 Project and Migrating the Database

**1. Configuration Setup:**
   - Ensure that you have configured the SQL Server connection string in your `appsettings.json` file.

   Example `appsettings.json` configuration:
```json
   "ConnectionStrings": {
     "Connection": "Server=<ServerName>;Database=<DatabaseName>;User Id=<UserId>;Password=<Password>;MultiSubnetFailover=True;Connect Timeout=1000;"
   },
   "ConnectionDbPassword": "<YourDbPassword>" // this shold be stored as environment variable
```

**2. Migration Execution:**
   - Open a command prompt or terminal.
   - Run specified commands with sql user that have permissions to modify schema

   Execute the following commands to apply migrations and update the database:
```bash
   dotnet ef database update --context UserManagerContext --project "<pathtoproject>UserManager\UserManager.Infrastructure\UserManager.Infrastructure.csproj" -- 'Data Source=<HOST>;Initial Catalog=UsersTemp;User ID=sa;Connection Timeout=300;MultiSubnetFailover=True;Encrypt=False;Password=<PWD>' 'dbo'
```

**2. Run:**
	- Execute
```bash
	dotnet run
```
Swagger under <host>/swagger/index.html address






