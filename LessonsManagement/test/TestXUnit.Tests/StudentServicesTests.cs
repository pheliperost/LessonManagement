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

        public StudentServicesTests( StudentFixtures studentFixtures)
        {
            _studentFixtures = studentFixtures;
        }

        [Fact(DisplayName = "Adding New Student Should Return Success.")]
        [Trait("Categoria", "Student Service")]
        public async Task StudentServices_AddNewStudent_ShouldReturnSuccess()
        {
            // Arrange
            var student = _studentFixtures.GenerateValidStudent();
            var mocker = new AutoMocker();

            var studentService = mocker.CreateInstance<StudentsService>();

            // Act
            await studentService.Add(student);

            // Assert
            mocker.GetMock<IStudentRepository>().Verify(r => r.Add(student), Times.Once);
            mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);
        }

        [Fact(DisplayName = "Adding New Invalid Student Should Return Error.")]
        [Trait("Categoria", "Student Service")]
        public async Task StudentServices_AddNewInvalidStudent_ShouldReturnError()
        {
            // Arrange
            var student = _studentFixtures.GenerateInvalidStudent();
            var mocker = new AutoMocker();

            var studentService = mocker.CreateInstance<StudentsService>();
            var notifyer = new Mock<INotifyer>();

            // Act
            await studentService.Add(student);

            // Assert
            mocker.GetMock<IStudentRepository>().Verify(r => r.Add(student), Times.Never);
            mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(2));
        }
    }
}
