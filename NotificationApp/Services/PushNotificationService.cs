using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Services
{
    public class PushNotificationService : INotificationService
    {
        private readonly ILogger _logger;

        public string ServiceType => "Push";

        public PushNotificationService(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(string message)
        {
            _logger.LogInfo($"Отправка Push: {message}");
        }
    }
}
