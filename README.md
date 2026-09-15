# Blood Bank Management System

Настольное приложение на C# (Windows Forms) для управления банком крови. Разработано в трехуровневой архитектуре (3-tier) в соответствии с техническим заданием.

---

## Содержание

- [Описание](#описание)
- [Возможности](#возможности)
- [Используемые технологии](#используемые-технологии)
- [Архитектура](#архитектура)
- [Требования](#требования)
- [Установка и запуск](#установка-и-запуск)
- [Структура проекта](#структура-проекта)
- [Описание модулей](#описание-модулей)
- [Тестовые учетные записи](#тестовые-учетные-записи)
- [Строка подключения](#строка-подключения)
- [Контроль версий](#контроль-версий)
- [Возможные ошибки и их решение](#возможные-ошибки-и-их-решение)
- [Лицензия](#лицензия)

---

## Описание

Blood Bank Management System — информационная система для автоматизации работы банка крови. Позволяет вести учет пользователей системы, регистрировать доноров, хранить информацию о группах крови и просматривать статистику по донорам в разрезе групп крови.

Приложение реализовано в трехуровневой архитектуре:

- Уровень представления — Windows Forms
- Уровень бизнес-логики (BLL) — валидация и правила
- Уровень доступа к данным (DAL) — SQL-запросы к MS SQL Server

Проект разработан в учебных целях и демонстрирует работу с:
- Windows Forms
- Трехуровневой архитектурой
- MS SQL Server
- ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter)
- Git и GitHub

---

## Возможности

1. Управление пользователями (добавление, обновление, поиск, удаление)
2. Простая аутентификация (вход и выход из системы)
3. Разграничение прав доступа (Admin / User)
4. Управление донорами (добавление, обновление, поиск, удаление)
5. Фильтрация доноров по группе крови
6. Панель управления для просмотра доноров по группам крови
7. Отображение общей статистики (количество доноров, пользователей, групп крови)

---

## Используемые технологии

| Технология | Версия | Назначение |
|------------|--------|------------|
| C# | .NET Framework 4.7.2 и выше | Язык программирования |
| Windows Forms | — | Графический интерфейс |
| MS SQL Server | 2014 и выше | Система управления базами данных |
| ADO.NET | — | Доступ к данным |
| Microsoft Visual Studio | 2015 и выше | Среда разработки |
| Git | любая | Система контроля версий |
| GitHub | — | Удаленный репозиторий |

---

## Архитектура

Проект разделен на три независимых проекта:

```
BloodBank   --->   BloodBank.BLL   --->   BloodBank.DAL   --->   SQL Server
(формы)               (логика)               (данные)               (БД)
```

Каждый уровень изолирован и общается только с соседним:

- BloodBank ссылается на BloodBank.BLL
- BloodBank.BLL ссылается на BloodBank.DAL
- BloodBank.DAL работает напрямую с базой данных

Правило зависимостей:

| Проект | Ссылается на |
|--------|--------------|
| BloodBank | BloodBank.BLL |
| BloodBank.BLL | BloodBank.DAL |
| BloodBank.DAL | (ни на что) |

---

## Требования

Перед началом работы убедитесь, что установлено:

- Microsoft Visual Studio 2015 или выше
- Компонент ".NET desktop development" в Visual Studio
- MS SQL Server 2014 или выше (Express, Developer, Standard)
- SQL Server Management Studio (SSMS)
- .NET Framework 4.7.2 или выше
- Git (опционально)

---

## Установка и запуск

### Шаг 1. Клонирование репозитория

```
git clone https://github.com/Kiwinze/BloodBank.git
cd BloodBank
```

### Шаг 2. Создание базы данных

1. Откройте SQL Server Management Studio
2. Подключитесь к вашему экземпляру SQL Server
3. Откройте файл Database/BloodBankDB.sql
4. Выполните скрипт (F5)

Скрипт создаст:

- Базу данных BloodBankDB
- Таблицы Users и Donors
- Тестовые данные (пользователи и доноры)
- Хранимые процедуры sp_LoginCheck, sp_BloodGroupStats

### Шаг 3. Настройка строки подключения

Откройте файл BloodBank.DAL/DbConnection.cs и измените строку подключения:

```
public static readonly string ConnectionString =
    @"Data Source=.\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True;";
```

Варианты строки подключения:

| Сценарий | Строка подключения |
|----------|-------------------|
| Локальный экземпляр по умолчанию | Data Source=localhost;Initial Catalog=BloodBankDB;Integrated Security=True; |
| Именованный экземпляр SQLEXPRESS | Data Source=.\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True; |
| С логином и паролем | Data Source=localhost;Initial Catalog=BloodBankDB;User ID=sa;Password=ваш_пароль; |

### Шаг 4. Открытие решения

1. Откройте файл BloodBank.sln в Visual Studio
2. Убедитесь, что все три проекта в решении:
   - BloodBank
   - BloodBank.BLL
   - BloodBank.DAL
3. Проверьте ссылки между проектами:
   - BloodBank.UI ссылается на BloodBank.BLL
   - BloodBank.BLL ссылается на BloodBank.DAL

### Шаг 5. Назначение запускаемого проекта

1. В Solution Explorer нажмите правой кнопкой по проекту BloodBank.UI
2. Выберите "Назначить запускаемым проектом" (Set as StartUp Project)
3. Название проекта станет жирным

### Шаг 6. Запуск

Нажмите F5 или зеленую кнопку "Start". Откроется форма входа.

---

## Структура проекта

```
BloodBank.sln
|
+-- BloodBank/                       Проект UI (WinForms)
|   +-- frmLogin.cs
|   +-- frmLogin.Designer.cs
|   +-- frmMain.cs
|   +-- frmMain.Designer.cs
|   +-- frmUsers.cs
|   +-- frmUsers.Designer.cs
|   +-- frmDonors.cs
|   +-- frmDonors.Designer.cs
|   +-- frmDashboard.cs
|   +-- frmDashboard.Designer.cs
|   +-- Program.cs
|   +-- Properties/
|   +-- BloodBank.UI.csproj
|
+-- BloodBank.BLL/                      Проект бизнес-логики
|   +-- LoginBLL.cs
|   +-- UserBLL.cs
|   +-- DonorBLL.cs
|   +-- DashboardBLL.cs
|   +-- BloodBank.BLL.csproj
|
+-- BloodBank.DAL/                      Проект доступа к данным
|   +-- DbConnection.cs
|   +-- LoginDAL.cs
|   +-- UserDAL.cs
|   +-- DonorDAL.cs
|   +-- DashboardDAL.cs
|   +-- BloodBank.DAL.csproj
|
+-- README.md
+-- .gitignore
```

---

## Описание модулей

### BloodBank

| Форма | Назначение |
|-------|------------|
| frmLogin | Форма входа в систему |
| frmMain | Главное окно с боковым меню |
| frmUsers | Управление пользователями системы |
| frmDonors | Управление донорами |
| frmDashboard | Панель управления со статистикой |

### BloodBank.BLL

| Класс | Назначение |
|-------|------------|
| LoginBLL | Проверка данных для входа |
| UserBLL | Бизнес-логика пользователей (валидация) |
| DonorBLL | Бизнес-логика доноров (валидация возраста и т.д.) |
| DashboardBLL | Получение статистики |

### BloodBank.DAL

| Класс | Назначение |
|-------|------------|
| DbConnection | Единая точка подключения к БД |
| LoginDAL | SQL-запросы для входа |
| UserDAL | SQL-запросы для пользователей (CRUD) |
| DonorDAL | SQL-запросы для доноров (CRUD, фильтр) |
| DashboardDAL | SQL-запросы статистики |

---

## Тестовые учетные записи

После выполнения SQL-скрипта в базе будут созданы две учетные записи:

| Логин | Пароль | Тип пользователя | Доступ |
|-------|--------|------------------|--------|
| admin | admin | Admin | Полный доступ |
| user | user | User | Без модуля "Пользователи" |

---

## Строка подключения

Примеры строк подключения для разных сценариев:

```
// Windows-аутентификация, локальный сервер
Data Source=localhost;Initial Catalog=BloodBankDB;Integrated Security=True;

// Windows-аутентификация, SQLEXPRESS
Data Source=.\SQLEXPRESS;Initial Catalog=BloodBankDB;Integrated Security=True;

// SQL-аутентификация
Data Source=localhost;Initial Catalog=BloodBankDB;User ID=sa;Password=YourPassword;
```

---

## Сборка и публикация

### Отладочная сборка

1. Меню "Сборка" -> "Очистить решение"
2. Меню "Сборка" -> "Пересобрать решение"
3. Нажмите F5

### Релизная сборка

1. В Solution Explorer правой кнопкой по проекту BloodBank.UI
2. Выберите "Свойства" -> вкладка "Сборка"
3. Смените конфигурацию на Release
4. Меню "Сборка" -> "Пересобрать решение"
5. Готовый .exe будет в папке BloodBank.UI/bin/Release/

---

## Возможные ошибки и их решение

| Ошибка | Причина | Решение |
|--------|---------|---------|
| Cannot open database "BloodBankDB" | База данных не создана | Выполните SQL-скрипт BloodBankDB.sql |
| Login failed for user | Неверная строка подключения | Проверьте ConnectionString в DbConnection.cs |
| Error 26 - Error Locating Server/Instance | Неверное имя сервера | Укажите правильный Data Source |
| Тип или имя пространства имен "BLL" не существует | Нет ссылки на проект | Добавьте ссылку UI -> BLL через Add Reference |
| Тип или имя пространства имен "DAL" не существует | Нет ссылки на проект | Добавьте ссылку BLL -> DAL через Add Reference |
| Не удалось найти файл метаданных "BloodBank.BLL.dll" | Проект BLL не собирается | Соберите BLL отдельно, исправьте его ошибки |
| Проект, создающий библиотеку классов, не может быть запущен | Стартовый проект — BLL или DAL | Назначьте стартовым BloodBank.UI |
| Неоднозначность между frmXxx.xxx и frmXxx.xxx | Дублирование класса в Designer-файле | Переименуйте класс в Designer-файле |

---

## Лицензия

Проект разработан в учебных целях. Лицензия MIT.

Copyright (c) 2026 Blood Bank Management System

Разрешается свободное использование, копирование, изменение и распространение данного программного обеспечения при условии сохранения уведомления об авторских правах.
