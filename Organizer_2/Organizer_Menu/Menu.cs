using System;
using Organizer_2;

namespace Organizer_Menu
{
    internal class Menu
    {
        public static void Main()
        {
            Console.WriteLine("Добро пожаловать в программу 'Органайзер'!");
            string fileName = @"Notification.xml";
            int answer = 1;
            while (answer != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Функции ежедневника:");
                Console.WriteLine("");
                Console.WriteLine("1. Добавить новое мероприятие или задачу в ежедневник");
                Console.WriteLine("2. Удалить событие");
                Console.WriteLine("3. Просмотреть список задач");
                Console.WriteLine("4. Поиск события по названию");
                Console.WriteLine("5. Редактировать событие");
                Console.WriteLine("");
                Console.WriteLine("Чтобы выбрать функцию ежедневника, введите её номер:");
                try
                {
                    UserConsole.Use(new Notification_Handler(NotificationRepositoryFactory.Create(fileName, NotificationRepositoryFactory.Type.Classic)), Convert.ToInt32(Console.ReadLine()), fileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine("");
                Console.WriteLine("Желаете продолжить работу?");
                Console.WriteLine("Да - 1, нет - 0");
                answer = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
