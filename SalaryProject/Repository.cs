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

        public Report ReportUser { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public Repository()
        {
            UserDb = new List<User>();
            ReportUser = new Report();
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

        /// <summary>
        /// Выбор действия сотрудника
        /// </summary>
        /// <param name="position"></param>
        /// <param name="number"></param>
        public void ActionUser(string position, int number)
        {
            switch (position)
            {
                case "руководитель":
                    if (number == 1) AddNewUser();  // Добавить сотрудник
                    //if (number == 2) AddNewUser();  // Посмотреть отчёт по всем сотрудникам
                    if (number == 3) ReportByUser();  // Посмотреть отчет по конкретному сотруднику
                    if (number == 4) AddTime();     // Добавить часы работы
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

        /// <summary>
        /// Добавлние времени сотруднику
        /// </summary>
        public void AddTime()
        {
            Console.WriteLine("Введите имя сотрудника, которому хотите добавить время");
            string name = Console.ReadLine();
            Console.WriteLine();
            if (FindIndex(name) >= 0)
            {
                Console.WriteLine($"Введите дату на которую Вы хотите добавить отработанные часы. Сегодня: {DateTime.Now.ToShortDateString()}");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Введите количество отработанных часов:");
                int time = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите комментарий:");
                string comment = Console.ReadLine();

                ReportUser.AddReport(date, name, UserDb[FindIndex(name)].Position, time, comment);
            }
            else Console.WriteLine("Такой сотрудник не найден в базе!");
        }

        public void ReportByUser()
        {
            Console.WriteLine("Введите имя сотрудника, по которому необходимо сформировать отчёт:");
            string name = Console.ReadLine();
            int index = FindIndex(name);
            if (index >= 0)
            {
                Console.WriteLine($"Введите период за который необходимо сформировать отчёт. Сегодня: {DateTime.Now.ToShortDateString()}");
                Console.WriteLine($"Введите начальную дату:");
                DateTime dateStart = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine($"Введите конечную дату:");
                DateTime dateStop = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Отчёт по сотруднику: {name} за период с {dateStart.ToShortDateString()} по {dateStop.ToShortDateString()}");

                string position = UserDb[index].Position;
                List<string> list = new List<string>();
                if (position == "руководитель") list = ReportUser.ManagerReport;
                else if (position == "сотрудник") list = ReportUser.EmployeeReport;
                else list = ReportUser.FreelancerReport;

                string line;
                string[] data;
                double totalTimeWork = 0;

                for (int i = 0; i < list.Count; i++)
                {
                    line = list[i];
                    data = line.Split(',');

                    if ((Convert.ToDateTime(data[0]) >= dateStart) && (Convert.ToDateTime(data[0]) <= dateStop) && name == data[1])
                    {
                        Console.WriteLine($"{data[0]}, {data[2]} часов, {data[3]}");
                        totalTimeWork += Convert.ToInt32(data[2]);
                    }
                }

                Console.WriteLine($"Итого: {totalTimeWork} часов, заработано: {UserDb[index].GetSalary(totalTimeWork)}");

            }
            else Console.WriteLine("Такой сотрудник не найден в базе!");
        }
    }
}
