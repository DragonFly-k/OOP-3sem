using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            Programmer.LANG Language;
            Programmer programmer = new Programmer();
            List<string> LP = new List<string> { "Ruby", "C#", "Kotlin", "Pascal", "Python", "GoLang", "VisualBasic", "Dart", "JS", "Java" };

            Console.Write("Список: ");
            foreach (string item in LP)
            {
                Console.Write(item + "   ");
            }
            Console.WriteLine();

            programmer.Delete += list =>
            {
                Console.Write("Измененный: ");
                foreach (string item in LP)
                {
                    Console.Write(item + "   ");
                }
                Console.WriteLine();
            };

            programmer.Mutate += list =>
            {
                Console.Write("Перестановка: ");
                foreach (string item in LP)
                {
                    Console.Write(item + "   ");
                }
                Console.WriteLine();
            };

            Language = programmer.dele;
            Language += programmer.Perenos;
            Language += programmer.Perenos;
            Language += programmer.Perenos;

            Language(LP);

            Func<string, string> A;
            string str = "Computers; ArE t;he MOST; rapidly ..chaNgING sp;here OF mo;dern TEChnol;ogy.";
            Console.WriteLine($"\n\nСтрока: {str}");
            A = StringEditor.RemovePunctuation;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = StringEditor.AddSymbol;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = StringEditor.ToUpper;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = StringEditor.ToLower;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");
            A = StringEditor.RemoveSpace;
            Console.WriteLine($"{A.Method.Name}: {A(str)}");

            Console.ReadKey();
        }
    }
}
