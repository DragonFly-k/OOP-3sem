using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {   
            //5
            Document docChek = new Chek(2343521, 10);
            Chek chek = docChek as Chek;
            if (chek != null)
            {
                chek.ShowInfo();
            }
            IOrganization orKvitant = new Kvitant(2575321, 0.5,5);
            if (orKvitant is Kvitant)
            {
                Kvitant kvitant1 = (Kvitant)orKvitant;
                kvitant1.SignADoc();
                kvitant1.ShowInfo();
            }
            Document docNaklad = new Naklad(214576821, "Gorge");
            if (docNaklad is Naklad naklad)
            {
                naklad.ShowInfo();
            }
            Kvitant kvitant = orKvitant as Kvitant;
            naklad = docNaklad as Naklad;
            Document[] docs = { chek, kvitant, naklad };
            Console.Write($"\n");
            Printer printer = new Printer();
            foreach (var item in docs)
            {
                printer.IAmPrinting(item);
                Console.Write($"\n");
            }

            //6
            Dolg Tom;
            Tom.dolg = 555;
            Tom.penya = 34;
            Tom.PrintInfo();

            Operation op = Operation.ipoteka;
            Console.WriteLine($"\nПример банковской операции {op}");

            Bygalteria byx = new Bygalteria();
            Document[] ListDOC = { new Kvitant(6856356, 0.2, 4), new Chek(68565635, 8585), new Naklad(10569545, "reno") };
            foreach (var i in ListDOC)
            {
                byx.Add(i);
            }
            byx.Show();
            byx.Remove(2);
            byx.Show();
            Chek chekk = new Chek(12122021, 10);
            Kvitant Kvit1 = new Kvitant(06102021, 0.2, 300);
            Kvitant Kvit2 = new Kvitant(11102021, 0.4, 500);
            Chek chek1 = new Chek(22102021, 22);
            Chek chek2 = new Chek(22102021, 300);
            Bygalteria docc = new Bygalteria() { chekk, chek2, Kvit1, Kvit2, chek1 };
            Console.WriteLine("Сумма квитанций: " + СontrollerByx.Kvitantsum(docc));
            Console.WriteLine("Количество чеков: " + СontrollerByx.NumberOfCheks(docc));
            СontrollerByx.PrintDocsPeriod(docc, 5102021, 8102021);

            //7
            try
            {
                Kvitant kvit0 = new Kvitant(06102021, 1.5, 300);
                if (kvit0.Fine >= 1)
                {
                    throw new Nalog();
                }
            }
            catch (Nalog e)
            {
                e.PrintInfo();
            }

            try
            {
                Chek che = new Chek(34122021, 10);
                if (che.Sum != 0)
                {
                    throw new SUM("ИТОГО - 0");
                }
            }
            catch (SUM e)
            {
                e.PrintInfo();
            }

            try
            {
                Dolg company = new Dolg();
                if (company.dolg != 0 || company.penya != 0)
                {
                    throw new Dolges();
                }
            }
            catch (Dolges e)
            {
                e.PrintInfo();
            }
            finally
            {
                Console.WriteLine("Долгов нет");
            }

            try
            {
                int x = 10;
                x = x / 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                int[] arr = new int[4];
                arr[15] = 5;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            int p = 10;
            int n = -10;
            Debug.Assert(n > 0, "n is negative");
            Debug.Assert(p > 0, "p is negative");

            Console.ReadKey();
        }
    }
}
