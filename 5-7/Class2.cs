using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{   //6
    struct Dolg
    {
        public int dolg;
        public int penya;
        public void PrintInfo()
        {
            Console.WriteLine($"Задолженность {dolg} пеня за задержку {penya} = итого {dolg+penya}");
        }
    }
    enum Operation
    { 
        kredit,
        ipoteka,
        lising,
        vklad
    }
    partial class Chek : Document, IOrganization
    {
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Сумма: {Sum}");
        }
        public override string ToString()
        {
            Console.WriteLine($"\tЧек");
            return "\0";
        }
    }
    //контейнер
    class Bygalteria: System.Collections.IEnumerable
    {
        private readonly List<Document> ListDOC;
        public List<Document> GetList     
        {
            get;
            set;
        }
        public Bygalteria()                        
        {
            ListDOC = new List<Document> ();
        }
        public void Add(Document obj)     
        {
            ListDOC.Add(obj);
        }
        public bool Remove(int index)
        {
            if (ListDOC.Count < index)
            {
                return false;
            }
            Console.WriteLine($"\n  Элемент [{index}] удален");
            ListDOC.RemoveAt(index);
            return true;
        }
        public void Show()
        {
            Console.WriteLine("\n----Элементы списка----");
            foreach (var i in ListDOC)
            {
                Console.Write(i);
            }
            Console.WriteLine("----------------------");
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            return ListDOC.GetEnumerator();
        }

    }
    //контроллер 
    class СontrollerByx 
    {
        public static int Kvitantsum(Bygalteria ListDOC)
        {
            int sum = 0;
            foreach (var i in ListDOC)
            {
                if (i is Kvitant)
                {
                   Kvitant kvit = (Kvitant)i;
                    sum += kvit.Sum;
                }
            }
            return sum;
        }
        public static int NumberOfCheks(Bygalteria ListDOC)
        {
            int sum = 0;
            foreach (var i in ListDOC)
            {
                if (i is Chek)
                {
                    sum++;
                }
            }
            return sum;
        }
        public static void PrintDocsPeriod(Bygalteria ListDOC, int begin, int end)
        {
            foreach (var i in ListDOC)
            {
                Document document = (Document)i;
                if (document.Date >= begin && document.Date <= end)
                {
                    document.ShowInfo();
                }
            }
        }
    }
}
