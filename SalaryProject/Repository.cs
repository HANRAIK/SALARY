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
        public void AddNewUser(string name, string position)
        {
            switch (position)
            {
                case "руководитель":
                    UserDb.Add(new Manager(name));
                    break;
                case "сотрудник":
                    UserDb.Add(new Employee(name));
                    break;
                case "фрилансер":
                    UserDb.Add(new Freelancer(name));
                    break;
                default:
                    Console.WriteLine("Такая роль не предусмотрена штатным распиманием!");
                    break;
            }
                


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
    }
}
