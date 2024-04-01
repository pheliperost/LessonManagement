using FluentValidation;
using System;

namespace LessonsManagement.Business.Models.Validations
{
    public class FileImportedValidation : AbstractValidator<FileImported>
    {
        public FileImportedValidation()
        {
            RuleFor(f => f.FilePath)
                .NotEmpty().WithMessage("You must select a file to upload.");

            RuleFor(f => f.FileDescription)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .Length(0, 100)
               .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");

            RuleFor(f => f.StartDate)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .Must(ValidDate)
               .WithMessage("The field {PropertyName} needs to be greater than {MinLength} and less than {MaxLength}.");

            RuleFor(f => f.EndDate)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .Must(ValidDate)
               .WithMessage("The field {PropertyName} needs to be greater than {MinLength} and less than {MaxLength}.");

        }

        protected bool ValidDate(DateTime date)
        {

            if (date > DateTime.MinValue && date < DateTime.MaxValue)
            {
                return true;
            }

            return false;
        }
    }
}
