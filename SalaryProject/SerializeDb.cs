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
        /// Сохранение списка пользователей в csv файл
        /// </summary>
        /// <param name="userDb"></param>
        public void SaveUser (List<User> userDb)
        {
            using (StreamWriter sw = new StreamWriter("dataUser.csv", true, Encoding.Unicode))
            {
                foreach (var item in userDb)
                {
                    sw.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Чтение списка сотрудников из файла
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
                                //default:
                                //    Console.WriteLine("Такая роль не предусмотрена штатным распиманием!");
                                //    break;
                        }
                    }

                }
            }
            
            return ru;
        }
    }
}
