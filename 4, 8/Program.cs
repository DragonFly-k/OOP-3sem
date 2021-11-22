using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program8
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> list1 = new List<string>();
                list1.Add("X");
                list1.Add("Y");
                list1.Add("Z");

                list1.Show();
                list1.Delete("X");
                list1.Show();

                List<string> list2 = new List<string>();
                Streams<string>.OutFile(@"D:\лабы\ооп\oop-3sem\4, 8\out.txt", ref list2);
                list2.Show();

                List<Kvitant> list3 = new List<Kvitant>();
                list3.Add(new Kvitant(58541541, 11054, 40));
                list3.Add(new Kvitant(25263521, 204440, 39));
                list3.Add(new Kvitant(52635221, 30042, 29));
                list3.Add(new Kvitant(45565555, 4550, 10));

                list3.Show();

                Streams<Kvitant>.InFile(@"D:\лабы\ооп\oop-3sem\4, 8\in.txt", ref list3);

            }
            finally
            {
                Console.WriteLine("The end!");
            }
            Console.ReadKey();
        }
    }
//class Program4
//    {
//        static void Main(string[] args)
//        {
//            List list1 = new List();
//            list1.AddNode("Y");
//            list1.AddNode("XX");
//            list1.AddNode("Z");

//            List list2 = new List();
//            list2.AddNode("Y");
//            list2.AddNode("XX");
//            list2.AddNode("Z");

//            list1.ShowInfo();
//            Console.Write("\n");
//            list2.ShowInfo();
//            Console.Write("\nequals : ");
//            Console.WriteLine(list1 == list2);
//            Console.Write("\n");

//            Node node = new Node();
//            node.Info = "R";
//            list1 = node + list1;
//            list1.ShowInfo();
//            Console.Write("\n");
//            list2.ShowInfo();
//            Console.Write("\nnot equals: ");
//            Console.WriteLine(list1 != list2);
//            Console.Write("\n");

//            list1--;
//            list1.ShowInfo();
//            Console.Write("\n");
//            list1 *= list2;
//            list1.ShowInfo();
//            Console.Write("\n");

//            List list3 = new List();
//            list3.AddNode("Vie");
//            list3.AddNode("gakjK");
//            list3.AddNode("jfFJf");
//            list3.AddNode("sdhS");
//            list3.AddNode("VSVfre");
//            list3.ShowInfo();
//            Console.Write("\n");

//            Console.WriteLine("Количество слов с заглавной буквой " + list3.CountFirstCapitalLetters());
//            Console.WriteLine("Повторяющиеся элементы в списке 3 = " + list3.CheckRepeatings());
//            Console.WriteLine("Повторяющиеся элементы в списке 2 = " + list2.CheckRepeatings());
//            Console.WriteLine("Количество элементов списка 3 =  " + StaticOperations.Count(list3));
//            Console.WriteLine( StaticOperations.ListString(list1));
//            Console.WriteLine("Самая длинная строка в списке 3" + StaticOperations.LongestInfo(list3));

//            string str = "mY NaMe Is KaTe";
//            Console.WriteLine(str + " изменено: " + StaticOperations.FormatText(str));
//            Console.ReadKey();
//        }
        
//    }
}
