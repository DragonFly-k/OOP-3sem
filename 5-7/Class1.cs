using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    //5
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
        bool signed= false;
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
            return "Документ";
        }
    }
    partial class Chek : Document, IOrganization
    {
        public int Sum
        {
            get;
            set;
        }
        public Chek(int date, int sum) : base(date)
        {
            Sum = sum;
        }
        public bool SignADoc()
        {
            return Signed = true; 
        }
    }
    sealed class Naklad : Document, IOrganization
    {
        public string Organization
        {
            get;
            set;
        }
        public Naklad(int date,  string organization) : base(date)
        {
            Organization = organization;
        }
        public bool SignADoc()
        {
            return Signed = true;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Организация: " + Organization);
        }
        public override string ToString()
        {
            Console.WriteLine($"\tНакладная");
            return "\0";
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
            return Signed=true;
        }
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("Налог: " + Fine);
            Console.WriteLine("Сумма: " + Sum);
        }
        public override string ToString()
        {
            Console.WriteLine($"\tКвитанция");
            return "\0";
        }
    }
    class Printer
    {
        public virtual void IAmPrinting(Document doc)
        {
            Console.WriteLine($"\t{ doc.GetType().Name}");
            doc.ToString();
        }
    } 
        
}
