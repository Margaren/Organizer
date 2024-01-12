using System;
using System.Collections.Generic;
using System.Xml;

namespace Organizer_2
{
    internal class NotificationRepository : INotificationRepository
    {

        XmlDocument _document = new XmlDocument();
        private readonly string _fileName;
        public NotificationRepository(string fileName)
        {
            _fileName = fileName;
            _document.Load("Notification.xml");
        }

        public List<Notification> Browse()
        {

            List<Notification> list = new List<Notification>();
            foreach (XmlNode take in _document.DocumentElement)
            {
                string Name = take["Name"].InnerText;
                DateTime Data = DateTime.Parse(take["Data"].InnerText);
                int Duration = Int32.Parse(take["Duration"].InnerText);

                list.Add(new Notification(take["Type"].InnerText)
                {
                    NotificationName = Name,
                    NotificationDateTime_Data = Data,
                    NotificationDateTime_Duration = Duration,
                });
                  
            }
            return list;
        }

        public void SaveFile()
        {
            _document.Save(_fileName);
        }

        public void Add(Notification notification)
        {
            XmlElement newFilter = _document.CreateElement("Notification");

            XmlElement newName = _document.CreateElement("Name");
            newName.InnerText = notification.NotificationName;
            newFilter.AppendChild(newName);

            XmlElement newData = _document.CreateElement("Data");
            newData.InnerText = notification.NotificationDateTime_Data.ToString();
            newFilter.AppendChild(newData);

            XmlElement newDuration = _document.CreateElement("Duration");
            newDuration.InnerText = notification.NotificationDateTime_Duration.ToString();
            newFilter.AppendChild(newDuration);

            XmlElement newType = _document.CreateElement("Type");
            newType.InnerText = notification.TypeOfNotification;
            newFilter.AppendChild(newType);

            _document.DocumentElement.AppendChild(newFilter);
        }

        public Notification FindByName(string name)
        {
            XmlNode root = _document.DocumentElement;
            XmlNode selectedNotification = root.SelectSingleNode(string.Format("Notification[Name='{0}']", name));


            if (selectedNotification == null)
                throw new Exception("Объект не найден");

            var notification = new Notification(selectedNotification["Type"].InnerText)
            {
                NotificationName = selectedNotification["Name"].InnerText,
                NotificationDateTime_Data = DateTime.Parse(selectedNotification["Data"].InnerText),
                NotificationDateTime_Duration = int.Parse(selectedNotification["Duration"].InnerText)
            };
            return notification;
        }

        public Notification Edit(string name)
        {
            XmlNode root = _document.DocumentElement;
            XmlNode node = root.SelectSingleNode(string.Format("Notification[Name='{0}']", name));

            
            string[] listEvenet = new string[] {
                "Желаете отредактировать выбранное событие?",
                "Изменить название?" ,
                "Изменить дату?" ,
                "Изменить продолжительность?" ,
                "Изменить тип?" };
            bool isContinue = true;

            for (int i = 0; i < listEvenet.Length; i++)
            {
                if (isContinue == false)
                    break;

                Console.WriteLine(listEvenet[i]);
                Console.WriteLine("Да - 1, нет - 0");
                var choice = Console.ReadLine();

                switch (i)
                {
                    case 0:
                        if (choice == "0")
                            isContinue = false;
                        continue;
                }
                if (choice == "0")
                    continue;

                switch (i)
                {
                    case 1:
                        Console.WriteLine($"Текущее имя: {node["Name"].InnerText}");
                        node["Name"].InnerText = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine($"Текущая дата: {node["Data"].InnerText}");
                        node["Data"].InnerText = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine($"Текущая продолжительность: {node["Duration"].InnerText}");
                        node["Duration"].InnerText = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine($"Текущий тип: {node["Type"].InnerText}");
                        node["Type"].InnerText = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Необработано!");
                        break;
                }

                

            }

            var notification = new Notification(node["Type"].InnerText)
            {
                NotificationName = node["Name"].InnerText,
                NotificationDateTime_Data = DateTime.Parse(node["Data"].InnerText),
                NotificationDateTime_Duration = int.Parse(node["Duration"].InnerText)
            };

            return notification;
        }

        public void Delete(string name)
        {
            XmlNode root = _document.DocumentElement;
            XmlNode node = root?.SelectSingleNode(string.Format("Notification[Name='{0}']", name));  

            if (node != null)
            {
                node?.ParentNode.RemoveChild(node);
            }
        }
    }
}
