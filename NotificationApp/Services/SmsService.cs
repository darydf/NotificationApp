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

            Random random = new Random();
            if (random.Next(1, 5) == 1)
            {
                throw new Exception("Не удалось отправить уведомление");
            }

            _logger.LogInfo($"SMS успешно отправлен: {message}");
        }

    }
}
