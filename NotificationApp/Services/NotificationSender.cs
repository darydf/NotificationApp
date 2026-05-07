using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Services
{
    public class NotificationSender
    {
        private readonly INotificationService _notificationService;

        public NotificationSender(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void Send(string message)
        {
            _notificationService.Send(message);
        }

        public string GetServiceType()
        {
            return _notificationService.ServiceType;
        }
    }
}
