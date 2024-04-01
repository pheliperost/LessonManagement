using FluentValidation;

namespace LessonsManagement.Business.Models.Validations
{
    public class StudentValidation : AbstractValidator<Student>
    {
        public StudentValidation()
        {
            RuleFor(f => f.StudentName)
                .NotEmpty().WithMessage("The field {PropertyName} is required.")
                .Length(0, 100)
                .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");

            RuleFor(f => f.Notes)
                .NotEmpty().WithMessage("The field {PropertyName} is required.")
                .Length(0, 500)
                .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");

        }
    }
}
