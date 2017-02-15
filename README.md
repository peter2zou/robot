1. This application is separated into multiple tiers (distributed architecture).  Web API (API interface)==>call Robot Position Service(Business Layer)==>call Data Service(Data Access Layer). The entity tier is shared by all others. The real implement needs to use  repository to store data. 

2. The dependency injection(Unity container) is used to loose couple the relationships between objects. WebAPI and Robot Position Service, Robot Position Service and Data Service.

3. All business logics are stored on Robot Position Service library. One business logic set should create one liberary for one microservice. 

4. The application provides two types of method: Async and Sync. Async methods provide non-blocking running.

5. The application includes unit testings for almost all methods except a few async methods. This should be done on real implementation.

6. The application does not implement validations, exception handlings, logging and comments. This should be done on real implementation.
