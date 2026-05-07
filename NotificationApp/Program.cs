using Microsoft.Extensions.DependencyInjection;
using NotificationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 

            var services = new ServiceCollection();

            services.AddSingleton<ILogger, FileLogger>();
            services.AddSingleton<INotificationService, EmailService>();
            services.AddSingleton<INotificationService, SmsService>();
            services.AddSingleton<INotificationService, PushNotificationService>();
            services.AddSingleton<MainForm>();

            var serviceProvider = services.BuildServiceProvider();
            var mainForm = serviceProvider.GetRequiredService<MainForm>();

            Application.Run(mainForm);
        }
    }
}
