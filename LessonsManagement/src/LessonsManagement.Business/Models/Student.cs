using System;
using System.Collections.Generic;

namespace LessonsManagement.Business.Models
{
    public class Student : Entity
    {
        public String StudentName { get; set; }
        public String Notes { get; set; }

        public IEnumerable<Lesson> Lessons { get; set; }
    }
}
