using Bogus;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Services;
using Moq.AutoMock;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public EventType GenerateEmptyEventTypeWithEmptyLesson()
        {
            IEnumerable<Lesson> emptyLesson = Enumerable.Empty<Lesson>();
            var eventType = new Faker<EventType>()
                .RuleFor(c => c.Lessons, f => emptyLesson);

            return eventType;
        }

        public EventType GenerateEmptyEventTypeWithLesson()
        {
            var lesson = new Faker<Lesson>()
                .RuleFor(c => c.ExecutionDate, f => f.Date.Recent(2))
                .RuleFor(c => c.Notes, f => f.Lorem.Paragraphs(2));

            var eventType = new Faker<EventType>()
                .RuleFor(c => c.Lessons, f => lesson.Generate(1));

            return eventType;
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
