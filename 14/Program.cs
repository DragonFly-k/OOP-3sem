using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _14
{
    class Program
    {
        static void Main(string[] args)
        {
            Kvitant Kvit1 = new Kvitant(06102021, 0.2, 300);
            Kvitant Kvit2 = new Kvitant(11102021, 0.4, 500);
            Kvitant Kvit3 = new Kvitant(30102021, 0.8, 700);
            Kvitant Kvit4 = new Kvitant(09802021, 1.6, 900);

            CustomSerializer.Serialize("bin.bin", Kvit1);
            CustomSerializer.Serialize("bin.soap", Kvit2);
            CustomSerializer.Serialize("bin.xml", Kvit3);
            CustomSerializer.Serialize("bin.json", Kvit4);

            CustomSerializer.Deserialize("bin.bin");
            CustomSerializer.Deserialize("bin.soap");
            CustomSerializer.Deserialize("bin.xml");
            CustomSerializer.Deserialize("bin.json");

            Console.WriteLine();
            List<Kvitant> list = new List<Kvitant>() { Kvit1, Kvit2, Kvit3, Kvit4 };
            using (FileStream fs = new FileStream("List.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Kvitant>));
                xs.Serialize(fs, list);
                fs.Close();
                using (FileStream fsd = new FileStream("List.xml", FileMode.Open))
                {
                    List<Kvitant> Kvit = (List<Kvitant>)xs.Deserialize(fsd);
                    Kvit.ForEach(x => Console.WriteLine($"Deserialized: {x.Fine} {x.Sum}"));
                }
            }

            Console.WriteLine();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("D:/лабы/ооп/oop-3sem/14/bin/Debug/List.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes = xRoot.SelectNodes("*");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.OuterXml);

            Console.WriteLine();
            XmlNodeList childnod = xRoot.SelectNodes("//Kvitant/date");
            foreach (XmlNode n in childnod)
                Console.WriteLine(n.InnerText);

            Console.WriteLine();
            XDocument xdoc = new XDocument(new XElement("Games",
          new XElement("Game", new XAttribute("name", "Super cow"),
          new XElement("company", "Microsoft"),
          new XElement("price", "40000")),

          new XElement("Game", new XAttribute("name", "Angry birds"),
          new XElement("company", "X-box"),
          new XElement("price", "33000"))));
            xdoc.Save("Games.xml");

            Console.ReadKey();
        }
    }
}