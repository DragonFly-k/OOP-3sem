using System;

namespace _11
{
    class Product
    {
        private string name;
        private int upc;
        private int price;
        private int date;
        private int count;
        private const int MAX_ID = 99;
        public Product(string name, int upc, int price, int count)
        {
            if (!string.IsNullOrEmpty(name))
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
        public override string ToString()
        {
            return $"\nНазвание: {Name}\nЦена: {Price}\nКоличество: {Count}";
        }
    }
}