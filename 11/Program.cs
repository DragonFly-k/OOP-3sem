using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            Console.WriteLine("Введите длину месяца: ");
            int n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<string> lengthN = from month in months
                                          where month.Length == n
                                          select month;
            var WinterSummer = months.Where((month, i) => i < 2 || i > 4 && i < 8 || i == 11);
            var alphabetOrder = months.OrderBy(month => month);
            var withU = months.Where(month => month.Contains("u") && month.Length > 3);

            foreach (string s in lengthN)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in WinterSummer)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in alphabetOrder)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in withU)
            { Console.WriteLine(s); }
            Console.WriteLine();


            List<Product> products = new List<Product>() {
                new Product("napitok Coca-cola ",1253588,135,255),
                new Product("napitok Coca-cola zero ",12563588,36,25),
                new Product("napitok Pepsi cola ",222588,45,255),
                new Product("napitok Fanta ",1556988,35,255),
                new Product("napitok 7UP ",1253588,135,205),
                new Product("napitok Schwepps ",12558248,5,26855),
                new Product("napitok Baykail ",8956668,16,425),
                new Product("napitok Byratino ",165568,185,5),
                new Product("napitok Snezhock ",45685268,8,895),
                new Product("napitok Rosinka ",1563588,25,1255)
            };

            var napitok = products.Where(e => e.Name.Contains("napitok"));
            var NapitocPrice = products.Where(e => e.Name.Contains("napitok") &&  e.Price<20);
            var ColPrice = products.Where(e => e.Price > 100).Count();
            var maxPrice = products.Max(e => e.Price);
            var alphabetе = products.OrderBy(e => e.Name);
            var countt = products.OrderBy(e => e.Count);

            var five = products.Where(e => e.Upc != 1253588).Where(e => e.Name.Contains("cola")).OrderByDescending(e => e.Price).Select(e => e.Name += ';').Take(3);

            Console.WriteLine("------ список товаров для заданного наименования  ------");
            foreach (var s in napitok)
            { Console.WriteLine(s); }
            Console.WriteLine();

            Console.WriteLine("-----список товаров для заданного наименования, цена которых не превосходит 20 ------");
            foreach (var s in NapitocPrice)
            { Console.WriteLine(s); }
            Console.WriteLine();

            Console.WriteLine("-----количество наименований цена которых больше 100 ------");
            Console.WriteLine(ColPrice);
            Console.WriteLine();


            Console.WriteLine("----- максимальная цена ------");
            Console.WriteLine(maxPrice);
            Console.WriteLine();

            Console.WriteLine("------ упорядоченный по алфавиту ---------");
            foreach (var s in alphabetе)
            { Console.WriteLine(s); }
            Console.WriteLine();

            Console.WriteLine("----- упорядоченный по количеству ---------");
            foreach (var s in countt)
            { Console.WriteLine(s);}

            Console.WriteLine("------ свой запрос ---------");
            foreach (var s in five)
            { Console.WriteLine(s); }
            Console.WriteLine();

            List<Product> prod = new List<Product>() {
                new Product("Lays",153588,135,255),
                new Product("Pringles",1255418,35,25),
                new Product("Esterella",22238588,16,255),
                new Product("Onega",15639888,25,1255)
            };

            var result = products.Join(
                prod,
                e => e.Price,
                c => c.Price,
                (c, e) => new { Napitoc = c.Name, Chips= e.Name, price = c.Price });
            Console.WriteLine("-------Join----------");
            foreach (var item in result)
            {
                Console.WriteLine($"Цена: ${item.price}\tНапиток: {item.Napitoc}\tЧипсы: {item.Chips}");
            }

            Console.ReadKey();
        }
    }
}
