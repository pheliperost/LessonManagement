using LessonsManagement.Business.Notifications;
using System.Collections.Generic;

namespace LessonsManagement.Business.Interfaces
{
    public interface INotifyer
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
