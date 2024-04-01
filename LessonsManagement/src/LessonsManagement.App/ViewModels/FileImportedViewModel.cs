using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LessonsManagement.App.ViewModels
{
    public class FileImportedViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("File")]
        [NotMapped]
        public IFormFile FileUpload { get; set; }

        public string FilePath { get; set; }

        [Required(ErrorMessage = "The field {0} it's required!")]
        [DataType(DataType.Date, ErrorMessage = "Wrong Date Format!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The field {0} it's required!")]
        [DataType(DataType.Date, ErrorMessage = "Wrong Date Format!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "The Field {0} Is Required!")]
        [StringLength(40, ErrorMessage = "The field {0} must have up to {1} characters")]
        public string FileDescription { get; set; }

        [NotMapped]
        public IEnumerable<LessonImportedViewModel> LessonsImported { get; set; }
    }
}
