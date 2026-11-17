-- ExpenseTrack System database
-- Import this file in phpMyAdmin (XAMPP) or run:
--   mysql -u root < database.sql

CREATE DATABASE IF NOT EXISTS expensetrack
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_general_ci;

USE expensetrack;

DROP TABLE IF EXISTS expense_tags;
DROP TABLE IF EXISTS budgets;
DROP TABLE IF EXISTS expenses;
DROP TABLE IF EXISTS tags;
DROP TABLE IF EXISTS categories;
DROP TABLE IF EXISTS user_profiles;
DROP TABLE IF EXISTS users;

-- One-to-one: User -> UserProfile
CREATE TABLE users (
    user_id       INT AUTO_INCREMENT PRIMARY KEY,
    username      VARCHAR(50)  NOT NULL UNIQUE,
    password_hash VARCHAR(200) NOT NULL,
    password_salt VARCHAR(100) NOT NULL,
    full_name     VARCHAR(100) NOT NULL,
    created_at    DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE user_profiles (
    profile_id INT AUTO_INCREMENT PRIMARY KEY,
    user_id    INT          NOT NULL UNIQUE,
    phone      VARCHAR(30)  NOT NULL DEFAULT '',
    currency   VARCHAR(10)  NOT NULL DEFAULT 'USD',
    photo_path VARCHAR(500) NOT NULL DEFAULT '',
    CONSTRAINT fk_profile_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE
);

-- One-to-many: User -> Category
CREATE TABLE categories (
    category_id   INT AUTO_INCREMENT PRIMARY KEY,
    user_id       INT         NOT NULL,
    category_name VARCHAR(80) NOT NULL,
    CONSTRAINT fk_category_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE,
    CONSTRAINT uq_category_name UNIQUE (user_id, category_name)
);

-- One-to-many: User -> Expense, Category -> Expense
CREATE TABLE expenses (
    expense_id   INT AUTO_INCREMENT PRIMARY KEY,
    user_id      INT           NOT NULL,
    category_id  INT           NOT NULL,
    title        VARCHAR(120)  NOT NULL,
    amount       DECIMAL(12,2) NOT NULL,
    expense_date DATE          NOT NULL,
    CONSTRAINT fk_expense_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE,
    CONSTRAINT fk_expense_category FOREIGN KEY (category_id)
        REFERENCES categories (category_id) ON DELETE RESTRICT
);

-- One-to-many: User -> Tag
CREATE TABLE tags (
    tag_id   INT AUTO_INCREMENT PRIMARY KEY,
    user_id  INT         NOT NULL,
    tag_name VARCHAR(50) NOT NULL,
    CONSTRAINT fk_tag_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE,
    CONSTRAINT uq_tag_name UNIQUE (user_id, tag_name)
);

-- Many-to-many: Expense <-> Tag
CREATE TABLE expense_tags (
    expense_id INT NOT NULL,
    tag_id     INT NOT NULL,
    PRIMARY KEY (expense_id, tag_id),
    CONSTRAINT fk_expense_tags_expense FOREIGN KEY (expense_id)
        REFERENCES expenses (expense_id) ON DELETE CASCADE,
    CONSTRAINT fk_expense_tags_tag FOREIGN KEY (tag_id)
        REFERENCES tags (tag_id) ON DELETE CASCADE
);

-- One-to-many: User -> Budget, Category -> Budget
CREATE TABLE budgets (
    budget_id    INT AUTO_INCREMENT PRIMARY KEY,
    user_id      INT           NOT NULL,
    category_id  INT           NOT NULL,
    budget_month INT           NOT NULL,
    budget_year  INT           NOT NULL,
    limit_amount DECIMAL(12,2) NOT NULL,
    CONSTRAINT fk_budget_user FOREIGN KEY (user_id)
        REFERENCES users (user_id) ON DELETE CASCADE,
    CONSTRAINT fk_budget_category FOREIGN KEY (category_id)
        REFERENCES categories (category_id) ON DELETE CASCADE,
    CONSTRAINT uq_budget UNIQUE (user_id, category_id, budget_month, budget_year)
);

-- Helpful indexes for the queries used by the application.
CREATE INDEX idx_expense_user_date ON expenses (user_id, expense_date);
CREATE INDEX idx_budget_user_period ON budgets (user_id, budget_year, budget_month);
