using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Notifications;
using LessonsManagement.Business.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXUnitBusiness.Tests.Fixtures;
using Xunit;

namespace TestXUnitBusiness.Tests
{
    [Collection(nameof(LessonsCollection))]
    public class LessonsServicesTests
    {
        readonly LessonsFixtures _lessonsFixtures;
        readonly LessonsService _lessonsService;

        public LessonsServicesTests(LessonsFixtures lessonsFixtures)
        {
            _lessonsFixtures = lessonsFixtures;
            _lessonsService = _lessonsFixtures.GetService();
        }

        [Fact(DisplayName = "Adding new Valid Lesson Should Return Success.")]
        [Trait("Categoria", "Lessons Service")]
        public async Task  LessonsServices_AddNewValidLesson_ShouldReturnSuccess()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateValidLesson();
            _lessonsFixtures.Mocker.GetMock<IEventTypeRepository>().Setup(c => c.GetEventType(lesson.EventTypeId))
                .Returns(Task.FromResult(lesson.EventType));

            IEnumerable<Lesson> lstLessonEmpty = Enumerable.Empty<Lesson>(); ;

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetLessonsByExecutedDay(lesson.ExecutionDate.Date))
                .Returns(Task.FromResult(lstLessonEmpty));

            // Act
            await _lessonsService.Add(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Add(lesson), Times.Once);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);
        }

        [Fact(DisplayName = "Adding new Invalid Lesson Should Return Error.")]
        [Trait("Categoria", "Lessons Service")]
        public async Task LessonsServices_AddNewInvalidLesson_ShouldReturnError()
        {
            // Arrange
            var lesson = _lessonsFixtures.GenerateInvalidLesson();
            _lessonsFixtures.Mocker.GetMock<IEventTypeRepository>().Setup(c => c.GetEventType(lesson.EventTypeId))
                .Returns(Task.FromResult(lesson.EventType));

            IEnumerable<Lesson> lstLessonEmpty = Enumerable.Empty<Lesson>(); ;

            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Setup(c => c.GetLessonsByExecutedDay(lesson.ExecutionDate.Date))
                .Returns(Task.FromResult(lstLessonEmpty));

            // Act
            await _lessonsService.Add(lesson);

            // Assert
            _lessonsFixtures.Mocker.GetMock<ILessonRepository>().Verify(r => r.Add(lesson), Times.Never);
            _lessonsFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(2));
        }
    }
}
