using LessonsManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LessonsManagement.App.Extensions
{
    [ViewComponent(Name = "Summary")]
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotifyer _notifyer;

        public SummaryViewComponent(INotifyer notifyer)
        {
            _notifyer = notifyer;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notifyer.GetNotifications());

            notifications.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Message));

            return View();
        }
    }
}
