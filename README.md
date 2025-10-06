# 💳 CreditLab

**CreditLab** — модульная платформа-симулятор кредитной экосистемы (набор API).  
Проект служит учебной/тестовой площадкой для моделирования: получение профиля по SSN, расчёт FICO-подобного скоринга, отправка заявки в сеть банков и агрегация ответов.

> Вся структура и имена в README соответствуют решению: `CreditLab.sln`  
> Проекты:
> - `MediatorServer` — (наш сервер)
> - `CreditDataHub.API` — источник/хранилище профилей
> - `FiscoEmulator.API` — эмулятор скоринга
> - `BankingEmulator.API` — эмулятор банков
> - `Shared.Core` — общие DTO/интерфейсы/сущности
> - `Shared.Infrastructure` — общий логгер/расширения/утилиты
> - `Shared.Tests` — место для unit-тестов (xUnit)

---

## 🔎 Быстрый обзор архитектуры

CreditLab (Solution)

│

├── CreditDataHub.API → Эмулирует внешний источник кредитных данных (SSN, доход, долги, история)

├── FiscoEmulator.API → Рассчитывает кредитный рейтинг (эмулятор FICO® Score)

├── BankingEmulator.API → Эмулирует банки, предлагающие кредиты по скорингу клиента

├── MediatorServer → Центральный сервер, который связывает все API и моделирует оплату за запросы

│

├── Shared.Core → Общие DTO, интерфейсы, доменные модели

├── Shared.Infrastructure → Логирование, мидлвары, инфраструктурные компоненты

├── Shared.Tests → Подготовлен для unit-тестов (xUnit)

│

└── README.md # Этот файл 😎

---

## 🧩 Что делает каждый сервис

- **CreditDataHub.API**
  - GET `/api/customer/{ssn}` — возвращает профиль клиента (если нет — генерирует, сохраняет в БД и возвращает).
  - Подключён EF Core (Postgres) для хранения профилей.
  - (Опционально) эндпоинты для платежей/баланса или админ-операций.

- **FiscoEmulator.API**
  - POST `/api/score` — принимает `CustomerProfileDto`, возвращает `FiscoScoreResultDto` (score, факторы, рейтинг).

- **BankingEmulator.API**
  - POST `/api/bank/request` — принимает `CreditRequestDto` (tempId, ssn, score, requestedAmount) и возвращает список `CreditOfferDto`.

- **MediatorServer**
  - GET `/api/credit/check?ssn={ssn}&amount={amount}` — orchestration:
    1. запрашивает профиль у `CreditDataHub`,
    2. отправляет профиль в `FiscoEmulator`,
    3. публикует заявку в `BankingEmulator`,
    4. логирует, списывает плату (эмуляция) и возвращает агрегированный результат.

---

## 📦 Технологии и зависимости

- .NET 8 (C#)
- EF Core + Npgsql (PostgreSQL)
- Swagger / OpenAPI
- Dependency Injection (built-in)
- Logging: `Shared.Infrastructure` → `IAppLogger<T>` + Request logging middleware
- Тестирование: xUnit (готово в `Shared.Tests`)

---

## 🚀 Как развернуть локально (быстрое руководство)

### 1) Клонировать репозиторий
```bash
git clone <your-repo-url> CreditLab
cd CreditLab
```

### 2) Установить PostgreSQL (через pgAdmin / локально / Docker)
Создать базу: `CreditDataDb`
Запомнить/указать пользователя и пароль

### 3) Настроить appsettings.json
Во всех API, которые используют Postgres (`CreditDataHub.API`), в `appsettings.json` указать:
```json
{
  "ConnectionStrings": {
    "PostgresConnection": "Host=localhost;Port=5432;Database=CreditDataDb;Username=postgres;Password=yourpassword"
  }
}
```

### 4) Установить зависимости и собрать
```bash
dotnet restore
dotnet build
```

### 5) Применить миграции для `CreditDataHub.API`
(в каталоге решения или корня)
```bash
dotnet ef migrations add InitialCreate -p CreditDataHub.API -s CreditDataHub.API
dotnet ef database update -p CreditDataHub.API -s CreditDataHub.API
```
>Если миграции уже есть — достаточно `dotnet ef database update`.

### 6) Запуск сервисов (каждый в своей консоли)
Примеры (порты настраиваются в `launchSettings.json` или `Program.cs`):
```bash
dotnet run --project CreditDataHub.API
dotnet run --project FiscoEmulator.API
dotnet run --project BankingEmulator.API
dotnet run --project MediatorServer
```

### 7) Открыть Swagger UI
Мы настраиваем Swagger UI так, чтобы он открывался по корню (`RoutePrefix = string.Empty`) в режиме разработки.
Открой браузер:
- `https://localhost:{port-of-MediatorServer}/` — MediatorServer Swagger
- Аналогично для других API (их ports указаны в `launchSettings.json`)

---

## 🛠 Дополнительные рекомендации / next steps

- Добавить Redis для распределённого кэширования (если будете запускать в нескольких инстансах).
- Добавить Serilog (sink) для записи логов в файл / ELK / Seq / Application Insights.
- Добавить Health Checks (Microsoft.AspNetCore.Diagnostics.HealthChecks).
- Покрыть ключевые сервисы unit-тестами (xUnit + Moq).
- Подготовить docker-compose.yml для локального запуска всех сервисов + Postgres + Redis.
