using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LessonsManagement.App.ViewModels
{
    public class LessonImportedViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The field {0} it's required!")]
        [DisplayName("Event Type Id")]
        public Guid EventTypeId { get; set; }

        [DisplayName("Student Id")]
        public Guid? StudentId { get; set; }

        [DisplayName("File Imported Id")]
        public Guid? FileImportedId { get; set; }

        [Required(ErrorMessage = "The field {0} it's required!")]
        [DataType(DataType.DateTime, ErrorMessage = "Wrong Date Format!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [BindProperty]
        [DisplayName("Execution Date")]
        public DateTime ExecutionDate { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [StringLength(500, ErrorMessage = "The field {0} must have up to {1} characters")]
        public string Notes { get; set; }

        //[NotMapped]
        public StudentViewModel Student { get; set; }

        //[NotMapped]
        public EventTypeViewModel EventType { get; set; }

        //[NotMapped]
        public FileImportedViewModel FileImported { get; set; }

        //[NotMapped]
        public IEnumerable<StudentViewModel> Students { get; set; }

        //[NotMapped]
        public IEnumerable<EventTypeViewModel> EventTypes { get; set; }

        //[NotMapped]
        public IEnumerable<FileImportedViewModel> FileImporteds { get; set; }
    }
}
