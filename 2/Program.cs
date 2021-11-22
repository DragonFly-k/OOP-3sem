using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1a
            byte Byte = 255;
            sbyte SByte = 127;
            short Short = 1;
            ushort UShort = 2;
            int Int = 3;
            uint UInt = 4;
            long Long = 5;
            ulong ULong = 6;
            char Char = 'k';
            bool Bool = true;
            float Float = 1.23f;
            double Double = 4.88;
            decimal Decimal = 7.58M;

           
            Console.WriteLine($"Типы:\nbyte\t{Byte}\nsbyte\t{SByte}\nshort\t{Short}\nushort\t{UShort}\nint\t{Int}\nuint\t{UInt}" +
            $"\nlong\t{Long}\nulong\t{ULong}\nchar\t{Char}\nbool\t{Bool}\nfloat\t{Float}\ndouble\t{Double}\ndecimal\t{Decimal}");
            //Console.Write("\nВведите int: ");
            //Int = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine($"Типы:\nbyte\t{Byte}\nsbyte\t{SByte}\nshort\t{Short}\nushort\t{UShort}\nint\t{Int}\nuint\t{UInt}" +
            //    $"\nlong\t{Long}\nulong\t{ULong}\nchar\t{Char}\nbool\t{Bool}\nfloat\t{Float}\ndouble\t{Double}\ndecimal\t{Decimal}");

            //1b
            byte k = 6;
            short s = k;
            ushort us = k;
            int i = k;
            uint ui = k;
            long l = k;
            Console.WriteLine($"\nНеявное преобразование:\nshort\t{s}\nushort\t{us}\nint\t{i}\nuint\t{ui}\nlong\t{l}");

            byte t = 6;
            short sh = (short)t;
            ushort ush = (ushort)t;
            int g = (int)t;
            uint uin = (uint)t;
            long lo = (long)t;
            Console.WriteLine($"\nЯвное преобразование:\nshort\t{sh}\nushort\t{ush}\nint\t{g}\nuint\t{uin}\nlong\t{lo}");

            //1с
            int v1 = 5;
            object obj = v1;
            int v2 = (int)obj;

            //1d
            var f = 12.44f;
            Console.WriteLine($"\nНеявно типизированная переменная: {f}");

            //1e
            int x1 = 4;
            int? x2 = x1;
            Console.WriteLine(x2);

            //1f
            var p = 9;
            p = 'r';
            Console.WriteLine(p);

            //2a
            string str1 = "Hello", str2 = "hello";
            if (String.Compare(str1, str2) == 0)
            {
                Console.WriteLine($"Строки одинаковы");
            }
            else
            {
                Console.WriteLine($"Строки различны");
            }

            //2b
            string s1 = "Hello", s2 = " world", s3 = " !!!";
            string s4 = string.Concat(s1, s2, s3);
            Console.WriteLine(s4);
            Console.WriteLine(string.Copy(s4));
            Console.WriteLine(s4.Substring(1, 5));
            string[] words = s4.Split(new char[] { ' ' });
            foreach (string s0 in words)
            {
                Console.WriteLine(s0);
            }
            Console.WriteLine(s4.Insert(5, s3));
            Console.WriteLine(s4.Remove(5, 3));

            //2c
            string emp = "", emp1 = null;
            Console.WriteLine(string.IsNullOrEmpty(emp));
            Console.WriteLine(string.IsNullOrEmpty(emp1));
            Console.WriteLine(emp == emp1);

            //2d
            StringBuilder sb = new StringBuilder("Hello world!!!");
            Console.WriteLine(sb.Remove(2, 3));
            sb = sb.Insert(0, "---");
            Console.WriteLine(sb.Insert(14, "---"));

            //3a
            int[,] mas = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int rows = mas.GetUpperBound(0) + 1; // индекс последнего элемента
            int columns = mas.Length / rows;
            for (int ii = 0; ii < rows; ii++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{mas[ii, j]} ");
                }
                Console.WriteLine();
            }

            //3b
            string[] names = { "Kate", "Vera", "Lera", "Liza", "Ira", "Kriss" };
            for (int mi = 0; mi < names.Length; ++mi)
            {
                Console.Write(names[mi] + " ");
            }
            Console.WriteLine(names.Length);
            string temp = names[0];
            names[0] = names[2];
            names[2] = temp;
            for (int oi = 0; oi < names.Length; ++oi)
            {
                Console.Write(names[oi] + " ");
            }

            //3c
            int[][] arr = new int[3][];
            arr[0] = new int[2];
            arr[1] = new int[3];
            arr[2] = new int[4];

            Console.WriteLine();
            for (int li = 0; li < 2; ++li)
            {
                arr[0][li] = li + 3;
                Console.Write(arr[0][li] + "  ");
            }
            Console.WriteLine();
            for (int li = 0; li < 3; ++li)
            {
                arr[1][li] = li + 8;
                Console.Write(arr[1][li] + "  ");
            }
            Console.WriteLine();
            for (int li = 0; li < 4; ++li)
            {
                arr[2][li] = li + 2;
                Console.Write(arr[2][li] + "  ");
            }

            //3d
            var n = new[] { 1, 2, 3, 4, 5 };
            var V = "Abcdefg";

            //4
            (int, string, char, string, ulong) kor = (18, "Катя", 'ж', "Сятковская", 575);
            Console.WriteLine();
            Console.Write(kor.Item1 + " " + kor.Item2 + " " + kor.Item4);
            (var a, var b) = ("123", 456);
            Console.WriteLine($"\n{a} {b}" + "\n_____________________________________\n");
            var First = (a: 10, b: "20");
            var Second = (a: 10, b: "20");
            Console.WriteLine(First == Second);

            //5
            (int, int, int, char) localfunc(int[] mass, string st)
            {
                int max = mass.Max();
                int min = mass.Min();
                int sum = mass.Sum();
                char sim = st.First();
                return (max, min, sum, sim);
            }
            int[] mass1 = { 1, 2, 3, 4, 5 };
            string st1 = "HAPPY DAY!!!";
            Console.WriteLine(localfunc(mass1, st1));

            //6
            int Fun1()
            {
                checked
                {
                    int x = int.MaxValue;
                    try
                    {
                        return x + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("переполнение");
                        return x;
                    }
                }
            }
            int Fun2()
            {
                unchecked
                {
                    int x = int.MaxValue;
                    try
                    {
                        return x + 1;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("переполнение");
                        return x;
                    }
                }
            }
            Console.WriteLine(Fun1());
            Console.WriteLine(Fun2());

            Console.ReadKey();
        }
    }
}
