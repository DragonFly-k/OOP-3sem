using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13
{
    class Program
    {
        static void Main(string[] args)
        {
            SEDDiskInfo.action += SEDlog.WriteLog;
            SEDFileInfo.action += SEDlog.WriteLog;
            SEDDirInfo.action += SEDlog.WriteLog;
            SEDFileManager.action += SEDlog.WriteLog;
            SEDDiskInfo.GetFreeSpace(@"C:\");
            SEDDiskInfo.GetEveryDisk();
            SEDFileInfo.GetFileInfo(@"D:\лабы\ооп\oop-3sem\13\file.txt");
            Console.WriteLine();
            SEDDirInfo.GetDirInfo(@"D:\лабы\ооп\oop-3sem");
            Console.WriteLine();
            SEDFileManager.A(@"D:\", " info");
            Console.WriteLine();
            SEDFileManager.B(@"D:\лабы\ооп\oop-3sem\13");
            Console.WriteLine();
            SEDFileManager.C(@"D:\лабы\ооп\oop-3sem\13\SED", @"D:\лабы\ооп\oop-3sem\13\");
            Console.WriteLine();
            SEDlog.Search("A");
            Console.ReadKey();
        }
    }
}
