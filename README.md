# Lab3-27185-Expense-Track-System-DotNet

## ExpenseTrack System

Personal Expense & Budget Management System built with **Windows Forms (C#/.NET 10)** and **MySQL (XAMPP)**.

Prepared by: Confiance UFITAMAHORO | ID: 27185

## Features

- User registration and login with salted, hashed passwords (PBKDF2-SHA256)
- Profile page with full name, phone, preferred currency and optional photo
- Custom categories, with five starter categories created for every new account
- Add, edit and delete expenses (title, amount, date, category)
- Create tags and attach several tags to one expense
- Filter the expense list by **one or more tags**
- Monthly budget limits per category, with spent and remaining amounts
- Dashboard with total spent, total budget, remaining amount, a budget-vs-actual bar chart and recent expenses
- Every record is scoped to the logged-in user

## Tech stack

| Layer | Technology |
| --- | --- |
| Desktop UI | Windows Forms, .NET 10 (`net10.0-windows`) |
| Service layer | Plain C# controller classes |
| Data access | `MySqlConnector` 2.6.2 (ADO.NET, parameterized SQL) |
| Database | MySQL from XAMPP |

> **Note about EF Core:** the lab brief mentions Entity Framework Core, but this build deliberately follows the reference `StudentManagementSystem` project, which uses `MySqlConnector` directly. That keeps the code short, explicit and easy to explain in a lab defence. The forms do not change if the controllers are later replaced with EF Core.

## Project structure

```
LAB3/
├─ ExpenseTrackSystem.sln
├─ database.sql
├─ README.md
└─ ExpenseTrackSystem/
   ├─ ExpenseTrackSystem.csproj
   ├─ Program.cs
   ├─ Database.cs                 (connection string)
   ├─ PasswordHelper.cs           (salt + PBKDF2 hash)
   ├─ Session.cs                  (current logged-in user)
   ├─ User.cs / UserProfile.cs / Category.cs / Expense.cs / Budget.cs / Tag.cs
   ├─ UserController.cs
   ├─ ProfileController.cs
   ├─ CategoryController.cs
   ├─ ExpenseController.cs
   ├─ TagController.cs
   ├─ BudgetController.cs
   ├─ LoginForm.cs / LoginForm.Designer.cs
   ├─ RegisterForm.cs / RegisterForm.Designer.cs
   └─ MainForm.cs / MainForm.Designer.cs
```

The structure is intentionally the same style as the reference project: one class per file, simple controllers, Windows Forms with `InitializeComponent`, and no extra architecture layers.

## Setup

### 1. Start MySQL

Open the XAMPP Control Panel and start **MySQL** (Apache is not needed for this desktop app).

### 2. Create the database

**Option A – phpMyAdmin**

1. Open <http://localhost/phpmyadmin>
2. Click **Import**
3. Choose `database.sql` from this folder and click **Go**

**Option B – command line**

```bat
cd C:\Users\SAINT\Documents\DOT-NET\LAB3
C:\xampp\mysql\bin\mysql.exe -u root < database.sql
```

The script creates the `expensetrack` database and all tables. It also drops/recreates the tables, so only run it again when you want to reset the data.

### 3. Check the connection string

Open `ExpenseTrackSystem\Database.cs`:

```csharp
public const string ConnectionString =
    "Server=localhost;Database=expensetrack;User ID=root;Password=;";
```

XAMPP's default MySQL user is `root` with an empty password. If you set a MySQL password, put it after `Password=`.

### 4. Run the application

Open `ExpenseTrackSystem.sln` in Visual Studio 2022 (or newer) and press **F5**.

Or from a terminal:

```bat
dotnet run --project ExpenseTrackSystem
```

`MySqlConnector` is restored automatically from NuGet.

## First use

1. Click **Create account** and register.
2. Your account starts with the categories **Bills, Food, Other, Shopping, Transport**.
3. Open **Expenses**, type a new tag (for example `vacation`), and click **Add tag**.
4. Add an expense, tick one or more tags, then click **Add**.
5. Click a row in the grid to load it into the form for **Update** or **Delete**.
6. In **Budgets**, choose a category, month, year and limit, then click **Save budget**.
7. In **Dashboard**, choose the month/year and click **Refresh** to see totals and the budget-vs-actual chart.
8. Use **Profile** to change your details, currency or photo.

## Database tables

| Table | Purpose |
| --- | --- |
| `users` | Login account (username, password hash, salt, full name) |
| `user_profiles` | One profile per user (phone, currency, photo path) |
| `categories` | Categories owned by a user |
| `expenses` | Expenses owned by a user and grouped by category |
| `tags` | Tags owned by a user |
| `expense_tags` | Many-to-many join table between expenses and tags |
| `budgets` | Monthly limit per user + category |

Relationships: `User 1:1 UserProfile`, `User 1:N Category/Expense/Budget`, `Category 1:N Expense/Budget`, `Expense M:N Tag`.

## Behaviour notes

- Passwords are never stored in plain text. A random salt is generated per account and the password is hashed with PBKDF2-SHA256 (100,000 iterations).
- Deleting a category is blocked while expenses still use it; its budgets are removed automatically.
- Saving a budget for the same category/month/year updates the existing limit instead of creating a duplicate.
- The tag filter uses **all** checked tags, so checking `vacation` and `family` returns expenses that have both tags.
- The chart is drawn with a simple `Paint` handler, so no charting package is required.

## Troubleshooting

| Problem | Fix |
| --- | --- |
| `Unable to connect to any of the specified MySQL hosts` | Start MySQL in XAMPP. |
| `Access denied for user 'root'@'localhost'` | Add your MySQL password to `Database.cs`. |
| `Unknown database 'expensetrack'` | Import `database.sql`. |
| `The type or namespace name 'MySqlConnector' could not be found` | Restore NuGet packages (right-click the project → **Restore NuGet Packages**). |
| Login says wrong password | Passwords are case-sensitive; register a new account if needed. |
