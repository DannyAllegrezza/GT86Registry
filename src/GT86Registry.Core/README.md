# Application Core Project
The application core layer has no depdencies on other application layers. This layer is currently comprised of the apps entities and interfaces, however, it could also be responsible for the following:

### Application Core Types

* Interfaces
* POCO Entities (business model classes that are persisted)
* Business Services
* Domain Events
* Aggregates
* Application exceptions
* Specifications
* Value Objects

The Application Core holds the business model, which includes entities, services, and interfaces. These interfaces include abstractions for operations that will be performed using Infrastructure, such as data access, file system access, network calls, etc. Sometimes services or interfaces defined at this layer will need to work with non-entity types that have no dependencies on UI or Infrastructure. These can be defined as simple Data Transfer Objects (DTOs).