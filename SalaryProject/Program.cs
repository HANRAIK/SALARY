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
            Console.WriteLine("Дорый день!");
            Console.Write("Введите своё имя: ");
            string name = Console.ReadLine();

            // Здесь будет алгоритм поиска

            if (name == "админ")
            {
                Console.WriteLine($"Здравствуйте, {name}!");
                Console.WriteLine("Ваша роль: {руководитель}");
                Console.WriteLine("Выбирите желаемое действие:");
                Console.WriteLine("(1). Добавить сотрудника");
                Console.WriteLine("(2). Посмотреть отчёт по всем сотрудникам");
                Console.WriteLine("(3). Посмотреть отчет по конкретному сотруднику");
                Console.WriteLine("(4). Добавить часы работы");
                Console.WriteLine("(5). Выход из программы");
            }

            Console.WriteLine();

            // Обработчик "(1). Добавить сотрудника"
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                char key = 'д';
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите имя нового сотрудника:");
                    string nameNewUser = Console.ReadLine();
                    Console.WriteLine("Введите роль нового сотрудника");
                    string positionNewUser = Console.ReadLine();
                    db.AddNewUser(nameNewUser, positionNewUser);
                    Console.WriteLine();
                    Console.WriteLine("Продолжить ввод новых сотрудников? (н/д)");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("//------------------------------------------------//");
            Console.WriteLine("Список всех сотрудников:");
            Console.WriteLine("//------------------------------------------------//");
            db.PrintUsersDb();
            Console.WriteLine("//------------------------------------------------//");

            Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("dataUser.csv", true, Encoding.Unicode))
            {
                foreach (var item in db.UserDb)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }
}
