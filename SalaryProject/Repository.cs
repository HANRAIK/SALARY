using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Repository
    {
        /// <summary>
        /// Список всех имен сотрудников
        /// </summary>
        public List<User> UserDb { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Repository()
        {
            UserDb = new List<User>();
        }

        /// <summary>
        /// Добавление нового сотрудника в базу
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public void AddNewUser()
        {
            char key = 'д';
            do
            {
                Console.WriteLine();
                Console.WriteLine("Введите имя нового сотрудника:");
                string nameNewUser = Console.ReadLine();
                Console.WriteLine("Введите роль нового сотрудника");
                string positionNewUser = Console.ReadLine();
                switch (positionNewUser)
                {
                    case "руководитель":
                        UserDb.Add(new Manager(nameNewUser));
                        break;
                    case "сотрудник":
                        UserDb.Add(new Employee(nameNewUser));
                        break;
                    case "фрилансер":
                        UserDb.Add(new Freelancer(nameNewUser));
                        break;
                    default:
                        Console.WriteLine("Такая роль не предусмотрена штатным распиманием!");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Продолжить ввод новых сотрудников? (н/д)");
                key = Console.ReadKey(true).KeyChar;
            } while (char.ToLower(key) == 'д');
        }

        /// <summary>
        /// Вывод на экран списка сотрудников
        /// </summary>
        public void PrintUsersDb()
        {
            foreach (var item in UserDb)
            {
                Console.WriteLine($"{item.Name}, {item.Position}");
            }
        }

        /// <summary>
        /// Возвращает индекс сотрудника в базе,если таковой будет найден. В противном случае, возвращает -1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FindIndex(string name)
        {
            for (int i = 0; i < UserDb.Count; i++)
            {
                if (UserDb[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }

        public void ActionUser(string position, int number)
        {
            switch (position)
            {
                case "руководитель":
                    if (number == 1) AddNewUser();
                    break;
                case "сотрудник":
                    
                    break;
                case "фрилансер":
                    
                    break;
                default:
                    Console.WriteLine("Такая роль не предусмотрена штатным распиманием!");
                    break;
            }
            Console.WriteLine();

        }
    }
}
