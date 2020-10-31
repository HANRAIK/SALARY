using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Freelancer : User
    {
        public Freelancer(string name): base(name)
        {
            Position = "фрилансер";
        }
    }
}
