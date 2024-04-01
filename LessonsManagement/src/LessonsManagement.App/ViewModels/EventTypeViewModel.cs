using LessonsManagement.App.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonsManagement.App.ViewModels
{
    public class EventTypeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Field {0} is Required!")]
        [StringLength(50, ErrorMessage = "The field {0} must have up to {1} characters")]
        [DisplayName("Event Type Name")]
        public string EventTypeName { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [StringLength(500, ErrorMessage = "The field {0} must have up to {1} characters")]
        public string Notes { get; set; }

        [Required(ErrorMessage = "The field {0} it's required!")]
        [Moeda]
        [DisplayName("Price")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [DisplayName("Duration Time (Minutes)")]
        public int DurationTimeInMinutes { get; set; }

        //[NotMapped]
        public IEnumerable<LessonViewModel> Lessons { get; set; }
    }
}
