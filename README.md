<p align="center">
  <img src="https://img.icons8.com/?size=512&id=55494&format=png" width="100" />
</p>
<p align="center">
    <h1 align="center">LESSONMANAGEMENT</h1>
</p>
<p align="center">
    <em><code>► INSERT-TEXT-HERE</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/pheliperost/LessonManagement?style=flat&color=0080ff" alt="license">
	<img src="https://img.shields.io/github/last-commit/pheliperost/LessonManagement?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/pheliperost/LessonManagement?style=flat&color=0080ff" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/pheliperost/LessonManagement?style=flat&color=0080ff" alt="repo-language-count">
<p>
<p align="center">
		<em>Developed with the software and tools below.</em>
</p>
<p align="center">
	<img src="https://img.shields.io/badge/JavaScript-F7DF1E.svg?style=flat&logo=JavaScript&logoColor=black" alt="JavaScript">
	<img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON">
</p>
<hr>

## 🔗 Quick Links

> - [📍 Overview](#-overview)
> - [📦 Features](#-features)
> - [📂 Repository Structure](#-repository-structure)
> - [🧩 Modules](#-modules)
> - [🚀 Getting Started](#-getting-started)
>   - [⚙️ Installation](#️-installation)
>   - [🤖 Running LessonManagement](#-running-LessonManagement)
>   - [🧪 Tests](#-tests)
> - [🛠 Project Roadmap](#-project-roadmap)
> - [🤝 Contributing](#-contributing)
> - [📄 License](#-license)
> - [👏 Acknowledgments](#-acknowledgments)

---

## 📍 Overview

<code>► INSERT-TEXT-HERE</code>

---

## 📦 Features

<code>► INSERT-TEXT-HERE</code>

---

## 📂 Repository Structure

```sh
└── LessonManagement/
    └── LessonsManagement
        ├── LessonsManagement.sln
        ├── sql
        │   ├── Consulta.sql
        │   ├── Criacao tabelas ApplicationDbContext.sql
        │   ├── Criacao tabelas DataDbContext.sql
        │   └── Import Students.sql
        ├── src
        │   ├── LessonsManagement.App
        │   │   ├── Areas
        │   │   │   └── Identity
        │   │   ├── AutoMapper
        │   │   │   └── AutoMapperConfig.cs
        │   │   ├── Configurations
        │   │   │   ├── DependencyInjectionConfig.cs
        │   │   │   ├── GlobalizationConfig.cs
        │   │   │   ├── IdentityConfig.cs
        │   │   │   └── MVCConfig.cs
        │   │   ├── Controllers
        │   │   │   ├── BaseController.cs
        │   │   │   ├── EventTypeController.cs
        │   │   │   ├── FileImportedController.cs
        │   │   │   ├── HomeController.cs
        │   │   │   ├── LessonsController.cs
        │   │   │   ├── LessonsImportedController.cs
        │   │   │   └── StudentsController.cs
        │   │   ├── Data
        │   │   │   ├── ApplicationDbContext.cs
        │   │   │   └── Migrations
        │   │   ├── Extensions
        │   │   │   ├── CustomAuthorization.cs
        │   │   │   ├── DisableElementByClaimTagHelper.cs
        │   │   │   ├── MoedaAttribute.cs
        │   │   │   ├── RazorExtensions.cs
        │   │   │   ├── RemoveElementByClaimTagHelper.cs
        │   │   │   └── SummaryViewComponent.cs
        │   │   ├── LessonsManagement.App.csproj
        │   │   ├── Program.cs
        │   │   ├── Properties
        │   │   │   ├── launchSettings.json
        │   │   │   ├── serviceDependencies.json
        │   │   │   └── serviceDependencies.local.json
        │   │   ├── Startup.cs
        │   │   ├── StartupWebTests.cs
        │   │   ├── ViewModels
        │   │   │   ├── ErrorViewModel.cs
        │   │   │   ├── EventTypeViewModel.cs
        │   │   │   ├── FileImportedViewModel.cs
        │   │   │   ├── LessonImportedViewModel.cs
        │   │   │   ├── LessonViewModel.cs
        │   │   │   └── StudentViewModel.cs
        │   │   ├── Views
        │   │   │   ├── EventType
        │   │   │   ├── FileImported
        │   │   │   ├── Home
        │   │   │   ├── Lessons
        │   │   │   ├── LessonsImported
        │   │   │   ├── Shared
        │   │   │   ├── Students
        │   │   │   ├── _ViewImports.cshtml
        │   │   │   └── _ViewStart.cshtml
        │   │   ├── appsettings.Development.json
        │   │   ├── appsettings.Testing.Development.json
        │   │   ├── appsettings.Testing.json
        │   │   ├── appsettings.json
        │   │   ├── libman.json
        │   │   └── wwwroot
        │   │       ├── css
        │   │       ├── favicon.ico
        │   │       ├── js
        │   │       └── lib
        │   ├── LessonsManagement.Business
        │   │   ├── Conciliation
        │   │   │   ├── ConciliationList.cs
        │   │   │   ├── Divergencies
        │   │   │   ├── DivergencyRow.cs
        │   │   │   └── Match.cs
        │   │   ├── FileImporter
        │   │   │   └── ImporterTxtFile.cs
        │   │   ├── Interfaces
        │   │   │   ├── IEventTypeRepository.cs
        │   │   │   ├── IEventTypeService.cs
        │   │   │   ├── IFileImportedRepository.cs
        │   │   │   ├── IFileImportedService.cs
        │   │   │   ├── ILessonImportedRepository.cs
        │   │   │   ├── ILessonImportedService.cs
        │   │   │   ├── ILessonRepository.cs
        │   │   │   ├── ILessonsService.cs
        │   │   │   ├── INotifyer.cs
        │   │   │   ├── IRepository.cs
        │   │   │   ├── IStudentRepository.cs
        │   │   │   └── IStudentService.cs
        │   │   ├── LessonsManagement.Business.csproj
        │   │   ├── Models
        │   │   │   ├── CalendarModel.cs
        │   │   │   ├── Entity.cs
        │   │   │   ├── EventType.cs
        │   │   │   ├── FileImported.cs
        │   │   │   ├── Lesson.cs
        │   │   │   ├── LessonImported.cs
        │   │   │   ├── Student.cs
        │   │   │   └── Validations
        │   │   ├── Notifications
        │   │   │   ├── Notification.cs
        │   │   │   └── Notifyer.cs
        │   │   ├── Services
        │   │   │   ├── BaseService.cs
        │   │   │   ├── EventTypeService.cs
        │   │   │   ├── FileImportedService.cs
        │   │   │   ├── LessonImportedService.cs
        │   │   │   ├── LessonsService.cs
        │   │   │   └── StudentsService.cs
        │   │   └── Utils
        │   │       ├── DateOperations.cs
        │   │       └── Operations.cs
        │   └── LessonsManagemente.Data
        │       ├── Class1.cs
        │       ├── Context
        │       │   └── DataDbContext.cs
        │       ├── LessonsManagement.Data.csproj
        │       ├── Mappings
        │       │   ├── DataBaseTypes.cs
        │       │   ├── EventTypeMapping.cs
        │       │   ├── FileImportedMapping.cs
        │       │   ├── LessonImportedMapping.cs
        │       │   ├── LessonsMapping.cs
        │       │   └── StudentMapping.cs
        │       ├── Migrations
        │       │   ├── 20240206230510_Initial.Designer.cs
        │       │   ├── 20240206230510_Initial.cs
        │       │   ├── 20240219181708_AddNotesFieldIntoLessonsTable.Designer.cs
        │       │   ├── 20240219181708_AddNotesFieldIntoLessonsTable.cs
        │       │   ├── 20240220190243_Creating EventType Table.Designer.cs
        │       │   ├── 20240220190243_Creating EventType Table.cs
        │       │   ├── 20240220204525_Add DurationTimeInMinutes into EventType Table.Designer.cs
        │       │   ├── 20240220204525_Add DurationTimeInMinutes into EventType Table.cs
        │       │   ├── 20240221220759_Changing name field DurationTimeInMinutes into EventType Table.Designer.cs
        │       │   ├── 20240221220759_Changing name field DurationTimeInMinutes into EventType Table.cs
        │       │   ├── 20240305232509_changing required field (Lesson).Designer.cs
        │       │   ├── 20240305232509_changing required field (Lesson).cs
        │       │   ├── 20240312190918_Table FileImported and LessonImported.Designer.cs
        │       │   ├── 20240312190918_Table FileImported and LessonImported.cs
        │       │   ├── 20240314022847_changing FileImported.Designer.cs
        │       │   ├── 20240314022847_changing FileImported.cs
        │       │   ├── 20240315001439_change fileimported.Designer.cs
        │       │   ├── 20240315001439_change fileimported.cs
        │       │   ├── 20240315045045_fix date fileimported.Designer.cs
        │       │   ├── 20240315045045_fix date fileimported.cs
        │       │   ├── 20240315045606_fix filepath character length - fileimported.Designer.cs
        │       │   ├── 20240315045606_fix filepath character length - fileimported.cs
        │       │   ├── 20240322183046_changing lessonimported properties.Designer.cs
        │       │   ├── 20240322183046_changing lessonimported properties.cs
        │       │   └── DataDbContextModelSnapshot.cs
        │       └── Repository
        │           ├── EventTypeRepository.cs
        │           ├── FileImportedRepository.cs
        │           ├── LessonImportedRepository.cs
        │           ├── LessonRepository.cs
        │           ├── Repository.cs
        │           └── StudentRepository.cs
        └── test
            ├── IntegrationTestsXUnitApp.Tests
            │   ├── Config
            │   │   └── IntegrationTestsFixture.cs
            │   ├── IntegrationTestsXUnitApp.Tests.csproj
            │   ├── LessonsManagementAppFactory.cs
            │   └── UserTests.cs
            └── TestXUnit.Tests
                ├── DateOperationsTests.cs
                ├── DateParamOverlap.cs
                ├── EventTypeServicesTests.cs
                ├── Fixtures
                │   ├── EventTypeFixtures.cs
                │   ├── EventTypesNamesEnum.cs
                │   ├── LessonsFixtures.cs
                │   └── StudentFixtures.cs
                ├── LessonsServicesTests.cs
                ├── StudentServicesTests.cs
                └── TestXUnitBusiness.Tests.csproj
```

---

## 🧩 Modules

<details closed><summary>LessonsManagement</summary>

| File                                                                                                                         | Summary                         |
| ---                                                                                                                          | ---                             |
| [LessonsManagement.sln](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/LessonsManagement.sln) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.test.TestXUnit.Tests</summary>

| File                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                 | ---                             |
| [TestXUnitBusiness.Tests.csproj](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/TestXUnitBusiness.Tests.csproj) | <code>► INSERT-TEXT-HERE</code> |
| [DateParamOverlap.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/DateParamOverlap.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [LessonsServicesTests.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/LessonsServicesTests.cs)               | <code>► INSERT-TEXT-HERE</code> |
| [EventTypeServicesTests.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/EventTypeServicesTests.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [StudentServicesTests.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/StudentServicesTests.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.test.TestXUnit.Tests.Fixtures</summary>

| File                                                                                                                                                         | Summary                         |
| ---                                                                                                                                                          | ---                             |
| [StudentFixtures.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/Fixtures/StudentFixtures.cs)         | <code>► INSERT-TEXT-HERE</code> |
| [LessonsFixtures.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/Fixtures/LessonsFixtures.cs)         | <code>► INSERT-TEXT-HERE</code> |
| [EventTypesNamesEnum.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/Fixtures/EventTypesNamesEnum.cs) | <code>► INSERT-TEXT-HERE</code> |
| [EventTypeFixtures.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/TestXUnit.Tests/Fixtures/EventTypeFixtures.cs)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.test.IntegrationTestsXUnitApp.Tests</summary>

| File                                                                                                                                                                                             | Summary                         |
| ---                                                                                                                                                                                              | ---                             |
| [IntegrationTestsXUnitApp.Tests.csproj](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/IntegrationTestsXUnitApp.Tests/IntegrationTestsXUnitApp.Tests.csproj) | <code>► INSERT-TEXT-HERE</code> |
| [UserTests.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/IntegrationTestsXUnitApp.Tests/UserTests.cs)                                                   | <code>► INSERT-TEXT-HERE</code> |
| [LessonsManagementAppFactory.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/IntegrationTestsXUnitApp.Tests/LessonsManagementAppFactory.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.test.IntegrationTestsXUnitApp.Tests.Config</summary>

| File                                                                                                                                                                              | Summary                         |
| ---                                                                                                                                                                               | ---                             |
| [IntegrationTestsFixture.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/test/IntegrationTestsXUnitApp.Tests/Config/IntegrationTestsFixture.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.sql</summary>

| File                                                                                                                                                                   | Summary                         |
| ---                                                                                                                                                                    | ---                             |
| [Consulta.sql](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/sql/Consulta.sql)                                                         | <code>► INSERT-TEXT-HERE</code> |
| [Criacao tabelas ApplicationDbContext.sql](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/sql/Criacao tabelas ApplicationDbContext.sql) | <code>► INSERT-TEXT-HERE</code> |
| [Criacao tabelas DataDbContext.sql](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/sql/Criacao tabelas DataDbContext.sql)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App</summary>

| File                                                                                                                                                                                 | Summary                         |
| ---                                                                                                                                                                                  | ---                             |
| [StartupWebTests.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/StartupWebTests.cs)                                     | <code>► INSERT-TEXT-HERE</code> |
| [appsettings.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/appsettings.json)                                         | <code>► INSERT-TEXT-HERE</code> |
| [Startup.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Startup.cs)                                                     | <code>► INSERT-TEXT-HERE</code> |
| [appsettings.Development.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/appsettings.Development.json)                 | <code>► INSERT-TEXT-HERE</code> |
| [LessonsManagement.App.csproj](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/LessonsManagement.App.csproj)                 | <code>► INSERT-TEXT-HERE</code> |
| [appsettings.Testing.Development.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/appsettings.Testing.Development.json) | <code>► INSERT-TEXT-HERE</code> |
| [appsettings.Testing.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/appsettings.Testing.json)                         | <code>► INSERT-TEXT-HERE</code> |
| [Program.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Program.cs)                                                     | <code>► INSERT-TEXT-HERE</code> |
| [libman.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/libman.json)                                                   | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Configurations</summary>

| File                                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                                 | ---                             |
| [DependencyInjectionConfig.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Configurations/DependencyInjectionConfig.cs) | <code>► INSERT-TEXT-HERE</code> |
| [GlobalizationConfig.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Configurations/GlobalizationConfig.cs)             | <code>► INSERT-TEXT-HERE</code> |
| [IdentityConfig.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Configurations/IdentityConfig.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [MVCConfig.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Configurations/MVCConfig.cs)                                 | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Extensions</summary>

| File                                                                                                                                                                                      | Summary                         |
| ---                                                                                                                                                                                       | ---                             |
| [CustomAuthorization.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/CustomAuthorization.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [SummaryViewComponent.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/SummaryViewComponent.cs)                     | <code>► INSERT-TEXT-HERE</code> |
| [MoedaAttribute.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/MoedaAttribute.cs)                                 | <code>► INSERT-TEXT-HERE</code> |
| [DisableElementByClaimTagHelper.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/DisableElementByClaimTagHelper.cs) | <code>► INSERT-TEXT-HERE</code> |
| [RemoveElementByClaimTagHelper.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/RemoveElementByClaimTagHelper.cs)   | <code>► INSERT-TEXT-HERE</code> |
| [RazorExtensions.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Extensions/RazorExtensions.cs)                               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.ViewModels</summary>

| File                                                                                                                                                                        | Summary                         |
| ---                                                                                                                                                                         | ---                             |
| [EventTypeViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/EventTypeViewModel.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [ErrorViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/ErrorViewModel.cs)                   | <code>► INSERT-TEXT-HERE</code> |
| [StudentViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/StudentViewModel.cs)               | <code>► INSERT-TEXT-HERE</code> |
| [LessonImportedViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/LessonImportedViewModel.cs) | <code>► INSERT-TEXT-HERE</code> |
| [FileImportedViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/FileImportedViewModel.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [LessonViewModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/ViewModels/LessonViewModel.cs)                 | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Areas.Identity.Pages</summary>

| File                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                 | ---                             |
| [_ViewStart.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Areas/Identity/Pages/_ViewStart.cshtml) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Properties</summary>

| File                                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                                 | ---                             |
| [launchSettings.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Properties/launchSettings.json)                       | <code>► INSERT-TEXT-HERE</code> |
| [serviceDependencies.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Properties/serviceDependencies.json)             | <code>► INSERT-TEXT-HERE</code> |
| [serviceDependencies.local.json](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Properties/serviceDependencies.local.json) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.AutoMapper</summary>

| File                                                                                                                                                          | Summary                         |
| ---                                                                                                                                                           | ---                             |
| [AutoMapperConfig.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/AutoMapper/AutoMapperConfig.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views</summary>

| File                                                                                                                                                     | Summary                         |
| ---                                                                                                                                                      | ---                             |
| [_ViewImports.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/_ViewImports.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [_ViewStart.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/_ViewStart.cshtml)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.Students</summary>

| File                                                                                                                                                    | Summary                         |
| ---                                                                                                                                                     | ---                             |
| [Delete.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Students/Delete.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Edit.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Students/Edit.cshtml)       | <code>► INSERT-TEXT-HERE</code> |
| [Details.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Students/Details.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Create.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Students/Create.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Students/Index.cshtml)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.LessonsImported</summary>

| File                                                                                                                                                           | Summary                         |
| ---                                                                                                                                                            | ---                             |
| [Delete.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/LessonsImported/Delete.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Edit.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/LessonsImported/Edit.cshtml)       | <code>► INSERT-TEXT-HERE</code> |
| [Details.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/LessonsImported/Details.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Create.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/LessonsImported/Create.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/LessonsImported/Index.cshtml)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.Home</summary>

| File                                                                                                                                                | Summary                         |
| ---                                                                                                                                                 | ---                             |
| [Privacy.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Home/Privacy.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Home/Index.cshtml)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.Lessons</summary>

| File                                                                                                                                                                           | Summary                         |
| ---                                                                                                                                                                            | ---                             |
| [_ListLessons.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/_ListLessons.cshtml)               | <code>► INSERT-TEXT-HERE</code> |
| [_ListLessonsGrouped.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/_ListLessonsGrouped.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Delete.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/Delete.cshtml)                           | <code>► INSERT-TEXT-HERE</code> |
| [Edit.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/Edit.cshtml)                               | <code>► INSERT-TEXT-HERE</code> |
| [Details.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/Details.cshtml)                         | <code>► INSERT-TEXT-HERE</code> |
| [Create.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/Create.cshtml)                           | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Lessons/Index.cshtml)                             | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.FileImported</summary>

| File                                                                                                                                                                  | Summary                         |
| ---                                                                                                                                                                   | ---                             |
| [Conciliation.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Conciliation.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Delete.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Delete.cshtml)             | <code>► INSERT-TEXT-HERE</code> |
| [Edit.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Edit.cshtml)                 | <code>► INSERT-TEXT-HERE</code> |
| [Details.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Details.cshtml)           | <code>► INSERT-TEXT-HERE</code> |
| [Create.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Create.cshtml)             | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/FileImported/Index.cshtml)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.EventType</summary>

| File                                                                                                                                                     | Summary                         |
| ---                                                                                                                                                      | ---                             |
| [Delete.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/EventType/Delete.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Edit.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/EventType/Edit.cshtml)       | <code>► INSERT-TEXT-HERE</code> |
| [Details.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/EventType/Details.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [Create.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/EventType/Create.cshtml)   | <code>► INSERT-TEXT-HERE</code> |
| [Index.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/EventType/Index.cshtml)     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.Shared</summary>

| File                                                                                                                                                                                      | Summary                         |
| ---                                                                                                                                                                                       | ---                             |
| [Error.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/Error.cshtml)                                         | <code>► INSERT-TEXT-HERE</code> |
| [_ValidationScriptsPartial.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/_ValidationScriptsPartial.cshtml) | <code>► INSERT-TEXT-HERE</code> |
| [_Layout.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/_Layout.cshtml)                                     | <code>► INSERT-TEXT-HERE</code> |
| [_CookieConsentPartial.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/_CookieConsentPartial.cshtml)         | <code>► INSERT-TEXT-HERE</code> |
| [_LoginPartial.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/_LoginPartial.cshtml)                         | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Views.Shared.Components.Summary</summary>

| File                                                                                                                                                                     | Summary                         |
| ---                                                                                                                                                                      | ---                             |
| [Default.cshtml](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Views/Shared/Components/Summary/Default.cshtml) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Data</summary>

| File                                                                                                                                                            | Summary                         |
| ---                                                                                                                                                             | ---                             |
| [ApplicationDbContext.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/ApplicationDbContext.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Data.Migrations</summary>

| File                                                                                                                                                                                                                       | Summary                         |
| ---                                                                                                                                                                                                                        | ---                             |
| [20240206230848_Initial.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/Migrations/20240206230848_Initial.Designer.cs)                           | <code>► INSERT-TEXT-HERE</code> |
| [00000000000000_CreateIdentitySchema.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/Migrations/00000000000000_CreateIdentitySchema.Designer.cs) | <code>► INSERT-TEXT-HERE</code> |
| [00000000000000_CreateIdentitySchema.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/Migrations/00000000000000_CreateIdentitySchema.cs)                   | <code>► INSERT-TEXT-HERE</code> |
| [20240206230848_Initial.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/Migrations/20240206230848_Initial.cs)                                             | <code>► INSERT-TEXT-HERE</code> |
| [ApplicationDbContextModelSnapshot.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Data/Migrations/ApplicationDbContextModelSnapshot.cs)                       | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.wwwroot.css</summary>

| File                                                                                                                                     | Summary                         |
| ---                                                                                                                                      | ---                             |
| [site.css](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/css/site.css) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.wwwroot.lib.jquery-validation-unobtrusive</summary>

| File                                                                                                                                                                                                                       | Summary                         |
| ---                                                                                                                                                                                                                        | ---                             |
| [LICENSE.txt](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/lib/jquery-validation-unobtrusive/LICENSE.txt)                                               | <code>► INSERT-TEXT-HERE</code> |
| [jquery.validate.unobtrusive.js](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js)         | <code>► INSERT-TEXT-HERE</code> |
| [jquery.validate.unobtrusive.min.js](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.wwwroot.lib.font-awesome.css</summary>

| File                                                                                                                                                            | Summary                         |
| ---                                                                                                                                                             | ---                             |
| [all.min.css](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/lib/font-awesome/css/all.min.css) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.wwwroot.lib.jquery</summary>

| File                                                                                                                                                  | Summary                         |
| ---                                                                                                                                                   | ---                             |
| [LICENSE.txt](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/lib/jquery/LICENSE.txt) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.wwwroot.js</summary>

| File                                                                                                                                                          | Summary                         |
| ---                                                                                                                                                           | ---                             |
| [HideShowElements.js](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/js/HideShowElements.js) | <code>► INSERT-TEXT-HERE</code> |
| [site.js](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/js/site.js)                         | <code>► INSERT-TEXT-HERE</code> |
| [Calendar.js](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/wwwroot/js/Calendar.js)                 | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.App.Controllers</summary>

| File                                                                                                                                                                             | Summary                         |
| ---                                                                                                                                                                              | ---                             |
| [LessonsController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/LessonsController.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [BaseController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/BaseController.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [EventTypeController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/EventTypeController.cs)             | <code>► INSERT-TEXT-HERE</code> |
| [HomeController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/HomeController.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [LessonsImportedController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/LessonsImportedController.cs) | <code>► INSERT-TEXT-HERE</code> |
| [FileImportedController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/FileImportedController.cs)       | <code>► INSERT-TEXT-HERE</code> |
| [StudentsController.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.App/Controllers/StudentsController.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business</summary>

| File                                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                                 | ---                             |
| [LessonsManagement.Business.csproj](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/LessonsManagement.Business.csproj) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.FileImporter</summary>

| File                                                                                                                                                               | Summary                         |
| ---                                                                                                                                                                | ---                             |
| [ImporterTxtFile.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/FileImporter/ImporterTxtFile.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Conciliation</summary>

| File                                                                                                                                                                 | Summary                         |
| ---                                                                                                                                                                  | ---                             |
| [Match.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Match.cs)                       | <code>► INSERT-TEXT-HERE</code> |
| [DivergencyRow.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/DivergencyRow.cs)       | <code>► INSERT-TEXT-HERE</code> |
| [ConciliationList.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/ConciliationList.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Conciliation.Divergencies</summary>

| File                                                                                                                                                                                                | Summary                         |
| ---                                                                                                                                                                                                 | ---                             |
| [EventTypeDivergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/EventTypeDivergencies.cs)         | <code>► INSERT-TEXT-HERE</code> |
| [PriceDivergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/PriceDivergencies.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [Divergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/Divergencies.cs)                           | <code>► INSERT-TEXT-HERE</code> |
| [ExecutionDateDivergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/ExecutionDateDivergencies.cs) | <code>► INSERT-TEXT-HERE</code> |
| [StudentDivergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/StudentDivergencies.cs)             | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Conciliation.Divergencies.Interfaces</summary>

| File                                                                                                                                                                                         | Summary                         |
| ---                                                                                                                                                                                          | ---                             |
| [ISetDivergencies.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Conciliation/Divergencies/Interfaces/ISetDivergencies.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Services</summary>

| File                                                                                                                                                                       | Summary                         |
| ---                                                                                                                                                                        | ---                             |
| [FileImportedService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/FileImportedService.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [EventTypeService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/EventTypeService.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [StudentsService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/StudentsService.cs)             | <code>► INSERT-TEXT-HERE</code> |
| [LessonImportedService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/LessonImportedService.cs) | <code>► INSERT-TEXT-HERE</code> |
| [BaseService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/BaseService.cs)                     | <code>► INSERT-TEXT-HERE</code> |
| [LessonsService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Services/LessonsService.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Notifications</summary>

| File                                                                                                                                                          | Summary                         |
| ---                                                                                                                                                           | ---                             |
| [Notification.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Notifications/Notification.cs) | <code>► INSERT-TEXT-HERE</code> |
| [Notifyer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Notifications/Notifyer.cs)         | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Interfaces</summary>

| File                                                                                                                                                                                 | Summary                         |
| ---                                                                                                                                                                                  | ---                             |
| [IStudentService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IStudentService.cs)                     | <code>► INSERT-TEXT-HERE</code> |
| [IFileImportedService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IFileImportedService.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [ILessonRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/ILessonRepository.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [ILessonImportedRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/ILessonImportedRepository.cs) | <code>► INSERT-TEXT-HERE</code> |
| [INotifyer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/INotifyer.cs)                                 | <code>► INSERT-TEXT-HERE</code> |
| [ILessonsService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/ILessonsService.cs)                     | <code>► INSERT-TEXT-HERE</code> |
| [IEventTypeService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IEventTypeService.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [IRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IRepository.cs)                             | <code>► INSERT-TEXT-HERE</code> |
| [IEventTypeRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IEventTypeRepository.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [IFileImportedRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IFileImportedRepository.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [ILessonImportedService.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/ILessonImportedService.cs)       | <code>► INSERT-TEXT-HERE</code> |
| [IStudentRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Interfaces/IStudentRepository.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Models</summary>

| File                                                                                                                                                       | Summary                         |
| ---                                                                                                                                                        | ---                             |
| [LessonImported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/LessonImported.cs) | <code>► INSERT-TEXT-HERE</code> |
| [Entity.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Entity.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [FileImported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/FileImported.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [Lesson.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Lesson.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [EventType.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/EventType.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [CalendarModel.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/CalendarModel.cs)   | <code>► INSERT-TEXT-HERE</code> |
| [Student.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Student.cs)               | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Models.Validations</summary>

| File                                                                                                                                                                                   | Summary                         |
| ---                                                                                                                                                                                    | ---                             |
| [EventTypeValidation.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Validations/EventTypeValidation.cs)       | <code>► INSERT-TEXT-HERE</code> |
| [FileImportedValidation.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Validations/FileImportedValidation.cs) | <code>► INSERT-TEXT-HERE</code> |
| [LessonsValidation.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Validations/LessonsValidation.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [StudentValidation.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Models/Validations/StudentValidation.cs)           | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagement.Business.Utils</summary>

| File                                                                                                                                                      | Summary                         |
| ---                                                                                                                                                       | ---                             |
| [Operations.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Utils/Operations.cs)         | <code>► INSERT-TEXT-HERE</code> |
| [DateOperations.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagement.Business/Utils/DateOperations.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagemente.Data</summary>

| File                                                                                                                                                                     | Summary                         |
| ---                                                                                                                                                                      | ---                             |
| [Class1.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Class1.cs)                                         | <code>► INSERT-TEXT-HERE</code> |
| [LessonsManagement.Data.csproj](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/LessonsManagement.Data.csproj) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagemente.Data.Repository</summary>

| File                                                                                                                                                                            | Summary                         |
| ---                                                                                                                                                                             | ---                             |
| [Repository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/Repository.cs)                             | <code>► INSERT-TEXT-HERE</code> |
| [LessonImportedRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/LessonImportedRepository.cs) | <code>► INSERT-TEXT-HERE</code> |
| [FileImportedRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/FileImportedRepository.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [EventTypeRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/EventTypeRepository.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [StudentRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/StudentRepository.cs)               | <code>► INSERT-TEXT-HERE</code> |
| [LessonRepository.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Repository/LessonRepository.cs)                 | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagemente.Data.Migrations</summary>

| File                                                                                                                                                                                                                                                                                                        | Summary                         |
| ---                                                                                                                                                                                                                                                                                                         | ---                             |
| [20240305232509_changing required field (Lesson).cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240305232509_changing required field (Lesson).cs)                                                                               | <code>► INSERT-TEXT-HERE</code> |
| [20240322183046_changing lessonimported properties.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240322183046_changing lessonimported properties.cs)                                                                           | <code>► INSERT-TEXT-HERE</code> |
| [20240314022847_changing FileImported.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240314022847_changing FileImported.Designer.cs)                                                                                   | <code>► INSERT-TEXT-HERE</code> |
| [20240220190243_Creating EventType Table.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240220190243_Creating EventType Table.Designer.cs)                                                                             | <code>► INSERT-TEXT-HERE</code> |
| [20240305232509_changing required field (Lesson).Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240305232509_changing required field (Lesson).Designer.cs)                                                             | <code>► INSERT-TEXT-HERE</code> |
| [20240312190918_Table FileImported and LessonImported.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240312190918_Table FileImported and LessonImported.Designer.cs)                                                   | <code>► INSERT-TEXT-HERE</code> |
| [20240219181708_AddNotesFieldIntoLessonsTable.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240219181708_AddNotesFieldIntoLessonsTable.cs)                                                                                     | <code>► INSERT-TEXT-HERE</code> |
| [20240220204525_Add DurationTimeInMinutes into EventType Table.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240220204525_Add DurationTimeInMinutes into EventType Table.cs)                                                   | <code>► INSERT-TEXT-HERE</code> |
| [DataDbContextModelSnapshot.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/DataDbContextModelSnapshot.cs)                                                                                                                         | <code>► INSERT-TEXT-HERE</code> |
| [20240206230510_Initial.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240206230510_Initial.Designer.cs)                                                                                                               | <code>► INSERT-TEXT-HERE</code> |
| [20240315045606_fix filepath character length - fileimported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315045606_fix filepath character length - fileimported.cs)                                                       | <code>► INSERT-TEXT-HERE</code> |
| [20240315045045_fix date fileimported.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315045045_fix date fileimported.Designer.cs)                                                                                   | <code>► INSERT-TEXT-HERE</code> |
| [20240315001439_change fileimported.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315001439_change fileimported.Designer.cs)                                                                                       | <code>► INSERT-TEXT-HERE</code> |
| [20240312190918_Table FileImported and LessonImported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240312190918_Table FileImported and LessonImported.cs)                                                                     | <code>► INSERT-TEXT-HERE</code> |
| [20240315045045_fix date fileimported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315045045_fix date fileimported.cs)                                                                                                     | <code>► INSERT-TEXT-HERE</code> |
| [20240221220759_Changing name field DurationTimeInMinutes into EventType Table.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240221220759_Changing name field DurationTimeInMinutes into EventType Table.Designer.cs) | <code>► INSERT-TEXT-HERE</code> |
| [20240315045606_fix filepath character length - fileimported.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315045606_fix filepath character length - fileimported.Designer.cs)                                     | <code>► INSERT-TEXT-HERE</code> |
| [20240322183046_changing lessonimported properties.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240322183046_changing lessonimported properties.Designer.cs)                                                         | <code>► INSERT-TEXT-HERE</code> |
| [20240206230510_Initial.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240206230510_Initial.cs)                                                                                                                                 | <code>► INSERT-TEXT-HERE</code> |
| [20240219181708_AddNotesFieldIntoLessonsTable.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240219181708_AddNotesFieldIntoLessonsTable.Designer.cs)                                                                   | <code>► INSERT-TEXT-HERE</code> |
| [20240221220759_Changing name field DurationTimeInMinutes into EventType Table.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240221220759_Changing name field DurationTimeInMinutes into EventType Table.cs)                   | <code>► INSERT-TEXT-HERE</code> |
| [20240315001439_change fileimported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240315001439_change fileimported.cs)                                                                                                         | <code>► INSERT-TEXT-HERE</code> |
| [20240220190243_Creating EventType Table.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240220190243_Creating EventType Table.cs)                                                                                               | <code>► INSERT-TEXT-HERE</code> |
| [20240220204525_Add DurationTimeInMinutes into EventType Table.Designer.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240220204525_Add DurationTimeInMinutes into EventType Table.Designer.cs)                                 | <code>► INSERT-TEXT-HERE</code> |
| [20240314022847_changing FileImported.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Migrations/20240314022847_changing FileImported.cs)                                                                                                     | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagemente.Data.Mappings</summary>

| File                                                                                                                                                                    | Summary                         |
| ---                                                                                                                                                                     | ---                             |
| [EventTypeMapping.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/EventTypeMapping.cs)           | <code>► INSERT-TEXT-HERE</code> |
| [DataBaseTypes.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/DataBaseTypes.cs)                 | <code>► INSERT-TEXT-HERE</code> |
| [StudentMapping.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/StudentMapping.cs)               | <code>► INSERT-TEXT-HERE</code> |
| [FileImportedMapping.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/FileImportedMapping.cs)     | <code>► INSERT-TEXT-HERE</code> |
| [LessonsMapping.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/LessonsMapping.cs)               | <code>► INSERT-TEXT-HERE</code> |
| [LessonImportedMapping.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Mappings/LessonImportedMapping.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

<details closed><summary>LessonsManagement.src.LessonsManagemente.Data.Context</summary>

| File                                                                                                                                                   | Summary                         |
| ---                                                                                                                                                    | ---                             |
| [DataDbContext.cs](https://github.com/pheliperost/LessonManagement/blob/master/LessonsManagement/src/LessonsManagemente.Data/Context/DataDbContext.cs) | <code>► INSERT-TEXT-HERE</code> |

</details>

---

## 🚀 Getting Started

***Requirements***

Ensure you have the following dependencies installed on your system:

* **CSharp**: `version x.y.z`

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

### 🤖 Running LessonManagement

Use the following command to run LessonManagement:

```sh
dotnet run
```

### 🧪 Tests

To execute tests, run:

```sh
dotnet test
```

---

## 🛠 Project Roadmap

- [X] `► INSERT-TASK-1`
- [ ] `► INSERT-TASK-2`
- [ ] `► ...`

---

## 🤝 Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Submit Pull Requests](https://github.com/pheliperost/LessonManagement/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/pheliperost/LessonManagement/discussions)**: Share your insights, provide feedback, or ask questions.
- **[Report Issues](https://github.com/pheliperost/LessonManagement/issues)**: Submit bugs found or log feature requests for Lessonmanagement.

<details closed>
    <summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your GitHub account.
2. **Clone Locally**: Clone the forked repository to your local machine using a Git client.
   ```sh
   git clone https://github.com/pheliperost/LessonManagement
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to GitHub**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.

Once your PR is reviewed and approved, it will be merged into the main branch.

</details>

---

## 📄 License

This project is protected under the [SELECT-A-LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

## 👏 Acknowledgments

- List any resources, contributors, inspiration, etc. here.

[**Return**](#-quick-links)

---
