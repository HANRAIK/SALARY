using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class Report
    {
        public List<string> ManagerReport { get; set; }
        public List<string> EmployeeReport { get; set; }
        public List<string> FreelancerReport { get; set; }

        public void AddReport(DateTime date, string name, string position, int time, string comment)
        {
            string note = $"{date.ToShortDateString()},{name},{time},{comment}";

            switch (position)
            {
                case "руководитель":
                    ManagerReport.Add(note);
                    break;
                case "сотрудник":
                    EmployeeReport.Add(note);
                    break;
                case "фрилансер":
                    FreelancerReport.Add(note);
                    break;
            }
        }

    }
}
