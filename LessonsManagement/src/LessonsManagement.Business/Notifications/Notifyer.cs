using LessonsManagement.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LessonsManagement.Business.Notifications
{
    public class Notifyer : INotifyer
    {
        private List<Notification> _notifications;

        public Notifyer()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
