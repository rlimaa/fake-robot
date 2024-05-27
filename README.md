# fake-robot
Fake Cleaning Robot Api

### Dependencies
1. .NET Core SDK  8
2. Nuget
3. EntityFrameworkCore 8.0.5

### Setup
To start running the service it's necessary to update the `.env` file on the root folder with applicable environment variable, specially the `CONNECTION_STRING` env variable with a valid Postgres connection string. An example of .env file can be seen below.

```dotenv
CONNECTION_STRING="Username=USER;Password=PASSWORD;Server=HOST:PORT;Database=FakeRobot"
ASPNETCORE_ENVIRONMENT=Development
ASPNETCORE_HTTP_PORTS=5001
```

The next step is to run:

```
docker compose up --build
```
### Infrastructure
The project was designed to use the `FakeRobot` database, containing the `Executions` table. A code first approach was used alongside `EntityFramework`. If the database does not exist on the Postgres instance connected, the system automatically creates it applying the migrations declared on the `FakeRobot.Infrastructure` project.

### API
The `FakeRobot.Api` project is the solution startup project and contains the dependency injection register and also all the API configuration. The validations and `Controllers` can be found there as well.

### Application

The `FakeRobot.Application` project contains the orchestration of the API, it call the right domain objects and stores the results using the Infrastructure.

### Domain
The `FakeRobot.Domain` project contains the core domain of the system. The `CleaningRobot` class is declared there, where all the domain logic is encapsulated.

### Contracts
The `FakeRobot.Contracts` project contains the contracts used in this API. Other systems should use it to speak with this API.

### Postman
There is a folder called `FakeRobot.Postman` on the `src` folder which contains a collection of requests and an environment that can be imported to Postman to test and exemplify the usage of the API.

### Decision log
1. The project is designed using [Domain Driven Design](https://github.com/tdonker/domain-driven-design-links)
2. Port `5001` was used because port `5000` was already in used in my local environment 
3. The `timestamp` field on the `Executions` table is stored with UTC
4. The `duration` field on the `Executions` table is stored in nano seconds
5. When the robot is moving North Y coordinate is incremented, when moving South Y is decremented
6. When the robot is moving East X coordinate is incremented, when moving West X is decremented
7. Given the small complexity of the system, only the core features are tested programatically, that is the `Domain` with the project `FakeRobot.Domain.Tests` and the interaction with outside world with the Postman tests on the `FakeRobot.Postman` folder. 