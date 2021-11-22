using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Product  milk = new Product("молоко");
                Product egg = new Product("яйца", 2222, 17);
                Product eggg = new Product("яйца", 2222, 17);
                Product salt = new Product();

                Product.PrintClassInfo();
                Console.WriteLine(milk.ToString());
                Console.WriteLine(egg.Equals(eggg));
                Console.WriteLine(milk.GetHashCode());
                string fabric = "milkov", newFabric;
                milk.ChangeFabric(ref fabric, out newFabric);

                Product[] product = new Product[6];
                product[0] = new Product("носки брестские", 800002, 4, 20);
                product[1] = new Product("носки хлопковые", 800222,  10, 15);
                product[2] = new Product("чулки", 803333,  3, 15);
                product[3] = new Product("колготки", 800322,  7, 5);
                product[4] = new Product("носки", 805555, 30, 89);
                product[5] = new Product("белые носки", 808888, 20, 8);

                foreach (Product item in product)
                {
                    if (item.Name.Contains("носки"))
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                Console.WriteLine("\nНоски цена которых <= 20:");
                foreach (Product item in product)
                {
                    if (item.Name.Contains("носки") && item.Price <= 20)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                var train = new Product("поезд");
                Console.WriteLine(train.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}