﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Employee : User
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        public Employee (string name): base(name)
        {
            Position = "сотрудник";
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
            Console.WriteLine("(2). Добавить свои отработанные часы работы (Вы можете добавлять часы задним числом)");
            Console.WriteLine("(3). Выход из программы");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

        public override double GetSalary(double workTime)
        {
            double salary;
            if (workTime > 160)
            {
                double overTime = workTime - 160;
                salary = 120_000 + (overTime / 160 * 40_000);
            }
            else
            {
                salary = workTime / 160 * 120_000;
            }
            return salary;
        }
    }
}
