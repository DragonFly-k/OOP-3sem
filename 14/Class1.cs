using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

namespace _14
{
    [Serializable]
    public class Kvitant
    {
        public double Fine {  get; set; }
        public int Sum { get; set; }
        [NonSerialized]
        public int date;

        public Kvitant() { }
        public Kvitant(int date, double fine, int sum)
        {
            this.date = date;
            Fine = fine;
            Sum = sum;
        }
        public override string ToString()
        {
            Console.WriteLine($"\tКвитанция- налог: {Fine}, сумма: {Sum}");
            return "\0";
        }
    }
    static class CustomSerializer
    {
        public static void Serialize(string file, Kvitant kvitant)
        {
            string format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        bf.Serialize(fs, kvitant);
                    }
                    break;

                case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        sf.Serialize(fs, kvitant);
                    }
                    break;

                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(Kvitant));
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        xs.Serialize(fs, kvitant);
                    }
                    break;

                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Kvitant));
                    using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                    {
                        js.WriteObject(fs, kvitant);
                    }
                    break;
            }
        }

        public static void Deserialize(string file)
        {
            string format = file.Split('.').Last();
            switch (format)
            {
                case "bin":
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Kvitant kvitant = (Kvitant)bf.Deserialize(fs);
                        Console.WriteLine($"Deserialized: {kvitant.Fine} {kvitant.Sum}");
                    }
                    break;

                case "soap":
                    SoapFormatter sf = new SoapFormatter();
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Kvitant kvitant = (Kvitant)sf.Deserialize(fs);
                        Console.WriteLine($"Deserialized: {kvitant.Fine} {kvitant.Sum}");
                    }
                    break;

                case "xml":
                    XmlSerializer xs = new XmlSerializer(typeof(Kvitant));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Kvitant kvitant = (Kvitant)xs.Deserialize(fs);
                        Console.WriteLine($"Deserialized: {kvitant.Fine} {kvitant.Sum}");
                    }
                    break;

                case "json":
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Kvitant));
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        Kvitant kvitant = (Kvitant)js.ReadObject(fs);
                        Console.WriteLine($"Deserialized: {kvitant.Fine} {kvitant.Sum}");
                    }
                    break;
            }
        }
    }
}