using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryProject
{
    class SerializeDb
    {
        /// <summary>
        /// Сохранение списка сотрудников в csv файл
        /// </summary>
        /// <param name="userDb"></param>
        public void SaveUser (List<User> userDb)
        {
            using (StreamWriter sw = new StreamWriter("dataUser.csv", false, Encoding.Unicode))
            {
                foreach (var item in userDb)
                {
                    sw.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Чтение списка сотрудников из csv файла
        /// </summary>
        /// <returns></returns>
        public List<User> ReadUser()
        {
            List<User> ru = new List<User>();

            if (File.Exists("dataUser.csv"))
            {
                using (StreamReader sr = new StreamReader("dataUser.csv", Encoding.Unicode))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        switch (data[1])
                        {
                            case " руководитель":
                                ru.Add(new Manager(data[0]));
                                break;
                            case " сотрудник":
                                ru.Add(new Employee(data[0]));
                                break;
                            case " фрилансер":
                                ru.Add(new Freelancer(data[0]));
                                break;
                            default:
                                Console.WriteLine("Такая роль не предусмотрена штатным распиcанием!");
                                break;
                        }
                    }

                }
            }
            
            return ru;
        }

        /// <summary>
        /// Сохранение отчёта в csv файл
        /// </summary>
        /// <param name="note"></param>
        public void SaveReport(List<string> note, string position)
        {
            string fileName = PositionFileReturn(position);

            //for (int i = 0; i < note.Count; i++)
            //{
            //    File.WriteAllText(fileName, note[i], Encoding.Unicode);
            //}


            if (note.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Unicode))
                {
                    for (int i = 0; i < note.Count; i++)
                    {
                        sw.WriteLine(note[i]);
                    }
                }
            }

        }

        /// <summary>
        /// Загрузка отчётов из csv файла
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public List<string> ReadReport(string position)
        {
            List<string> report = new List<string>();

            string fileName = PositionFileReturn(position);

            if (File.Exists(fileName) && (fileName != null))
            {
                using (StreamReader sr = new StreamReader(fileName, Encoding.Unicode))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        report.Add(line);
                    }
                }
            }
            return report;
        }

        /// <summary>
        /// По должности определяем из какого файла необходимо читать данные
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private string PositionFileReturn(string position)
        {
            switch (position)
            {
                case "руководитель":
                    return "ManagerReport.csv";
                case "сотрудник":
                    return "EmployeeReport.csv";
                case "фрилансер":
                    return "FreelancerReport.csv";
                default:
                    return null;
            }
        }

        public override string ToString()
        {
            return $"тыква";
        }
    }
}
