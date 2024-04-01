using FluentValidation;
using FluentValidation.Results;
using LessonsManagement.Business.Interfaces;
using LessonsManagement.Business.Models;
using LessonsManagement.Business.Notifications;

namespace LessonsManagement.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotifyer _notifyer;

        protected BaseService(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorCode);
            }

        }

        protected void Notify(string message)
        {
            _notifyer.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
