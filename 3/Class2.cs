using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{  
    partial class Product
    {
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("Объект null");
            }
            Product product = obj as Product;
            return product.Name == Name && product.Price == Price;
        }

        public override int GetHashCode()
        {
            return Price + Count;
        }

        public override string ToString()
        {
            return $"\nНазвание: {Name}\nЦена: {Price}\nКоличество: {Count}\nПроизодитель: {Fabric}";
        }
    }
}
