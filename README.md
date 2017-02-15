1. This application is separated into multiple tiers (distributed architecture).  Web API==>call Robot Position Service==>call Data Service. entity tier is share by all other tiers. The real implement needs to use repository to store data. 

2. The dependency injection(Unity container) is used to decouple the relationships between objects. WebAPI and Robot Position Service, Robot Position Service and Data Service.

3. All business logics are stored on Robot Position Service library. Each library can be considered as one business logic set of a microservice.

4. The application provides two types of method: Async and Sync. Async methods provide better none-block processes.

5. The application includes unit testings for almost all methods except some async methods. This should be done on real implementation.

6. The application does not provide exception handler and enough comments on methods. This should be done on real implementation.
