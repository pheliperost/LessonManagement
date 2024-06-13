using Bogus;
using FluentValidation;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models.Validations;
using LessonsManagement.Business.Notifications;
using LessonsManagement.Business.Services;
using Moq;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestXUnitBusiness.Tests.Fixtures;
using Xunit;

namespace TestXUnitBusiness.Tests
{
    [Collection(nameof(StudentCollection))]
    public class StudentServicesTests
    {
        readonly StudentFixtures _studentFixtures;
        readonly StudentsService _studentsService;

        public StudentServicesTests(StudentFixtures studentFixtures)
        {
            _studentFixtures = studentFixtures;
            _studentsService = _studentFixtures.GetService();

        }

        [Fact(DisplayName = "Adding a New Valid Student Should Return Success.")]
        [Trait("Category", "Student Service")]
        public async Task StudentServices_AddNewStudent_ShouldReturnSuccess()
        {
            // Arrange
            var student = _studentFixtures.GenerateValidStudent();

            // Act
            await _studentsService.Add(student);

            // Assert
            _studentFixtures.Mocker.GetMock<IStudentRepository>().Verify(r => r.Add(student), Times.Once);
            _studentFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);
        }

        [Fact(DisplayName = "Adding a New Invalid Student Should Return Error.")]
        [Trait("Category", "Student Service")]
        public async Task StudentServices_AddNewInvalidStudent_ShouldReturnError()
        {
            // Arrange
            var student = _studentFixtures.GenerateInvalidStudent();
            var notifyer = new Mock<INotifyer>();

            // Act
            await _studentsService.Add(student);

            // Assert
            _studentFixtures.Mocker.GetMock<IStudentRepository>().Verify(r => r.Add(student), Times.Never);
            _studentFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(2));
        }
    }
}
