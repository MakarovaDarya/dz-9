using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public class employee
    {
        public string name { get; }
        public string jobtitle { get; }
        public employee(string name,string jobtitle)
        {
            this.name = name;
            this.jobtitle = jobtitle;
        }
    public class Worker
        {
            public string Name;
            public string Jobtitle; 
            public Task task;
            public Task Task
            {
                get { return task; }
            }
            public Worker(string Name,string JobTitle)
            {
                this.Name = Name;
                this.Jobtitle = JobTitle;
            }
        }
    public string Print()
        {
            return $"{name}, {jobtitle}";
        }
        public static void GiveTask(List<Worker> workers, List<Task> tasks)
        {
            var z = new List<Task>();
            z.AddRange(tasks);
            foreach (var worker in workers)
            {
                for (int i = 0; i < z.Count; i++)
                {
                    Console.WriteLine($"Задача: {z[i]} \nДана сотруднику {worker}");
                    Console.WriteLine("Работоник будет выполнять эту задачу?");
                    string answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "да":
                            worker.task = z[i];
                            Task.ChangeStatus(worker, z[i]);
                            Console.WriteLine("Работник взял задачу");
                            z.Remove(z[i]);
                            break;
                        case "нет":
                            Console.WriteLine("Выберите действие (1.Отклонить\n2.Удалить\n3.Отдать задание другому");
                            string answer2 = Console.ReadLine();
                            switch (answer2)
                            {
                                case "1":
                                    Console.WriteLine("Тимлид отклонил задачу");
                                    break;
                                case "2":
                                    tasks.Remove(worker.task);
                                    break;
                                case "3":
                                    Console.WriteLine("Выберите другую задачу");
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}
