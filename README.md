# UpgradeManager

> **OTUS Educational Project** — Unity upgrade system implementation  
> **Учебный проект OTUS** — реализация системы улучшений на Unity

---

## 🇬🇧 English

### Overview

**UpgradeManager** is a Unity 3D educational project developed as part of the [OTUS Game Developer course](https://otus.ru/). The goal of this project was to design and implement a flexible, data-driven **upgrade system** for a game character — a common and essential feature in RPG, action, and roguelike games.

The system allows players to spend in-game currency to level up character attributes such as **damage**, **health**, and **movement speed**. Upgrades can have **prerequisite requirements** and are fully configurable via Unity's ScriptableObjects.

---

### 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| **Unity 2022** | Game engine |
| **C# (.NET)** | Game logic |
| **Zenject** | Dependency injection framework |
| **Odin Inspector** | Enhanced Unity editor tooling |
| **TextMeshPro** | UI text rendering |
| **ScriptableObjects** | Data-driven configuration |

---

### 🏗️ Architecture

The project follows clean architecture principles with clear separation of concerns:

```
Assets/Scripts/
├── Upgrades/
│   ├── Configs/                  # ScriptableObject configs (data)
│   │   ├── UpgradeConfig.cs      # Abstract base config with price table
│   │   ├── DamageUpgradeConfig.cs
│   │   ├── HealthUpgradeConfig.cs
│   │   └── SpeedUpgradeConfig.cs
│   ├── IUpgrade.cs               # Interface for upgrades with requirements
│   ├── Upgrade.cs                # Abstract base upgrade (level, progress, events)
│   ├── DamageUpgrade.cs          # Concrete damage upgrade
│   ├── HealthUpgrade.cs          # Concrete health upgrade (supports prerequisites)
│   ├── SpeedUpgrade.cs           # Concrete speed upgrade
│   ├── UpgradeCatalog.cs         # ScriptableObject catalog of all upgrades
│   └── UpgradesManager.cs        # Core manager: level-up logic & money checks
├── Hero.cs                       # Game character with PlayerStats
├── PlayerStats.cs                # Dynamic stat dictionary (add/change/remove)
├── MoneyStorage.cs               # In-game currency with events
├── GameInstaller.cs              # Zenject bindings (DI composition root)
├── UpgradesInstaller.cs          # Wires up catalog → upgrades → requirements
├── DebugMoney.cs                 # UI component for displaying money
└── DebugUpgrade.cs               # Debug helper for upgrade interactions
```

---

### ✨ Key Features & Design Patterns

#### 1. Data-Driven Configuration (ScriptableObjects)
Each upgrade type has a dedicated `UpgradeConfig` ScriptableObject with a configurable **price table** that auto-calculates costs per level based on a base price. Designers can tweak upgrade data directly in the Unity Inspector without touching code.

#### 2. Dependency Injection (Zenject)
`MoneyStorage` and `UpgradesManager` are registered as singletons in `GameInstaller` and injected wherever needed. This decouples components and makes the system highly testable.

#### 3. Factory Method Pattern
Each `UpgradeConfig` implements `InstantiateUpgrade()` — a factory method that creates the correct `Upgrade` subclass from its own config data, keeping instantiation logic close to the data that drives it.

#### 4. Observer Pattern (C# Events)
- `MoneyStorage` fires `OnMoneyChanged`, `OnMoneyEarned`, `OnMoneySpent`
- `Upgrade` fires `OnLevelUp`
- `UpgradesManager` fires `OnLevelUp`

This event-driven approach allows the UI and other systems to react to state changes without tight coupling.

#### 5. Prerequisite / Dependency System
Upgrades can declare **required upgrades** via `IUpgrade.AddRequirements()`. For example, `HealthUpgrade` checks that all required upgrades are at a higher level before allowing a level-up.

#### 6. Template Method Pattern
The abstract `Upgrade` base class defines the full `LevelUp()` algorithm (validation → price → increment → event), while concrete subclasses override `LevelUp(int level)` to add type-specific side effects.

---

### 📐 Class Diagram (simplified)

```
UpgradeCatalog (ScriptableObject)
    └── UpgradeConfig[] configs
            ├── DamageUpgradeConfig  ──► DamageUpgrade
            ├── HealthUpgradeConfig  ──► HealthUpgrade (implements IUpgrade)
            └── SpeedUpgradeConfig   ──► SpeedUpgrade

UpgradesManager
    ├── Dictionary<string, Upgrade>
    └── MoneyStorage

MoneyStorage
    ├── EarnMoney(int)
    ├── SpendMoney(int)
    └── Events: OnMoneyChanged, OnMoneyEarned, OnMoneySpent

Hero
    └── PlayerStats  (Dictionary<string, int>)
```

---

### 🚀 How to Open the Project

1. Install **Unity 2022.3 LTS** (or later).
2. Clone this repository:
   ```bash
   git clone https://github.com/MrRandomise/UpgradeManager.git
   ```
3. Open the project folder in **Unity Hub**.
4. Open the main scene located in `Assets/Scenes/`.
5. Enter Play mode to interact with the upgrade system via the debug UI.

---

### 📚 What I Learned

- Designing a **scalable upgrade system** that is easy to extend with new upgrade types
- Using **Zenject** for dependency injection in Unity projects
- Applying **design patterns** (Factory, Observer, Template Method, Strategy) in a game architecture context
- Leveraging **ScriptableObjects** for designer-friendly, code-free configuration
- Implementing an **event-driven UI** that reacts to model changes

---

---

## 🇷🇺 Русский

### Описание проекта

**UpgradeManager** — учебный проект по курсу [OTUS «Разработчик игр на Unity»](https://otus.ru/). Цель проекта — разработать гибкую, конфигурируемую **систему улучшений** игрового персонажа — типовой и необходимый модуль в RPG, action и roguelike играх.

Система позволяет тратить игровую валюту на прокачку характеристик персонажа: **урон**, **здоровье** и **скорость передвижения**. Улучшения поддерживают **цепочки зависимостей** (требования) и полностью настраиваются через ScriptableObjects в редакторе Unity.

---

### 🛠️ Технологический стек

| Технология | Назначение |
|---|---|
| **Unity 2022** | Игровой движок |
| **C# (.NET)** | Логика игры |
| **Zenject** | Фреймворк для внедрения зависимостей |
| **Odin Inspector** | Расширенные инструменты редактора Unity |
| **TextMeshPro** | Рендеринг текста в UI |
| **ScriptableObjects** | Конфигурация данных |

---

### 🏗️ Архитектура

Проект построен по принципам чистой архитектуры с чётким разделением ответственности.

- **Конфиги (ScriptableObject)** — данные об улучшениях, ценах и зависимостях
- **Upgrade / UpgradesManager** — ядро системы, бизнес-логика прокачки
- **MoneyStorage** — хранилище валюты с событийной моделью
- **PlayerStats** — динамический словарь характеристик персонажа
- **Zenject DI** — связывает все компоненты без жёстких зависимостей

---

### ✨ Реализованные паттерны проектирования

| Паттерн | Где применяется |
|---|---|
| **Factory Method** | `UpgradeConfig.InstantiateUpgrade()` — создание нужного типа улучшения |
| **Template Method** | `Upgrade.LevelUp()` — общий алгоритм с переопределяемым хуком |
| **Observer** | C#-события `OnLevelUp`, `OnMoneyChanged`, `OnMoneyEarned`, `OnMoneySpent` |
| **Dependency Injection** | Zenject — `MoneyStorage`, `UpgradesManager` как синглтоны |
| **Strategy / Interface** | `IUpgrade` — поведение «проверки требований» |

---

### 🚀 Как открыть проект

1. Установите **Unity 2022.3 LTS** или новее.
2. Склонируйте репозиторий:
   ```bash
   git clone https://github.com/MrRandomise/UpgradeManager.git
   ```
3. Откройте папку проекта в **Unity Hub**.
4. Откройте сцену из `Assets/Scenes/`.
5. Нажмите Play для взаимодействия с системой улучшений через отладочный UI.

---

### 📚 Что я изучил в проекте

- Проектирование **масштабируемой системы улучшений**, которую легко расширять новыми типами
- Применение **Zenject** для внедрения зависимостей в Unity-проектах
- Практическое использование **паттернов проектирования** в игровой архитектуре
- Настройка **ScriptableObjects** для удобного редактирования параметров дизайнерами без кода
- Реализация **событийного UI**, реагирующего на изменения модели

---

*Made with ❤️ as part of the OTUS Game Developer course.*
