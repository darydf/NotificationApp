using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Services
{
    public class SmsService : INotificationService
    {
        private readonly ILogger _logger;

        public string ServiceType => "SMS";

        public SmsService(ILogger logger)
        {
            _logger = logger;
        }

        public void Send(string message)
        {
            _logger.LogInfo($"Отправка SMS: {message}");
        }
    }
}
