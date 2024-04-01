using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonsManagement.App.ViewModels
{
    public class StudentViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} characters", MinimumLength = 5)]
        [DisplayName("Student Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [StringLength(500, ErrorMessage = "The field {0} must have up to {1} characters")]
        public string Notes { get; set; }

        //[NotMapped]
        public IEnumerable<LessonViewModel> Lessons { get; set; }
    }
}
