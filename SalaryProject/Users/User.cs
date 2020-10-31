using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    abstract class User
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}, {Position}";
        }

        /// <summary>
        /// Вывод функицонала сотрудника на экран 
        /// </summary>
        public virtual void PrintScreen() { }

    }
}
