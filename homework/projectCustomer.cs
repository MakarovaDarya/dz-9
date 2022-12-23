using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    internal class projectCustomer
    {
        public string name;
        public projectCustomer(string name)
        {
            this.name = name;
        }

        public void Print()
        {
            Console.WriteLine($"Заказчик - {name} ");
        }
    }
}
