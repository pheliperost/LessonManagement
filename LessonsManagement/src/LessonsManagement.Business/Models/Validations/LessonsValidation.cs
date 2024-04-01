using FluentValidation;

namespace LessonsManagement.Business.Models.Validations
{
    public class LessonsValidation : AbstractValidator<Lesson>
    {
        public LessonsValidation()
        {
            RuleFor(f => f.ExecutionDate)
                .NotEmpty().WithMessage("The field {PropertyName} is required.");

            RuleFor(f => f.Notes)
                .NotEmpty().WithMessage("The field {PropertyName} is required.")
                .Length(0, 500)
                .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");


        }
    }
}
