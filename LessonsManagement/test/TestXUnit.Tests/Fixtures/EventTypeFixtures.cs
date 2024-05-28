using Bogus;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestXUnitBusiness.Tests.Fixtures
{
    [CollectionDefinition(nameof(EventTypeCollection))]
    public class EventTypeCollection : ICollectionFixture<EventTypeFixtures>
    {}

    public class EventTypeFixtures : IDisposable
    {
        public EventTypeService  _eventTypeService;
        public AutoMocker Mocker;
        public EventType GenerateValidEventType()
        {
            var eventType = new Faker<EventType>()
                .RuleFor(c => c.EventTypeName, f => f.PickRandom<EventTypesNamesEnum>().ToString())
                .RuleFor(c => c.Notes, f => f.Lorem.Paragraphs(2))
                .RuleFor(c => c.Price, f => Convert.ToDecimal(f.Commerce.Price(1, 200, 2)))
                .RuleFor(c => c.DurationTimeInMinutes, f => f.Random.Number(1,360));

            return eventType;
        }
        public EventType GenerateInvalidEventType()
        {
            return new Faker<EventType>();
        }

        public EventTypeService GetService()
        {
            Mocker = new AutoMocker();
            _eventTypeService = Mocker.CreateInstance<EventTypeService>();

            return _eventTypeService;
        }

        public void Dispose()
        {
        }
    }
}
