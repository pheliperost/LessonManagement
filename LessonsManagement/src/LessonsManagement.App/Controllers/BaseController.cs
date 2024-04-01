using LessonsManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LessonsManagement.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotifyer _notifyer;

        public BaseController(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        protected bool ValidOperation()
        {
            return !_notifyer.HasNotification();
        }
    }
}
