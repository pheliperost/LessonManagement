using LessonsManagement.Business.Interfaces;
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
    [Collection(nameof(EventTypeCollection))]
    public class EventTypeServicesTests
    {
        readonly EventTypeFixtures _eventTypeFixtures;
        readonly EventTypeService _eventTypeService;

        public  EventTypeServicesTests(EventTypeFixtures eventTypeFixtures)
        {
            _eventTypeFixtures = eventTypeFixtures;
            _eventTypeService = _eventTypeFixtures.GetService();
        }

        [Fact(DisplayName = "Adding New Valid Event Type Should Return Success.")]
        [Trait("Categoria", "Event Type Service")]
        public async Task EventTypeServices_AddNewEventType_ShouldReturnSuccess()
        {
            // Arrange
            var eventType = _eventTypeFixtures.GenerateValidEventType();

            // Act
            await _eventTypeService.Add(eventType);

            // Assert
            _eventTypeFixtures.Mocker.GetMock<IEventTypeRepository>().Verify(r => r.Add(eventType), Times.Once);
            _eventTypeFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Never);

        }

        [Fact(DisplayName = "Adding New Invalid Event Type Should Return Error.")]
        [Trait("Categoria", "Event Type Service")]
        public async Task EventTypeServices_AddNewInvalidEventType_ShouldReturnError()
        {
            // Arrange
            var eventType = _eventTypeFixtures.GenerateInvalidEventType();

            // Act
            await _eventTypeService.Add(eventType);

            // Assert
            _eventTypeFixtures.Mocker.GetMock<IEventTypeRepository>().Verify(r => r.Add(eventType), Times.Never);
            _eventTypeFixtures.Mocker.GetMock<INotifyer>().Verify(m => m.Handle(It.IsAny<Notification>()), Times.Exactly(4));

        }
    }
}
