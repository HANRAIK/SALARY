using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Employee : User
    {
        public Employee (string name): base(name)
        {
            Position = "сотрудник";
        }
    }
}
