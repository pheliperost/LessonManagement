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

            _testsFixture.GeneratePassword();

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Input.Email",_testsFixture.UserEmail},
                {"Input.Password",_testsFixture.UserPassword},
                {"Input.ConfirmPassword",_testsFixture.UserPassword}
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
            Assert.Contains($"Hello {_testsFixture.UserEmail}!", responseString);
        }

        [Fact(DisplayName = "Execute the user registration with mismatch password returning error.")]
        [Trait("Category", "Integration Web - User")]
        public async Task User_RegisterYourselfWithPasswordMismatching_MustExecuteCommandWithError()
        {
            //Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Identity/Account/Register");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgeryToken = _testsFixture.GetAntiForgeryToken(await initialResponse.Content.ReadAsStringAsync());

            _testsFixture.GeneratePassword();

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Input.Email",_testsFixture.UserEmail},
                {"Input.Password",_testsFixture.UserPassword},
                {"Input.ConfirmPassword",_testsFixture.UserPassword+ "abc"}
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
            Assert.Contains($"The password and confirmation password do not match.", responseString);
        }

        [Fact(DisplayName = "Execute the user registration with invalid email returning error.")]
        [Trait("Category", "Integration Web - User")]
        public async Task User_RegisterYourselfWithInvalidEmail_MustExecuteCommandWithError()
        {
            //Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Identity/Account/Register");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgeryToken = _testsFixture.GetAntiForgeryToken(await initialResponse.Content.ReadAsStringAsync());

            _testsFixture.GeneratePassword();

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Input.Email",_testsFixture.GenerateInvalidEmail(10)},
                {"Input.Password",_testsFixture.UserPassword},
                {"Input.ConfirmPassword",_testsFixture.UserPassword}
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
            Assert.Contains($"The Email field is not a valid e-mail address.", responseString);
        }

        [Fact(DisplayName = "Execute the user registration without filling fields returning error.")]
        [Trait("Category", "Integration Web - User")]
        public async Task User_RegisterYourselfWithoutFillingFields_MustExecuteCommandWithError()
        {
            //Arrange
            var initialResponse = await _testsFixture.Client.GetAsync("/Identity/Account/Register");
            initialResponse.EnsureSuccessStatusCode();

            var antiForgeryToken = _testsFixture.GetAntiForgeryToken(await initialResponse.Content.ReadAsStringAsync());

            _testsFixture.GeneratePassword();

            var formData = new Dictionary<string, string>
            {
                { _testsFixture.AntiForgeryFieldName, antiForgeryToken },
                {"Input.Email",""},
                {"Input.Password","" },
                {"Input.ConfirmPassword",""}
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
            Assert.Contains($"The Email field is required.", responseString);
            Assert.Contains($"The Password field is required.", responseString);
        }
    }
}
