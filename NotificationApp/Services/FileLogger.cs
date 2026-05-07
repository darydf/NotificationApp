using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Services
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public void LogInfo(string message)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} INFO: {message}";
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }

        public void LogError(string message)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} ERROR: {message}";
            File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
        }
    }
}
