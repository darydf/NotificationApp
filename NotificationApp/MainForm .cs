using NotificationApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationApp
{
    public partial class MainForm : Form
    {
        private readonly Dictionary<string, INotificationService> _services;
        private readonly ILogger _logger;

        public MainForm(
            IEnumerable<INotificationService> services,
            ILogger logger)
        {
            _services = services.ToDictionary(s => s.ServiceType);
            _logger = logger;

            InitializeComponent();

            cmbNotificationType.Items.Clear();
            foreach (var serviceType in _services.Keys)
            {
                cmbNotificationType.Items.Add(serviceType);
            }

            if (cmbNotificationType.Items.Count > 0)
                cmbNotificationType.SelectedIndex = 0;

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var channel = cmbNotificationType.Text;
            var message = txtMessage.Text;
            var time = DateTime.Now.ToString("HH:mm:ss");

            if (string.IsNullOrEmpty(channel))
            {
                MessageBox.Show("Выберите сервис");
                _logger.LogError("Сервис не выбран");
                AddLog($"{time} | ERROR | Сервис не выбран");
                return;
            }

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Введите сообщение");
                _logger.LogError("Пустое сообщение");
                AddLog($"{time} | ERROR | Пустое сообщение");
                return;
            }

            INotificationService service = null;

            if (channel == "Email")
                service = _services["Email"];
            else if (channel == "SMS")
                service = _services["SMS"];
            else if (channel == "Push")
                service = _services["Push"];

            try
            {
                var notificationSender = new NotificationSender(service);
                notificationSender.Send(message);
                AddLog($"{time} | INFO | {channel} отправлен: {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                AddLog($"{time} | ERROR | {ex.Message}");
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            if (message.ToLower() == "пасхалка")
            {
                var easterForm = new SecretForm();
                easterForm.ShowDialog();
                AddLog($"{time} | ПАСХАЛКА | Секретная форма открыта!");
            }
        }

        private void AddLog(string message)
        {
            if (lstLogs.InvokeRequired)
            {
                lstLogs.Invoke(new Action(() => AddLog(message)));
                return;
            }

            lstLogs.Items.Add(message);
            lstLogs.SelectedIndex = lstLogs.Items.Count - 1;

            while (lstLogs.Items.Count > 100)
            {
                lstLogs.Items.RemoveAt(0);
            }
        }
    }
}

