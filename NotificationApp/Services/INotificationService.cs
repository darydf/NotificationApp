using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationApp.Services
{
    public interface INotificationService
    {
        string ServiceType {  get; }
        void Send(string message);
    }
}
