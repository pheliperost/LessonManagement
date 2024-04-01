using FluentValidation;

namespace LessonsManagement.Business.Models.Validations
{
    public class EventTypeValidation : AbstractValidator<EventType>
    {
        public EventTypeValidation()
        {
            RuleFor(f => f.EventTypeName)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .Length(0, 100)
               .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");

            RuleFor(f => f.Notes)
               .NotEmpty().WithMessage("The field {PropertyName} is required.")
               .Length(0, 500)
               .WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength}.");

            RuleFor(f => f.Price)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be greater than {ComparisonValue}");

            RuleFor(f => f.DurationTimeInMinutes)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be greater than {ComparisonValue}");

        }
    }
}
