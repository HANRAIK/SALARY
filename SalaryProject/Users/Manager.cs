﻿using System;
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

    }
}
