<p align="center">
  <img src="https://img.icons8.com/?size=512&id=55494&format=png" width="100" />
</p>
<p align="center">
    <h1 align="center">LESSONMANAGEMENT</h1>
</p>

This project is designed to assist teachers in managing their lessons efficiently. Key features include:

* **Lesson Management**: Keep track of lesson subjects, notes, and student information.

<p align="center">
    <img width="550" height="300" src="https://raw.githubusercontent.com/pheliperost/pheliperost/main/gifsdocumentation/calendar.gif" alt="Calendar GIF">
</p>


* **Pricing**: Easily manage and update lesson prices.


<p align="center">
    <img width="550" height="250" src="https://raw.githubusercontent.com/pheliperost/pheliperost/main/gifsdocumentation/eventtype.gif" alt="Calendar GIF">
</p>

<p align="center">
    <img width="550" height="250" src="https://raw.githubusercontent.com/pheliperost/pheliperost/main/gifsdocumentation/editfromcalendar.gif" alt="Calendar GIF">
</p>

* **Reporting**: Generate detailed reports for lessons provided to third parties, such as schools. These reports include information on all lessons conducted within a specific period and the corresponding earnings.
By utilizing this tool, teachers can streamline their administrative tasks and focus more on delivering quality education.

<p align="center">
    <img width="550" height="250" src="https://raw.githubusercontent.com/pheliperost/pheliperost/main/gifsdocumentation/conciliation.gif" alt="Calendar GIF">
</p>

* **Conciliation**: This feature allows you to import .txt files containing lesson data provided by third parties (such as schools or educational platforms). The software then performs a reconciliation process, ensuring that the imported lessons match your recorded lessons in terms of execution date, price, duration, student, and lesson type. This helps maintain data consistency and accuracy between your records and those of external partners.


## 💻 Technologies 

### Archicteture
* .Net Core MVC.

This project was built with:
* .Net Core 2.2.
* MS SQL Server. 

using the libraries:
* AutoMapper
* FluentValidation
* FullCalendar
* Bogus
* Moq
* AutoMoq
* Fluent Assertions
* EFCore.BulkExtensions
* EntityFrameworkCre

The Language used was **C# version 7.3**.

## 🔧 Project Dependencies 	

These are the required dependencies to run the project properly:

### MVC Project

* Microsoft.AspNetCore.App 2.2.0
* AutoMapper 8.1.0
* AutoMapper.Extensions.Microsoft.DependencyInjection 6.1.0
* FluentValidation 8.6.2
* FullCalendar 3.9.0
* EFCore.BulkExtensions 2.5.0
* Microsoft.EntityFrameworkCore 2.2.4
* Microsoft.EntityFrameworkCore.Relational 2.2.4
* Microsoft.EntityFrameworkCore.SqlServer 2.2.4

### Tests Projects

* Microsoft.AspNetCore.App 2.2.0
* Microsoft.AspNetCore.Mvc.Testing 2.2.0
* Microsoft.NET.Test.Sdk 16.0.1
* Bogus 20.0.2
* FluentAssertions 6.12.0
* Moq 4.13.0
* Moq.AutoMock 1.2.0.120
* Xunit 2.4.0
* Xunit.Runner.Visualstudio 2.4.0

### Database Requirements

* Sql Server 2019.

## 🚀 Getting Started

### ⚙️ Installation

1. Clone the LessonManagement repository:

```sh
git clone https://github.com/pheliperost/LessonManagement
```

2. Change to the project directory:

```sh
cd LessonManagement
```

3. Install the dependencies:

```sh
dotnet build
```




### 🤖 Apply Migrations and Running the Project

To create all database entities necessary for LessonManagement to run properly, follow these steps:

1. Navigate to the folder where the project was cloned and open `LessonManagement.sln` with Visual Studio.
2. Change your ConnectionString to your database in `LessonsManagement.App/appsettings.json`.
3. Navigate to `Tools` > `NuGet Package Manager` > `Package Manager Console`.
4. Ensure the `LessonManagement.Data` project is selected as the default project in the Package Manager Console.
5. Run the following command:

    ```sh
    update-database -Context DataDbContext
    ```

6. In the `Package Manager Console` window, ensure the `LessonManagement.App` project is selected as the default project.
7. Run the following command:

    ```sh
    update-database -Context ApplicationDbContext
    ```

8. Press `F5` to run the project.

**Note**: To access the system, you need to create a user account due to the identity security features implemented in the LessonManagement project.



### 🧪 Tests

To execute tests, navigate to `LessonsManagement\test\TestXUnit.Tests` or `LessonsManagement\test\IntegrationTestsXUnitApp.Tests` and run:

```sh
dotnet test
```

---


## ⏭️ Next Steps

### General
* Develop a curriculum roadmap outlining essential subjects for all students and track their progression.
* Implement a mobile offline version of the application to ensure usability without internet connectivity.
* Integrate a WebAPI version (Currently in Development) to extend functionality and facilitate integration with other systems.
* Design and implement a streamlined, user-friendly interface to enhance ease of use and accessibility.

### Conciliation Report
* Allow exporting the result to Excel format.
* Enable send conciliation report via email.
* Rethink the report layout to make it cleaner.
* Support different file formats for the conciliation module.


