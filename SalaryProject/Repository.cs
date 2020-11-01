using Microsoft.TeamFoundation.Client.CommandLine;
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
                Console.Write("Введите имя нового сотрудника: ");
                string nameNewUser = Console.ReadLine();
                Console.Write("Введите роль нового сотрудника: ");
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
                Console.Write("Продолжить ввод новых сотрудников? (н/д) ");
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
        public void ActionUser(string name, string position, int number)
        {
            switch (position)
            {
                case "руководитель":
                    if (number == 1) AddNewUser();  // Добавить сотрудник
                    if (number == 2) ReportByAllUser();  // Посмотреть отчёт по всем сотрудникам
                    if (number == 3) ReportByUser(name, position);  // Посмотреть отчет по конкретному сотруднику
                    if (number == 4) AddTime(name, position);     // Добавить часы работы
                    //if (number == 5) Environment.Exit(0); 
                    break;
                case "сотрудник":
                    if (number == 1) ReportByUser(name, position);  // Посмотреть свои отработанные часы и зарплату за период
                    if (number == 2) AddTime(name, position);  // Добавить свои отработанные часы работы (Вы можете добавлять часы задним числом)
                    //if (number == 3) Environment.Exit(0);
                    break;
                case "фрилансер":
                    if (number == 1) ReportByUser(name, position);  // Посмотреть свои отработанные часы и зарплату за период

                    // Добавить свои отработанные часы работы
                    // Вы можете добавлять часы задним числом не ранее, чем за два дня от текущего времени.
                    // Если между текущем днём и тем днем в какой фрилансер хочет вписать часы прошло больше двух дней - не даём это сделать.
                    if (number == 2) AddTime(name, position);
                    //if (number == 3) Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Такая роль не предусмотрена штатным распиманием!");
                    break;
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Добавление времени сотруднику
        /// </summary>
        public void AddTime(string nameUser, string positionUser)
        {
            string name;

            if (positionUser == "руководитель")
            {
                Console.Write("Введите имя сотрудника, которому хотите добавить время: ");
                name = Console.ReadLine();
            }
            else name = nameUser;

            Console.WriteLine();
            if (FindIndex(name) >= 0)
            {
                Console.WriteLine($"Введите дату на которую Вы хотите добавить отработанные часы. Сегодня: {DateTime.Now.ToShortDateString()}");
                DateTime date = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Введите количество отработанных часов: ");
                int time = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите комментарий: ");
                string comment = Console.ReadLine();

                if (positionUser == "фрилансер")
                {
                    if (((DateTime.Now - date).TotalDays <= 2) && ((DateTime.Now - date).TotalDays > 0))  ReportUser.AddReport(date, name, UserDb[FindIndex(name)].Position, time, comment);
                    else if (((DateTime.Now - date).TotalDays < 0))
                    {
                        Console.WriteLine();
                        Console.WriteLine("ВНИМАНИЕ!!! ЧАСЫ НЕ ДОБАВЛЕНЫ! Вы не можете добавлять часы наперёд!");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("ВНИМАНИЕ!!! ЧАСЫ НЕ ДОБАВЛЕНЫ! Вы можете добавлять часы задним числом не ранее, чем за два дня от текущего времени!");
                        Console.WriteLine();
                    }     
                }
                else
                {
                    if (((DateTime.Now - date).TotalDays < 0))
                    {
                        Console.WriteLine();
                        Console.WriteLine("ВНИМАНИЕ!!! ЧАСЫ НЕ ДОБАВЛЕНЫ! Вы не можете добавлять часы наперёд!");
                        Console.WriteLine();
                    }
                    else ReportUser.AddReport(date, name, UserDb[FindIndex(name)].Position, time, comment);
                } 
                    
            }
            else Console.WriteLine("Такой сотрудник не найден в базе!");
        }

        /// <summary>
        /// Посмотреть отчет по конкретному сотруднику
        /// </summary>
        public void ReportByUser(string nameUser, string positionUser)
        {
            string name;

            if (positionUser == "руководитель")
            {
                Console.Write("Введите имя сотрудника, по которому необходимо сформировать отчёт: ");
                name = Console.ReadLine();
            }
            else name = nameUser;    

            int index = FindIndex(name);
            if (index >= 0)
            {
                Console.WriteLine($"Введите период за который необходимо сформировать отчёт. Сегодня: {DateTime.Now.ToShortDateString()}");
                Console.Write($"Введите начальную дату: ");
                DateTime dateStart = Convert.ToDateTime(Console.ReadLine());
                Console.Write($"Введите конечную дату: ");
                DateTime dateStop = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine($"Отчёт по сотруднику: {name} за период с {dateStart.ToShortDateString()} по {dateStop.ToShortDateString()}");
                Console.WriteLine("-------------------------------------------------------------------------");

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

                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine($"Итого: {totalTimeWork} часов, заработано: {UserDb[index].GetSalary(totalTimeWork)}");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine();

            }
            else Console.WriteLine("Такой сотрудник не найден в базе!");
        }

        /// <summary>
        /// Посмотреть отчёт по всем сотрудникам
        /// </summary>
        public void ReportByAllUser()
        {
            Console.WriteLine($"Введите период за который необходимо сформировать отчёт. Сегодня: {DateTime.Now.ToShortDateString()}");
            Console.Write($"Введите начальную дату: ");
            DateTime dateStart = Convert.ToDateTime(Console.ReadLine());
            Console.Write($"Введите конечную дату :");
            DateTime dateStop = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Отчёт за период с {dateStart.ToShortDateString()} по {dateStop.ToShortDateString()}");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();

            List<string> list = new List<string>();
            double totalAllTimeWork = 0;
            double totalAllSalary = 0;

            for (int i = 0; i < UserDb.Count; i++)
            {
                switch (UserDb[i].Position)
                {
                    case "руководитель":
                        list = ReportUser.ManagerReport;
                        break;
                    case "сотрудник":
                        list = ReportUser.EmployeeReport;
                        break;
                    case "фрилансер":
                        list = ReportUser.FreelancerReport;
                        break;
                }

                string line = string.Empty;
                string[] data = null; 
                string name = UserDb[i].Name; //////////////////////////
                double totalUserTimeWork = 0;

                for (int j = 0; j < list.Count; j++)
                {
                    line = list[j];
                    data = line.Split(',');

                    if ((Convert.ToDateTime(data[0]) >= dateStart) && (Convert.ToDateTime(data[0]) <= dateStop) && name == data[1])
                    {
                        totalUserTimeWork += Convert.ToInt32(data[2]);
                    }
                }
                var totalUserSalary = UserDb[i].GetSalary(totalUserTimeWork);
                Console.WriteLine($"{name} отработал {totalUserTimeWork} часов и заработал за период {totalUserSalary}");
                totalAllTimeWork += totalUserTimeWork;
                totalAllSalary += totalUserSalary;
            }
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine($"Всего часов отработано за период {totalAllTimeWork}, сумма к выплате {totalAllSalary}");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void EndApp() { }
    }
}
