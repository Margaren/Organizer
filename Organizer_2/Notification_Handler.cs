using System;

namespace Organizer_2
{
    public class Notification_Handler
    {
        private readonly INotificationRepository _notificationRepository;
        public Notification_Handler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        public void Add(string typeNotification, string name, DateTime data, int duration)
        {
            _notificationRepository.Add(new Notification(typeNotification) { NotificationName = name,
                                                                             NotificationDateTime_Data = data,
                                                                             NotificationDateTime_Duration = duration});
            _notificationRepository.SaveFile();
        }

        public void Delete(string name)
        {
            _notificationRepository.Delete(name);
            _notificationRepository.SaveFile();
        }

        public void Browse()
        {
            _notificationRepository.Browse().ForEach(i => Console.WriteLine("Название события: " + i.NotificationName +
                                                                            "\nДата начала: " + i.NotificationDateTime_Data +
                                                                            "\nПродолжительность: " + i.NotificationDateTime_Duration + " часа \n"));
        }

        public Notification FindByName(string name)
        {
            var notification = _notificationRepository.FindByName(name) ?? throw new Exception("Уведомление не найдено");
            Console.WriteLine("Название события: " + notification.NotificationName
                                + "\nДата начала: " + notification.NotificationDateTime_Data
                                + "\nПродолжительность: " + notification.NotificationDateTime_Duration + " часа \n");
            return notification;
        }

        public Notification Edit(string name)
        {
            var notification = _notificationRepository.FindByName(name);
            Console.WriteLine("Название события: " + notification.NotificationName
                                + "\nДата начала: " + notification.NotificationDateTime_Data
                                + "\nПродолжительность: " + notification.NotificationDateTime_Duration + " часа \n");
            var notify = _notificationRepository.Edit(name);
            _notificationRepository.SaveFile();
            return notify;
        }
    }
}
