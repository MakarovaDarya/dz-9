using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    public enum Status
    {
        Проект, Исполняется, Закрыт
    }
    internal class project
    {
        public projectCustomer customer { get; set; }
        public string Description { get; set; }
        public employee TimLid { get; set; }    
        public DateTime deadline { get; set; }  
        public Status status { get; set; }
        List<Task> tasks;
        public project(projectCustomer customer,string Description, employee TimLid, DateTime deadline)
        {
            this.customer = customer;
            this.Description = Description;
            this.TimLid = TimLid;
            this.deadline = deadline;
            status=Status.Проект;
        }    
        public void Addtasks(List<Task> tasks)
        {
            this.tasks = tasks;
        }
        public void CloseProject(DateTime date,DateTime deadLine)
        {
            status = Status.Закрыт;
            Console.WriteLine($"Дата завершения проекта:{date}\nСрок выполнения: {deadline}");
            if (date > deadline)
            {
                Console.WriteLine("Проект сдан не вовремя");
            }
            else
            {
                Console.WriteLine("Проект принят");
            }

        }
        

    }
}
