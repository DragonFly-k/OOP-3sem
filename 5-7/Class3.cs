using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    //7
    public class Nalog : Exception
    {
        private string message;
        public Nalog()
        {
            message = "\nБольшой налог";
        }
        public void PrintInfo()
        {
            Console.WriteLine(message);
        }
    }
    public class SUM : Exception
    {
        private string message;
        public SUM(string message)
        {
            this.message = message;
        }
        public void PrintInfo()
        {
            Console.WriteLine(message);
        }
    }
    public class Dolges : Exception
    {
        public void PrintInfo()
        {
            Console.WriteLine("ТЫ ДОЛЖНИК");
        }
    }
}
