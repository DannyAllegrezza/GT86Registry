# Infrastructure Project
This layer sits above the `Core` project. It implements the interfaces defined by the `Core` layer, specifically data access implementations. 

### Infrastructure Types
* EF Core types (DbContext, Migrations)
* Data access implementation types (Repositories)
* Infrastructure-specific services (FileLogger, SmtpNotifier, etc.)