# EShopMicroservices


## Port number for each microservices

** http - https **

 Microservices      | Local Env                     | Docker Env                  | Docker Inside               |
| ----------------  | ----------------------------- | --------------------------  |
| Catalog           | 5000 - 5050                   | 6000 - 6060                 | 8000 - 8081                 |


## BuildingBlock

** 1. Manage NuGet packages version control **

## Rest API Endpoints

### Catalog Microservices

 Method             | Request URI                   | User Cases                  |
| ----------------  | ----------------------------- | --------------------------  |
| GET               | /products                     | List all products           |
| GET               | /products/{id}                | Fetcha specific product     |
| GET               | /products//category           | Get products by catagory    |
| POST              | /products/                    | Create a new product        |
| PUT               | /products/{id}                | Update a product            |
| DELETE            | /products/{id}                | Remove a product            |
