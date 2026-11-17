# Lab3-27185-Expense-Track-System-DotNet

## ExpenseTrack System

A simple personal expense and budget tracker built with **Windows Forms (C#/.NET 10)** and **MySQL (XAMPP)**.

**Author:** Confiance UFITAMAHORO — ID: 27185

## Features

- Register and log in (passwords stored as salted hashes)
- Edit profile: phone, currency, photo
- Add, update and delete expenses with categories and tags
- Create tags and filter expenses by one or more tags
- Set monthly budgets per category
- Dashboard with totals, a budget-vs-actual chart and recent expenses

## Tech stack

- Windows Forms, .NET 10
- C# controller classes with `MySqlConnector` (ADO.NET)
- MySQL from XAMPP

## Setup

1. Start **MySQL** in the XAMPP Control Panel.
2. Open <http://localhost/phpmyadmin> → **Import** → choose `database.sql` → **Go**.
3. Open `ExpenseTrackSystem.sln` in Visual Studio and press **F5**.

Or from a terminal:

```bat
dotnet run --project ExpenseTrackSystem
```

The connection string in `ExpenseTrackSystem/Database.cs` is:

```csharp
Server=localhost;Database=expensetrack;User ID=root;Password=;
```

If your MySQL `root` user has a password, add it after `Password=`.

## Database tables

`users`, `user_profiles`, `categories`, `expenses`, `tags`, `expense_tags`, `budgets`.

Relationships: one profile per user, one-to-many users → categories/expenses/budgets, many-to-many expenses ↔ tags.

## First use

1. Click **Create account** and register.
2. On the **Expenses** tab, add a tag, then add an expense.
3. Set monthly limits on the **Budgets** tab.
4. Check spending and the chart on the **Dashboard**.
