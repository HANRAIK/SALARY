using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository db = new Repository();
            SerializeDb sdb = new SerializeDb();

            // Загрузка списка сотрудников из .CSV
            db.UserDb = sdb.ReadUser();

            #region Вывод списка сотрудников на экран
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("//------------------------------------------------//");
            Console.WriteLine("Список всех сотрудников:");
            Console.WriteLine("//------------------------------------------------//");
            db.PrintUsersDb();
            Console.WriteLine("//------------------------------------------------//");
            #endregion

            Console.ReadLine();

            Console.WriteLine("Дорый день!");

            int index; // индекс сотрудника в базе
            string name; // имя сотрудника, которое вводит пользователь

            // Ввод имени и поиск пользователя в базе по имени
            do
            {
                Console.Write("Введите своё имя: ");
                name = Console.ReadLine();
                name = name.ToLower();

                index = db.FindIndex(name);

                // Поиск пользователя в базе
                if (index >= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Здравствуйте, {db.UserDb[index].Name}!");
                    Console.WriteLine($"Ваша роль: {db.UserDb[index].Position}");
                    Console.WriteLine();
                    db.UserDb[index].PrintScreen();
                }
                else if (name == "админ")
                {
                    Console.WriteLine($"Здравствуйте, Администратор!");
                    Console.WriteLine("Выбирите желаемое действие:");
                    Console.WriteLine("(1). Добавить сотрудника");
                    Console.WriteLine("(2). Посмотреть отчёт по всем сотрудникам");
                    Console.WriteLine("(3). Посмотреть отчет по конкретному сотруднику");
                    Console.WriteLine("(4). Добавить часы работы");
                    Console.WriteLine("(5). Выход из программы");
                    index = 6;
                }
                else
                {
                    Console.WriteLine("Такой пользователь не найден!");
                    Console.WriteLine();
                }

            } while (index < 0);

            Console.WriteLine();

            int number = Convert.ToInt32(Console.ReadLine());

            db.ActionUser(db.UserDb[index].Position, number);

            #region Вывод списка сотрудников на экран
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("//------------------------------------------------//");
            Console.WriteLine("Список всех сотрудников:");
            Console.WriteLine("//------------------------------------------------//");
            db.PrintUsersDb();
            Console.WriteLine("//------------------------------------------------//");
            #endregion

            Console.ReadLine();

            // Сохранение списка сотрудников в .CSV
            sdb.SaveUser(db.UserDb);
        }
    }
}
