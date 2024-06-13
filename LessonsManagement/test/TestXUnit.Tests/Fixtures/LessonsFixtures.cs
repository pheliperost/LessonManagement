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
    [CollectionDefinition(nameof(LessonsCollection))]
    public class LessonsCollection : ICollectionFixture<LessonsFixtures>
    {}

    public class LessonsFixtures : IDisposable
    {
        public LessonsService  _lessonsService;
        public StudentFixtures _studentFixtures;
        public EventTypeFixtures _eventTypeFixtures;
        public AutoMocker Mocker;

        public LessonsFixtures()
        {
            Mocker = new AutoMocker();
        }

        public Lesson GenerateValidLesson()
        {
            var eventType = GenerateValidEventType();
            var student = GenerateValidStudent();

            var lesson = new Faker<Lesson>()
                 .RuleFor(c => c.ExecutionDate, f => f.Date.Recent(2))
                 .RuleFor(c => c.Notes, f => f.Lorem.Paragraphs(2))
                 .RuleFor(c => c.EventTypeId, f => eventType.Id)
                 .RuleFor(c => c.EventType, f => eventType)
                 .RuleFor(c => c.StudentId, student.Id)
                 .RuleFor(c => c.Student, student);

            return lesson;
        }

        public Lesson GenerateInvalidLesson()
        {
            var eventType = GenerateValidEventType();
            var student = GenerateValidStudent();

            var lesson = new Faker<Lesson>()
                     .RuleFor(c => c.EventTypeId, f => eventType.Id)
                     .RuleFor(c => c.EventType, f => eventType);

            return lesson;
        }


        public Student GenerateValidStudent()
        {
            var studentFaker = new Faker<Student>()
                .RuleFor(c => c.StudentName, f => f.Name.FullName())
                .RuleFor(c => c.Notes, f => f.Lorem.Paragraph(2));

            return studentFaker;
        }

        public EventType GenerateValidEventType()
        {
            var eventType = new Faker<EventType>()
                .RuleFor(c => c.EventTypeName, f => f.PickRandom<EventTypesNamesEnum>().ToString())
                .RuleFor(c => c.Notes, f => f.Lorem.Paragraphs(2))
                .RuleFor(c => c.Price, f => Convert.ToDecimal(f.Commerce.Price(1, 200, 2)))
                .RuleFor(c => c.DurationTimeInMinutes, f => f.Random.Number(1, 360));

            return eventType;
        }

        public LessonsService GetService()
        {
            Mocker = new AutoMocker();
            _lessonsService = Mocker.CreateInstance<LessonsService>();

            return _lessonsService;
        }

        public void Dispose()
        {
        }
    }
}
