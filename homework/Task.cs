using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static homework.employee;

namespace homework
{ 
    public enum StatusTask
    {
        назначена, в_работе, на_проверке, выполнена

    }
    public class Task
    {
        public string descriptions { get; set; }
        public DateTime deadLine { get; set; }
        public StatusTask status { get; set; }
        public Worker worker { set; get; }
        public employee Employee { get; set; }
        public Report report { get; set; }

        public Task(string descriptions, DateTime deadLine, employee Employee)
        {
            this.descriptions = descriptions;
            this.deadLine = deadLine;
            this.Employee = Employee;
        }
        public string Print()
        {
            return $"{descriptions}, {deadLine}";
        }
        public Worker Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public static DateTime date()
        {
            return new DateTime(2022, 12, 1);
        }
        public static void ChangeStatus(Worker worker,Task task)
        {
            if (worker.Task.status == StatusTask.назначена)
            {
                worker.Task.status = StatusTask.в_работе;
                task.Worker = worker;
            }
        }
        public void PrintT()
        {
            Console.WriteLine($"Задача: {descriptions}, Срок:{date()}");
        }
        public static void StatusReport(Worker worker)
        {
            if (worker.Task.status == StatusTask.в_работе)
            {
                worker.Task.status = StatusTask.на_проверке;
            }
        }
        public static void OpenTask(Worker worker)
        {
            if (worker.Task.status == StatusTask.выполнена)
            {
                worker.Task.status = StatusTask.на_проверке;
            }
        }
        public static void CloseTask(Worker worker)
        {
            if (worker.Task.status == StatusTask.на_проверке)
            {
                worker.Task.status = StatusTask.выполнена;
            }
        }

    }
}
