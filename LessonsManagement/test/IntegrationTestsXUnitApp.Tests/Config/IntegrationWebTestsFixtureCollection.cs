using LessonsManagement.App;
using Xunit;

namespace IntegrationTestsXUnitApp.Tests.Config
{
    public class IntegrationWebTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupWebTests>>
    {
    }
}
