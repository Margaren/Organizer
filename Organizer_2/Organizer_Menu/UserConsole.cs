using Organizer_2;
using System;

namespace Organizer_Menu
{
    public class UserConsole
    {
        public static void Use(Notification_Handler notificationHandler, int choice, string fileName)
        {
            string notificationName;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Создание нового события");
                    Console.WriteLine("Введите название события");
                    string name = Console.ReadLine();

                    Console.WriteLine("Введите дату начала события");
                    DateTime data = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Введите продолжительность события в часах");
                    int duration = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Введите тип события по порядковому номеру:\nМероприятие\nДень рождения\nЗвонок\nЗадача");
                    notificationHandler.Add(Console.ReadLine(), name, data, duration);
                    break;
                case 2:
                    Console.WriteLine("Удалить  событие");
                    Console.WriteLine("Введите точное название события для удаления");
                    notificationName = Console.ReadLine();
                    notificationHandler.Delete(notificationName);
                    break;
                case 3:
                    Console.WriteLine("Просмотр событий");
                    notificationHandler.Browse();
                    break;
                case 4:
                    Console.WriteLine("Поиск события по названию");
                    Console.WriteLine("Введите полное название события: ");
                    notificationHandler.FindByName(Console.ReadLine());
                    break;
                case 5:
                    Console.WriteLine("Редактирование события");
                    Console.WriteLine("Введите полное название события, которое хотите отредактировать: ");
                    notificationHandler.Edit(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Введённое значение некорректно. Пожалуйста, повторите попытку");
                    choice = Convert.ToInt32(Console.ReadLine());
                    break;
            }
        }
    }
}
