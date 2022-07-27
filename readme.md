
# Teaching plan

## Week 1: Basics, Console projects

### Lesson 1

#### Aim

    1. Introduce myself, the course, get to know each other, our backgrounds and experiences, explain
    the Lithuanian market for .NET developers.
    2. Explain the structure of the course.
    3. Install Visual Studio 2019, get familiar with the development environment, create a new project.
    4. Get familiar with debugging technique.

#### Homework/Project

    Main: Hello World in Visual Studio.
    Extra: Enter your name or surname in Console window and print out a full sentence.
    Extra: Enter your date of birth and produce age.
    Extra: Console Calculator.
    
#### Links

    Visual Studio 2019 - https://visualstudio.microsoft.com/vs/
    Hello World program - https://en.wikipedia.org/wiki/%22Hello,_World!%22_program
    Developer salaries - https://docs.google.com/presentation/d/1keUGzMCqV3oedd2x9sPMTa3x2TP9iLDNWWy2OHqxF-c/

### Lesson 2

#### Aim

    1. Get familiar with Object-oriented programming (OOP).
    2. Get familiar with basic programming concepts in .NET: arrays, lists, loops, if statements, operators and etc.

#### Homework/Project

    Main: Console Shop Project.
    Extra: Upload it to GitHub.
   
#### Links

    Console Project Tutorial - https://docs.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-console?view=vs-2019
    GitHub 101 - https://guides.github.com/

### Lesson 3

#### Aim

    1. Continue learning C# programming, inheritance, encapsulation, abstraction and etc.
    2. Introduce NuGet packages library.

#### Homework/Project

    Main: Job advertisement scraper.
    Extra:
    
#### Links
    
    NuGet 101 - https://docs.microsoft.com/en-us/nuget/what-is-nuget
    Web scraping - https://en.wikipedia.org/wiki/Web_scraping
    Web scraping in c# - https://www.scrapingbee.com/blog/web-scraping-csharp/#making-an-http-request-to-a-web-page-in-c
    ScrapySharp - https://github.com/rflechner/ScrapySharp

### Lesson 4

#### Aim

    1. More Object oriented programming working with Generics and Inheritance.
    2. Introduce to Json.
    3. Learning how to work with Files.

#### Lesson 5

#### Aim

    1. Revision/ Project work

## Week 2: MVC + Razor, API technologies.

### Lesson 1

#### Aim

    1. Introduce MVC design pattern and Razor.
    2. Explain Project folder structure.
    3. Introduce sending data to the controllers.
    4. Explain Routing concept in MVC.

#### Homework/Project

    Main: Registration form application.
    Extra: Back-end validation and attributes.
    
#### Links

    Razor - https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-3.1&tabs=visual-studio
    MVC Pattern - https://dotnet.microsoft.com/apps/aspnet/mvc

### Lesson 2

#### Aim

    1. Introduce Razor engine limitations and explain why JavaScript is needed.
    2. Enriching Razor with JavaScript.

#### Homework/Project

    Main: Registration form upgrade. Make it a Single-page application (SPA).
    Extra:
    
#### Links

    Razor - https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-3.1&tabs=visual-studio

### Lesson 3

#### Aim

    1. Introduce WebAPI and differences from MVC.
    2. Explain REST API software architecture.
    3. Sending parameters (FromBody vs FromUrl).
    4. Test it via HttpGet, HttpPost, HttpDelete, using Postman.

#### Homework/Project

    Main: 'Minima' shop Warehouse RESTful API system for three items: bread, milk and cake.
    Extra: 3 items should reuse the same code, generic controllers, repository.
    Extra: Add Swagger to API.
    
#### Links

    What is an API? - https://www.youtube.com/watch?v=s7wmiS2mSXY&ab_channel=MuleSoftVideos
    REST API - https://www.restapitutorial.com/

### Lesson 4

#### Aim

    1. Get familiar with REST API documentation
    2. Swagger
    3. Postman

### Lesson 5

#### Aim 

    Revision Project Work

## Week 3: Databases

### Lesson 1

#### Aim

    1. Create a database on your local machine, setup MS SQL.
    2. Create schemas, tables, test data.
    3. SQL statements: SELECT, UPDATE, INSERT, DELETE. 
    4. SqlConnecion with .NET Core.

#### Homework/Project

    Main: Introduce customer object in 'Minima' application.
    Upgrade existing application to be able to filter by the customer.
    Extra: Upgrade the database with millions of records and observe the performance. 
    
#### Links

    SQL basics - https://www.dataquest.io/blog/sql-basics/

### Lesson 2

#### Aim

    1. Introduce Foreign Keys, Indexes.
    2. Explain Stored procedures, functions.
    3. Explain SQL clauses: Joins, Group By, Aliases.
    4. Introducing Dapper in .NET.

#### Homework/Project

    Main: Focus on One-to-One, One to Many, Many to Many
    Extra:
    
#### Links
    
    SQL Join - https://www.geeksforgeeks.org/sql-join-set-1-inner-left-right-and-full-joins/
    Dependency Injection (DI) - https://stackoverflow.com/questions/130794/what-is-dependency-injection

### Lesson 3

#### Aim

    1. Introduce Entity Framework Core, its benefits over plain SQL.
    2. Get familiar with DbSets, Linq.

#### Homework/Project

    Main: Upgrade 'Minima' to use EF Core and Linq instead of SqlConnection.
    Extra: Research IEnumerable vs IQueryable and apply proper usage.
    
#### Links

    EF Core - https://docs.microsoft.com/en-us/ef/core/
    LINQ - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/

### Lesson 4

#### Aim

    1. EF core advanced.
    2. Relationships: one to many, one to many, many to many.
    3. Loading related entities.

### Lesson 5
 
#### Aim

  Revision/ project work


## Week 4: Code-reusability, Architecture and Design patterns

### Lesson 1

#### Aim

    1. Clean code structure.
    2. Introduce an interface and its power through Dependency Injection (DI).
    3. Repository and Service coding patterns.

#### Homework/Project

    Main: Upgrade existing 'Minima' project to employ Customer and Product service, inject them as services.
    Refactor database access to use Repositories (Generic repositories + Unit of work).
    Extra:

#### Links

    Domain-Driven design (DDD) - https://en.wikipedia.org/wiki/Domain-driven_design
    Dependency Injection (DI) - https://stackoverflow.com/questions/130794/what-is-dependency-injection

### Lesson 2

#### Aim

    1. Dividing models into Entities and Data Transfer Objects (DTOs).
    2. Configure and employ AutoMapper.
    3. Exception handling.

#### Homework/Project

    Main: Employ the principles above to the current project.
    Extra:
    
#### Links
    
    AutoMapper - https://automapper.org/
    Exception handling - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/exceptions/exception-handling

### Lesson 3

#### Aim

    1. Introduction to Asynchronous Programming: Async/Await.
    2. Extension methods, Helper classes. When to use static classes.
    3. Shared project, common packages patterns.

#### Homework/Project

    Main: Employ the principles above to the current project.
    Extra:

#### Links

    Asynchronous Programming - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/

### Lesson 4

#### Aim

    1. Dividing solution into several projects.
    2. Clean Code
    3. SOLID

### Lesson 5

#### Aim

    Revision/Project work

## Week 5: Automated testing, Test-driven development (TDD)

### Lesson 1

#### Aim

    1. Introduction to Test-driven development (TDD).
    2. Understanding Unit tests.
    3. XUnit testing framework, Facts/Theories.
    4. Architecture for testing frameworks.

#### Homework/Project

    Main: Adding unit tests for existing projects.
    Extra:
    
#### Links
    
    Unit testing - https://softwaretestingfundamentals.com/unit-testing/
    Test-driven development - https://en.wikipedia.org/wiki/Test-driven_development

### Lesson 2

#### Aim

    1. Integration testing.
    2. Mocking services with Moq.
    3. Replacing Database with In-Memory Database for testing.

#### Homework/Project

    Main: Adding Integration tests to current projects.
    Extra:
    
#### Links
    
    Integration testing - https://softwaretestingfundamentals.com/integration-testing/
    In-Memory Database - https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli

### Lesson 3

#### Aim

    1. BDD + Specflow
    2. WireMock.

#### Homework/Project

    Extra: GildedRose refactoring Kata
  
#### Links

    GildedRose Kata - https://github.com/emilybache/GildedRose-Refactoring-Kata
    Refactoring Katas - https://kata-log.rocks/refactoring

### Lesson 4

#### Aim

    1. The issue with memory database.
    2. The issues with a real DB
    3. LocalDB
    4. Small Intro to Docker and how can it help to create databases

### Lesson 5 

#### Aim

    1. Revision

## Week 6: Working in teams, team project.

### Lesson 1

#### Aim

    1. Understanding Git, branching, merge-request, conflicts.
    2. Scrum, sprint methodologies.
    3. Divide into teams and work together to simulate real-life scenarios.

#### Homework/Project

    Major project: a Bank application. Be creative!
    Suggestions: be able to register and login (ignore security for now),
    Top up with the single click. Be able to send money to other account.
    Extra ideas: investing, be able to request money. Be creative!

#### Links
    
    How Banks operate - https://www.marketreview.com/how-banks-operate/
    Revolut -http://www.boussiasconferences.gr/files/_boussias_conferences_content/presentations/digitalbanking_cy/2019/dimitris_litsikakis_digibanking_cy19.pdf
    Scrum - https://en.wikipedia.org/wiki/Scrum_(software_development)
    Graphical Git clients - https://git-scm.com/downloads/guis

#### Lesson 2-3

    Continue working on the Bank Project.

## Week 6 CI/CD, Virtualization, Infrastructure?

### Lesson 1

    1. CI/CD in Github
    2. Yml files

### Lesson 2 

    1. Docker

### Lesson 3

    1. Docker-Compose

#### Lesson 4

    1. Kubernetes

#### Lesson 5

    1. Revision/Project


## Week 7: Authentication and Microservices

### Lesson 1

    1. Authentication is complex
    2. ASP.NET Identity

### Lesson 2

    1. Oauth2
    2. Identity Server.

### Lesson 3

#### Aim

    1. Monolith vs Microservice.
    2. Event Drive programming
    3. Messaging technologies.
    4. RabbitMq introduced

### Homework/Project

    Main: Setup a first pipeline in GitHub, which checks builds and runs tests.
    Extra:
    
#### Links
    
    CI/CD - https://www.infoworld.com/article/3271126/what-is-cicd-continuous-integration-and-continuous-delivery-explained.html
    Azure - https://azure.microsoft.com/en-us/

### Lesson 4

#### Aim

   1. Dividing solution into different domains.
   2. Event Handlers
   3. Publish your own Nuget

#### Homework/Project

    Main: Host a .NET project publicly.
    Extra:
    
#### Links

    Free web hosting - https://www.techradar.com/web-hosting/best-free-web-hosting
    SmarterASP.net - https://www.smarterasp.net/
    GitHub Pages - https://pages.github.com/

### Lesson 5

#### Aim

    1. Api Gateway
    2. Kubernetes basics

### Homework/Project

    Main: To be added.
    Extra:
    
#### Links

## 8-9 Revision and team-work project