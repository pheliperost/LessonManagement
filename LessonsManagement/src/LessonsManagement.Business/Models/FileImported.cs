using System;
using System.Collections.Generic;

namespace LessonsManagement.Business.Models
{
    public class FileImported : Entity
    {
        public String FilePath { get; set; }
        public String FileDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Ef Relations
        public IEnumerable<LessonImported> LessonsImported { get; set; }
    }
}
