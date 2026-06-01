# Task API (AZ-204 Cloud Architecture Practice Project)

This project is a cloud-native backend application built with **.NET 8** and inspired by **Microsoft Azure** architecture patterns.
It is designed to simulate a real-world task management system while covering core topics of the **Azure Developer Associate (AZ-204)** certification.

The project focuses on practical implementation of:

* event-driven architecture
* asynchronous processing
* messaging patterns
* domain events
* scalable backend design
* cloud-native application structure

---

# Purpose

The goal of this project is to:

* Gain hands-on experience with cloud-native backend architecture
* Learn Azure-related architectural patterns through practical implementation
* Build a scalable and loosely coupled event-driven system
* Apply modern backend and messaging best practices
* Prepare for the AZ-204 certification through project-based learning

---

# Architecture Overview

The application follows a modular and event-driven architecture inspired by Azure services and distributed system patterns.

## Current Architecture

* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **Domain Events**
* **Integration Events**
* **Message Bus Abstraction**
* **Consumer Pipeline**
* **Dependency Injection Scopes**
* **Asynchronous Event Processing**

## Azure-Oriented Architecture Goals

The project architecture is intentionally designed to mirror common Azure solutions:

| Local Implementation        | Azure Equivalent            |
| --------------------------- | --------------------------- |
| FakeMessageBus              | Azure Service Bus           |
| Consumer Handlers           | Azure Functions             |
| SQL Server                  | Azure SQL Database          |
| Local Event Processing      | Serverless Event Processing |
| Dependency Injection Scopes | Function Invocation Scope   |

This allows the project to simulate realistic cloud-native workflows without requiring an active Azure subscription.

## Local Development Configuration

The database connection string is configured using .NET User Secrets and is intentionally not stored in the repository.

Example:

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<connection-string>"

---

# Key Features

* CRUD operations for task management
* Domain-driven event pipeline
* Event-driven architecture
* Integration event mapping
* Consumer-based asynchronous processing
* Message bus abstraction layer
* Clean separation of concerns
* Dependency injection and scoped processing
* Cloud-oriented backend structure

---

# Event Flow

```text
Client Request
    ↓
Task API
    ↓
Domain Event Created
    ↓
DbContext Dispatching
    ↓
Integration Event Mapping
    ↓
Message Bus Publishing
    ↓
Consumer Processing
```

---

# AZ-204 Topics Covered

This project directly maps to important AZ-204 certification areas:

## Develop Azure Compute Solutions

* ASP.NET Core Web API
* Azure Functions architecture concepts
* Dependency Injection
* Asynchronous processing

## Develop for Azure Storage

* Entity Framework Core
* SQL-based persistence
* Storage-oriented architecture patterns

## Implement Azure Security

* Service abstraction patterns
* Separation of concerns
* Secure architecture preparation for Managed Identity integration

## Connect to and Consume Azure Services

* Messaging abstraction
* Event-driven communication
* Queue and consumer concepts
* Integration event design

## Monitor and Troubleshoot Azure Solutions

* Structured logging concepts
* Distributed processing flow
* Event tracing concepts

---

# Azure Simulation Notes

Due to the lack of an active Azure subscription, cloud services such as:

* Azure Service Bus
* Azure Functions
* Azure SQL
* Blob Storage

are currently implemented as local simulations or architecture abstractions.

The project is intentionally structured so that simulated infrastructure components can later be replaced with real Azure services with minimal architectural changes.

The primary focus is on understanding:

* cloud-native architecture
* distributed systems
* event-driven design
* Azure-related backend patterns
* scalable application structure

rather than portal-based Azure configuration.

---

# Current Technical Concepts

The project currently implements:

* Domain Event Pattern
* Integration Event Mapping
* Consumer Pipeline Pattern
* Dependency Injection
* Scoped Service Resolution
* Asynchronous Event Handling
* Event-driven Architecture
* Separation of Domain and Integration Concerns

---

# Status

Work in progress — implemented incrementally with a strong focus on architecture, learning, and AZ-204 preparation.

---

# Notes

This project is intentionally designed to balance:

* practical backend engineering
* cloud-native architecture concepts
* Azure certification preparation
* portfolio relevance
* real-world software design patterns

The goal is not only to learn Azure services themselves, but to understand the architectural principles behind modern distributed cloud applications.
