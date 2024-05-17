using IntegrationTestsXUnitApp.Tests.Config;
using LessonsManagement.App;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTestsXUnitApp.Tests
{
    [Collection(nameof(IntegrationWebTestsFixtureCollection))]
    public class UserTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _testsFixture;
        public UserTests(IntegrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Execute the user registration with success.")]
        [Trait("Category","Integration Web - User")]
        public async Task User_RegisterYourself_MustExecuteCommandWithSuccess()
        {
            //Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Identity/Account/Register");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgeryToken = _testsFixture.GetAntiForgeryToken(await initialResponse.Content.ReadAsStringAsync());

            var email = "teste@teste.com";

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Input.Email",email},
                {"Input.Password","@_Abc1teste"},
                {"Input.ConfirmPassword","@_Abc1teste"}
            };

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Identity/Account/Register")
            {
                Content = new FormUrlEncodedContent(formData)
            };

            //Act
            var postResponse = await _testsFixture.Client.SendAsync(postRequest);

            //Assert
            var responseString = await postResponse.Content.ReadAsStringAsync();

            postResponse.EnsureSuccessStatusCode();
            Assert.Contains($"Hello {email}!", responseString);
        }
    }
}
