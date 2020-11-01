using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Freelancer : User
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        public Freelancer(string name): base(name)
        {
            Position = "фрилансер";
        }

        /// <summary>
        /// Вывод функицонала сотрудника на экран 
        /// </summary>
        public override void PrintScreen()
        {
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Выбирите желаемое действие:");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("(1). Посмотреть свои отработанные часы и зарплату за период");

            // Если между текущем днём и тем днем в какой фрилансер хочет вписать часы прошло больше двух дней - не даём это сделать.
            Console.WriteLine("(2). Добавить свои отработанные часы работы");
            Console.WriteLine("(Вы можете добавлять часы задним числом не ранее, чем за два дня от текущего времени.)");

            Console.WriteLine("(3). Выход из программы");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        public override double GetSalary(double workTime)
        {
            double salary = workTime * 1000;
            return salary;
        }
    }
}
