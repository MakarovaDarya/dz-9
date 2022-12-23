using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static homework.employee;

namespace homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            employee Employee = new employee("Иван", "Иванов");
            int cWorkers = 10;
            List<Worker> workers = new List<Worker>(10)
            {
                new Worker("Петр","Петров"),
                new Worker("Сергей","Семенов"),
                new Worker("Алексей", "Ахмеев"),
                new Worker("Леонид", "Захаров"),
                new Worker("Александр", "Рябов"),
                new Worker("Константин", "Рыболов"),
                new Worker("Аркадий", "Иванов"),
                new Worker("Екатерина", "Лобачкова"),
                new Worker("София", "Егорова"),
                new Worker("Роман", "Петров"),
            };
            DateTime deadline = Task.date();
            projectCustomer customer = new projectCustomer("Валентин");
            List<Task> tasks = new List<Task>(cWorkers)
            {
                new Task("Сделать проектирование программы", deadline, Employee),
                new Task("Выполнить тестирование и отладку", deadline, Employee),
                new Task("Выполнить анализ требований", deadline, Employee),
                new Task("Сделать сортировку!", deadline, Employee),
                new Task("Оптимозировать работу программу", deadline, Employee),
                new Task("Создать черновик программы", deadline, Employee),
                new Task("Протестировать всю систему", deadline, Employee),
                new Task("Поддерживать всех работающих", deadline, Employee),
                new Task("Выработать требование к программе", deadline, Employee),
                new Task("Сделать корректировку кода и утвердить его", deadline, Employee)
            };
            project Project = new project(customer, "Напишите программу", Employee, deadline);
            Project.Addtasks(tasks);
            employee.GiveTask(workers, tasks);
            Console.WriteLine("Сдаем отчеты");
            DateTime date = DateTime.Now;
            int p = 0;

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(($"Отчёт за {i} месяц"));
                date = date.AddMonths(1);
                for (int k=0; k < workers.Count; k++)
                {
                    Console.WriteLine($"Работник {workers[k].Name} взялся за задачу <<{workers[k].Task.descriptions}>>");
                    Report Report = Report.CreateReport(workers[i]);
                    Console.WriteLine("Заказчик доволен работой?");
                    Console.WriteLine("Отчет: ");
                    Report.Print();
                    string answer = Console.ReadLine().ToLower();
                    switch (answer)
                    {
                        case "да":
                            Console.WriteLine($"Отчет за {i} месяц выолнен и принят");
                            Task.CloseTask(workers[k]);
                            Console.WriteLine($"Работник {workers[k].Name} отправил отчёт. \nСтатус задачи - {workers[i].Task.status}. \nДата выполнения: {date}.\nДата дедлайна на текущий месяц - {deadline}");
                            break;
                        case "нет":
                            Console.WriteLine($"Отчет на {i} месяц не закончен");
                            Report ReportNew = Report.CreateReport(workers[i]);
                            ReportNew.Print();
                            Console.WriteLine("На сколько дней просрочено задание: ");
                            int overdue = int.Parse(Console.ReadLine());
                            p += overdue;
                            Task.CloseTask(workers[k]);
                            Console.WriteLine($"Работник {workers[k].Name} отправил отчёт. \nСтатус задачи - {workers[i].Task.status}. \nДата выполнения: {date + TimeSpan.FromDays(overdue)}.\nДата дедлайна на текущий месяц - {deadline}");
                            break;
                    }
                }
                for (int l = 0; l < workers.Count; l++)
                {
                    Task.OpenTask(workers[l]);
                }
                Console.Clear();
            }
            Project.CloseProject(date + TimeSpan.FromDays(p), deadline);


        }
    }
}
