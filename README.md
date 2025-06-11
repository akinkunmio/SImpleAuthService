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
