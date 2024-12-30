# EShopMicroservices


## Port number for each microservices

Http - Https

 Microservices      | Local Env                     | Docker Env                  | Docker Inside               |
| ----------------  | ----------------------------- | --------------------------  |	--------------------------	|
| Catalog           | 5000 - 5050                   | 6000 - 6060                 | 8000 - 8081                 |


## BuildingBlock

1. Manage NuGet packages version control

## Rest API Endpoints

#### 1.Catalog Microservices

 Method             | Request URI                   | User Cases                  |
| ----------------  | ----------------------------- | --------------------------  |
| GET               | /products                     | List all products           |
| GET               | /products/{id}                | Fetcha specific product     |
| GET               | /products//category           | Get products by catagory    |
| POST              | /products/                    | Create a new product        |
| PUT               | /products/{id}                | Update a product            |
| DELETE            | /products/{id}                | Remove a product            |


## Run With Docker

1. Run docker with docker compose btn

2. Open command line

3. Type "docker ps" to check current running container

4. Type "docker exec -it <container id> bash" to enter postgres

5. "\l" to list db and "\c <database name>" to connect database

6. "\d" to check tables