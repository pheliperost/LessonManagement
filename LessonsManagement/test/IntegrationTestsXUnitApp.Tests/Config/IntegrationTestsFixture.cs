using IntegrationTestsXUnitApp.Tests.Config;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace IntegrationTestsXUnitApp.Tests.Config
{
    [CollectionDefinition(nameof(IntegrationWebTestsFixtureCollection))]

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly LessonsManagementAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions {

            };

            Factory = new LessonsManagementAppFactory<TStartup>();
            Client = Factory.CreateClient();
        }
        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
