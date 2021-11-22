using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{    //8
    public interface IGeneric<T>
    {
        void Add(T info);
        void Delete(T info);
        void Show();
    }
    class DATA
    {
        public int Date
        {
            get;
            set;
        }
        public DATA(int date)
        {
            Date = date;
        }
    }
    interface IOrganization
    {
        bool SignADoc();
        void ShowInfo();

    }
    abstract class Document
    {
        DATA date;
        bool signed = false;
        public bool Signed
        {
            get => signed;
            set => signed = value;
        }
        public int Date
        {
            get => date.Date;
        }
        public Document(int date)
        {
            this.date = new DATA(date);
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nДата: {date.Date}\nПодпись: {signed}");
        }
        public override string ToString()
        {
            return $"Дата документа: {date.Date}\nПодпись: {signed}\n";
        }
    }
    class Kvitant : Document, IOrganization
    {
        public double Fine
        {
            get;
            set;
        }
        public int Sum
        {
            get;
            set;
        }
        public Kvitant(int date, double fine, int sum) : base(date)
        {
            Fine = fine;
            Sum = sum;
        }
        public bool SignADoc()
        {
            return Signed = true;
        }
        public override string ToString()
        {
            return base.ToString() + $"Налог: {Fine}\n";
        }
    }
    class Streams<T> where T : class
    {
        public static void InFile(string path, ref List<T> list)
        {
            Node<T> node = list.Head;
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                while (node != null)
                {
                    sw.WriteLine(node.Info);
                    node = node.Next;
                }
            }
        }
        public static void OutFile(string path, ref List<string> list)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string[] items = sr.ReadToEnd().Split('\n');
                foreach (var item in items)
                {
                    list.Add(item);
                }
            }
        }
    }
}
