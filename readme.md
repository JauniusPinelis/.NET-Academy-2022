
# Teaching plan

## Week 1: Basics, Console projects

### Lesson 1 Intro

#### Aim

    1. Introduce myself, my experience etc.
    2. Explain the structure of the course. The aim of this course. Emphasis on teamwork.
    3. Accelerated start to get you to able to work in a team.
    4. Working in a scrum. Jira.
    5. Install Visual Studio 2022, get familiar with the development environment, Project Types.
    6. C# Basics -> Strings, Console Input, Output, Numbers, Parsing, Basic branching.

### Lesson 2 Basic c# programming

#### Aim

    1. Get familiar with.
    2. Get familiar with basic programming concepts in .NET: Methods, Parameters, output, arrays, lists, loops statements, operators and etc.

#### Homework/Project

    Main: Console Shop Project.

### Lesson 3 OOP

#### Aim

    1. Introducing Object Oriented programming into C#: Classes, Objects, properties, constructors, functions.
    2. Emphasis on encapsulation and abstraction, splitting functionality into different classes (services).
    3. Continue learning C# programming, inheritance, encapsulation, abstraction and etc.

#### Homework/Project

    Main: Console Shop Project.

### Lesson 4 Lists, Objects, LINQ, JSON, Writing files

#### Aim

   1. Arrays/Lists manipulation.
   2. Creating, Adding, Removing Lists of Objects.
   3. LINQ -> Filtering (Where), Select, ForEach.
   4. JSON Notation
   5. Writing Reading from Files.

#### Homework/Project

    Main: Console Shop Project continued -> Save State to json file, write load from it. 

### Lesson 5 GIT

#### Aim

    1. Github
    2. Git 
    3. Github Desktop Client
    4. GIT CLI
    5. Staging, Commit, Push, Remote, Branching, Pull-requests, Conflicts.
    6. .gitignore
    7. Git Flow.

## Week 2: Databases, API

### Lesson 1 POSTGRE

#### Aim

    1. Relational Databases -> Postgre
    2. Installing Postgre.
    3. Installing pgAdmin
    4. SQL for tables, columns, data.
    5. Primary Keys, Foreign Keys, Indexes
    6. Relationships One to One, One to Many, Many to Many.

#### Homework/Project

   Create a database schema for a shop. Populate it with data.

### Lesson 2 C# with Postgre

#### Aim

   1. Nugets.
   2. SQLConnection
   3. The trouble mapping sql to c# objects.
   4. Dapper.
   5. Repository.

#### Homework/Project

    Main: Shop should use database instead of Json

### Lesson 3 API

#### Aim

    1. Introduce WebAPI, MVC.
    2. Explain REST API software architecture.
    3. Sending parameters (FromBody vs FromUrl).
    4. Test it via HttpGet, HttpPost, HttpDelete using Swagger.
    5. Swagger
    6. CRUD.

#### Homework/Project

    Main: CRUD api for Product warehouse.

#### Links

    What is an API? - https://www.youtube.com/watch?v=s7wmiS2mSXY&ab_channel=MuleSoftVideos
    REST API - https://www.restapitutorial.com/

### Lesson 4 API architecture

#### Aim

    1. Controllers
    2. Services
    3. Repositories
    4. Static Helper classes.
    5. Extension methods
    6. Dtos
    7. Entities
    8. DbDeploy/dbup

#### Homework/Project

    Main: Apply best practices for Product warehouse.

### Day 5

    1. UML
    2. How to work in teams
    3. Dividing into tasks.
    4. Agile programming 
    5. Pull-requests and Conflicts reminder

## Week 3 for Hosting/Adform specifics

### Day 1 CI/CD

    1. CI/CD
    2. Github Actions
    3. Yml files/templates

### Day 2 Docker Kubernetes intro

    1. Virtual machines
    2. Docker.
    3. Kubernetes

### Day 3 Hosting (Adform)

    1. Scrum by Adform
    2. Hosting and other details of Adform

### Day 4 Logging and Monitoring in SCRUM (Adform)

    1. Need for logging and monitoring
    2. Grafana
    3. Kibana

### Day 5 Vault and other missed details (Adform)

    1. Vault
    2. Other detais

## Week 4 The Good Practices

### Day 1 Asynchronous programming and HttpClient

    1. Async/Await
    2. Task.Await
    3. System Integration
    4. HttpClient
    5. https://jsonplaceholder.typicode.com/
    6. Parsing response.
    7. Sending Body

### Day 2 Automapper, Generics

    1. Dont expose Entities
    2. Dtos
    3. AutoMapper
    4. Inheritance
    5. Generics

### Day 3 Validation and configurations

    1. Attributes
    2. ModelState
    3. FluentValidation
    4. Services vs StaticHelpers vs Extensions
    5. Appsettings/Configurations.

### Day 4 Exceptions StatusCodes

    1. Exception handling
    2. Custom Exceptions
    3. Status Codes.

### Day 5 REST API delicacies

    1. REST API documentation
    2. Swagger documentation attributes.
    3. Semantic versioning, contract changes.
    4. Is Api Restful?

## Week 4 Automated Tests

### Lesson 1 Xunit

#### Aim

    1. Nunit
    1. InlineData
    2. Task.Assert vs FluentAssertions
    3. Archictecture for tests.

### Lesson 2 Mocks

    1. Dependency Inversion Principles.
    2. Interfaces
    3. Mocks
    4. Moq
    5. Code Coverage

### Lesson 3 Integration Tests

    1. Integration Tests
    2. WebApplicationFactory
    3. CustomWebApplicationFactory
    4. InMemoryDatabase vs RealDatabase
    5. Real Database issues.
    6. Db with Docker

### Lesson 4 WireMock, Autofixture

    1. External Apis,
    2. Adapter Pattern
    3. WireMock.
    4. Autofixture.

### Lesson 5 Bdd Specflow

    1. Bdd
    2. Specflow
    3. TDD

## Week 5 Devops

### Lesson 1 CI/CD

    1. CI/CD
    2. Github Actions
    3. Yml files.
    4. Build, run tests in pipelines
    5. SonarQube.

### Lesson 2 Docker

    1. Virtual machines
    2. Install Docker
    3. Docker run Postgre
    4. Docker Images/Containers

### Lesson 3 Docker-compose

    1. Building images.
    2. Pushing registry
    3. Creating Container
    4. Docker-compose

### Lesson 4 Kubernetes

    1. Kubernetes

### Revision

    1. Revision

## Week 6 Microservices

### Lesson 1 Microservices

    1. Monolith
    2. Microservices

### Lesson 2 RabbitMq

    1. Event Driven programming
    2. API calls vs messages
    3. Messaging technologies.
    4. RabbiqMq
    5. RabbitMq with Docker.

### Lesson 3 RabbitMq continued

    1. Publishing Event
    2. Subscribing Events
    3. Retries.

### Lesson 4 Api Gateway and Logging

    1. Ocelot
    2. Importance of Logging in Microservices

### Lesson 5 Background running tasks

    1. BackgroundService
    2. Hangfire

## Week 6 Databases DeepDive

### Lesson 1 SQL Recap

    1. Recap of SQL.
    2. Joins
    3. Views
    4. Procedures
    5. Triggers
    6. Functions

### lesson 2 SQL Migrations

    1. DbSchema as Code with Liquibase or Flyway.
    2. Integration tests with real DB in Docker.

### lesson 3 ORM and EFCore

    1. ORM
    2. EFCore Code first.
    3. EfCore Migrations
    4. EF weaknesses.

### lesson 4 Document Databases

    1. Document vs Relation
    2. MongoDb 
    3. MongoDb on Docker
    4. MongoDB C#/.NET Driver

### Lesson 5 Performace, Scaling

    1. Query performance issues
    2. Query optimization.
    3. Vertical vs Horizontal scaling.
    4. Partitioning/Sharding

## Week 7 Authentication And useful nugets

### Lesson 1

    1. Authentication vs Authorization
    2. Register
    3. Login
    4. Hashing Passwords
    5. Session Token
    6. JWT

### Lesson 2 Authentication with HttpClient

    1. Securing API
    2. Credentials
    3. x-api-key
    4. Bearer token

### Lesson 3 OAUTH2

    1. OAuth 2.0
    2. Identity Server 4

### Lesson 4 REFIT Client

    1. REFIT

### Lesson 5 Productivity extensions

    1. Visual Studio Extensions
    2. Add new file
    3. Power tools
    4. Useful shortcuts, snippets.

## Week 8 Design patterns

### Day 1 Solid

    1. Solid

### Day 2 Design Patterns

    1. Strategy pattern
    2. Factory
    3. Adapter
    4. Singleton

### Day 3 Mediator

    1. MediaTr 
    2. CQRS

### Day 4 Domain Driven Design

    1. DDD (Domain Driven Design)
    2. Clean Architecture.

### Day 5 Func Action Predicates

    1. Functions Action Predicates
    2. Working with Enums

## Week 9 .NET framework and other Microsoft technologies

### Day 1 .NET framework

    1. NET core vs .NEt Framework
    2. What does it mean to work on legacy code.
    3. .NET framework project structure.
  
### Day 2 .NET Framework WCF/Soap

    1. Missing dependency injection
    2. Razor Pages application (asp.net mvc)
    3. cshtml