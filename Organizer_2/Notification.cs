using System;

namespace Organizer_2
{
    public class Notification //Уведомление 
    {
        public int NotificationDateTime_Duration { get; set; }
        public DateTime NotificationDateTime_Data { get; set; }
        public String NotificationName { get; set; }
        public enum NotificationType { Event = 1, Birthday = 2, PhoneCall = 3, Task = 4 }
        public NotificationType TypeNotification { get; set; }
        public string TypeOfNotification { get; set; }
        public Notification (string type)
        {

            TypeOfNotification = type;
            switch (type)
            {
                case "Мероприятие":
                    TypeNotification = NotificationType.Event;
                    break;
                case "День рождения":
                    TypeNotification = NotificationType.Birthday;
                    break;
                case "Звонок":
                    TypeNotification = NotificationType.PhoneCall;
                    break;
                case "Задача":
                    TypeNotification = NotificationType.Task;
                    break;

            }
        }
    }

}
