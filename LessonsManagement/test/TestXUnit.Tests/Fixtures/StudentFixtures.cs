using Bogus;
using LessonsManagement.Business.Models;
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
        public void Dispose()
        {
        }
    }
}
