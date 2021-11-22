using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    partial class Product
    {
        static int id;
        private string name;
        private int upc;
        static string fabric;
        private int price;
        private int date;
        private int count;

        //поля
        private readonly int ID;
        private const int MAX_ID = 99;

        //конструкторы
        public Product()
        {
            ID = GetHashCode();
        }

        public Product(string name, int count=55,  int price= 550)
        {
            if (!string.IsNullOrEmpty(name) && id <= MAX_ID)
            {
                this.name = name;
                this.count = count;
                this.price = price;
                id++;
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }

        public Product(string name, int upc, int price, int count) 
        {
            if (!string.IsNullOrEmpty(name) && id <= MAX_ID)
            {
                this.name = name;
                this.upc = upc;
                this.price = price;
                this.count = count;
            }
            else
            {
                Console.WriteLine("Некорректный ввод!");
            }
                
        }

        static Product()
        {
            fabric = "FOX";
        }

        ////// закрытый конструктор
        //private Product() { }

        // get and set
        public int Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;               
            }
        }
        public int Upc
        {
            get
            {
                return upc;
            }
            private set
            {
                if (value < 10)
                {
                    upc = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public string Fabric
        {
            get
            {
                return fabric;
            }
        }
        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value > 0)
                {
                    date = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value > 0)
                {
                    count = value;
                }
                else
                {
                    Console.WriteLine("Неверный формат!");
                }
            }
        }

        // методы
        public void ChangeFabric(ref string newFabric, out string fabric) 
        {
            fabric = newFabric;
            Console.WriteLine("Новая фабрика - " + fabric);
        }

        public static void PrintClassInfo()
        {
            Console.WriteLine($"Информация о классе:\nИмя класса: Product\nКоличество объектов: {id}\nМаксимальное количество: {MAX_ID}");
        }

    }
}
