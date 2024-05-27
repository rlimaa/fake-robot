# fake-robot
Fake Cleaning Robot Api


### Setup
To start running the service it's necessary to update the `env_file` on the root with a valid Postgres connection string. The next step is to run

```
docker compose up
```
If you need to rebuild the docker image, then run 
```
docker compose build
```
before running docker compose up command.

### Decision log
1. The project is designed using [Domain Driven Design](https://github.com/tdonker/domain-driven-design-links)
2. The `timestamp` field on the `Executions` table is stored with UTC 
3. The `duration` field on the `Executions` table is stored in nano seconds
4. When the robot is moving North Y coordinate is incremented, when moving South Y is decremented
5. When the robot is moving East X coordinate is incremented, when moving West X is decremented