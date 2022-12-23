using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static homework.employee;

namespace homework
{
    public class Report
    {
        public string text;
        public DateTime deadline;
        public Worker worker;
        public Report(string text, DateTime deadline, Worker worker)
        {
            this.text = text;
            this.deadline = deadline;
            this.worker = worker;
        }
        public static DateTime date()
        {
            return new DateTime(2022, 12, 1);
        }
        public static Report CreateReport(Worker worker)
        {
            Console.WriteLine("Напишите очёт");
            string text = Console.ReadLine();
            Task.StatusReport(worker);

            return new Report(text, date(), worker);
        }
        public void Print()
        {
            Console.WriteLine($"{text}");
        }
    }
}
