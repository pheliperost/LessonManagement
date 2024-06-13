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
    [CollectionDefinition(nameof(StudentCollection))]
    public class StudentCollection : ICollectionFixture<StudentFixtures>
    {}


    public class StudentFixtures : IDisposable
    {
        public StudentsService _studentService;
        public AutoMocker Mocker;
        public Student GenerateValidStudent()
        {
            var studentFaker = new Faker<Student>()
                .RuleFor(c => c.StudentName, f => f.Name.FullName())
                .RuleFor(c => c.Notes, f => f.Lorem.Paragraph(2));

            return studentFaker;
        }
        public Student GenerateInvalidStudent()
        {
           return new Faker<Student>();
        }

        public StudentsService GetService()
        {
            Mocker = new AutoMocker();
            _studentService = Mocker.CreateInstance<StudentsService>();
            return _studentService;
        }
        public void Dispose()
        {
        }
    }
}
