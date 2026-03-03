# Console RPG Engine

An educational console-based Role-Playing Game (RPG) engine built with C#. The primary objective of this project is to provide a practical demonstration of core software engineering principles, including **OOP**, **SOLID**, **Generics**, and **Design Patterns** within a functional application.

The engine features turn-based combat, a flexible generic inventory system, character progression, and JSON-based state persistence.

## Tech Stack & Architecture

Built with a strong emphasis on clean architecture, extensibility, and maintainable C# code.

* **Language:** C#
* **Platform:** .NET Core / .NET 5+
* **Serialization:** `Newtonsoft.Json` (utilizing `TypeNameHandling` for correct polymorphic deserialization of inventory items and weapons).

### Applied Design Patterns

This project actively demonstrates the practical application of Gang of Four (GoF) design patterns:

1. **Factory Method:** The `EnemyFactory` class encapsulates the complex logic for instantiating random enemies, cleanly isolating object creation from the main game loop.
2. **Strategy:** Implemented via the `IWeapon` interface. Different weapons encapsulate their own damage calculation algorithms (`CalculateDamage`), allowing the hero to swap combat behaviors dynamically at runtime.
3. **Observer:** Utilizes native C# events (e.g., `OnDied`) to notify the `GameManager` of character deaths. This cleanly decouples the combat mechanics from the reward and XP distribution logic.
4. **Decorator:** Enables the dynamic attachment of additional behaviors or effects to weapons (e.g., adding elemental fire damage) or characters without modifying their underlying base classes.
5. **Singleton (State Management):** The `GameManager` acts as the centralized coordinator, managing the global state of the game and the execution of the core game loop.