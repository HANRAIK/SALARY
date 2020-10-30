using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    abstract class Person
    {
        public string Name { get; set; }

        public int Salary { get; set; }

        public int WorkTime { get; set; }

        public DateTime date { get; set; }

        public string position { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public virtual void GetReport(string name, DateTime periodStart, DateTime periodStop)
        {

        }

        public virtual void GetTotalWorkTime(string name, DateTime periodStart, DateTime periodStop)
        {

        }
    }
}
