# SImpleAuthService

SimpleAuthService is a microservice that implements 3 apis to showcase how a simple authentication service works

Written in C# using .NET 8. It makes usee of the ONION CLEAN architecture

SimpleAuhSystem/
│
├── SimpleAuhSystem.Domain/
│   └── Entities
│
├── SimpleAuhSystem.Application/
│   └── DTOs, Contracts, Services
│
├── SimpleAuhSystem.Infrastructure/
│   └── Repositories, Data(DbContext), Helpers
│
├── SimpleAuhSystem.Presentation/
│   └── Controllers, Program.cs, appsettings.json
|
└── README.md (Docs)
|
|
└── SimpleAuhSystem.sln

The application uses an inmemory database and can also be set to use docker.
The Presenatation project is the default application and would spring up the swagger interface once run
either using 'dotnet run' or running from a Visual Studio IDE.

To Test.

The Register api takes an email and password. And would return a corresponding response once created.

The Login api takes an email and password of resgistered user and returns a Token and Date of expiry. A one hour 
validity period was used.

The Secure api need a valid bearer token, to be accessed. The swagger takes the token from Login api to authenticate a user.
Should be in this format "Bearer {tokenFromLogin}". Once authenticated, user would successfully call the api. Else a 401 is displayed
