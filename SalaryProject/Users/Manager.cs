using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Manager : User
    {
        public Manager (string name): base(name)
        {
            Position = "руководитель";
        }

        /// <summary>
        /// Вывод функицонала сотрудника на экран 
        /// </summary>
        public override void PrintScreen()
        {
            Console.WriteLine("Выбирите желаемое действие:");
            Console.WriteLine("(1). Добавить сотрудника");
            Console.WriteLine("(2). Посмотреть отчёт по всем сотрудникам");
            Console.WriteLine("(3). Посмотреть отчет по конкретному сотруднику");
            Console.WriteLine("(4). Добавить часы работы");
            Console.WriteLine("(5). Выход из программы");
        }
    }
}
