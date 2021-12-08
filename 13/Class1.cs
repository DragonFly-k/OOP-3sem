using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace _13
{
    class SEDlog
    {     
        public static void WriteLog(string message)
        {
            string path = @"D:\лабы\ооп\oop-3sem\13\log.txt";
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        public static void Search(string name)
        {
            StringBuilder newFile = new StringBuilder();
            string path = @"D:\лабы\ооп\oop-3sem\13\log.txt", str;
            int lineNumber = 0;
            using (StreamReader sw = new StreamReader(path))
            {
                while (!sw.EndOfStream)
                {
                    str = sw.ReadLine();
                    if (str.Contains(name))
                    {
                        Console.WriteLine(str);
                    }
                    else
                    {
                        newFile.Append(str + "\n");
                    }
                    lineNumber++;
                }
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("Number of lines: {0}", lineNumber);
                sw.WriteLine(newFile);
            }
        }
    }
    static class SEDDiskInfo
    {
        public static event Action<string> action;
        public static void GetFreeSpace(string name)
        {
            var disk = DriveInfo.GetDrives().Single(e => e.Name == name);
            Console.WriteLine($"Cвободное место: {disk.AvailableFreeSpace} bytes\nфайловая система: {disk.DriveFormat}\n");
            action($"GetFreeSpace works");
        }
        public static void GetEveryDisk()
        {
            foreach (var item in DriveInfo.GetDrives())
            {
                Console.WriteLine($"имя диска :{item.Name}\nобъем: {item.TotalSize} bytes\nдоступный объем: {item.AvailableFreeSpace} bytes\n");
            }
            action($"GetEveryDisk works");
        }
    }
    static class SEDFileInfo
    {
        public static event Action<string> action;
        public static void GetFileInfo(string path)
        {
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                action($"GetFileInfo works");
                Console.WriteLine($"Полный путь: {file.FullName}\nразмер: {file.Length}\nрасширение: {file.Extension}\nимя: {file.Name}\nдата создания: {file.CreationTime}\nдата изменения: { file.LastWriteTime}");
            }
            else
            {
                Console.WriteLine("file doesnt exist");
            }
        }
    }
    static class SEDDirInfo
    {
        public static event Action<string> action;
        public static void GetDirInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            action($"GetDirInfo works");
            Console.WriteLine($"Количестве файлов:{dir.GetFiles().Length}\nВремя создания: {dir.CreationTime}\nКоличестве поддиректориев: " +
                $"{dir.GetDirectories().Length}\nСписок родительских директориев: {dir.Parent}");
        }
    }
    static class SEDFileManager
    {
        public static event Action<string> action;
        public static void A(string diskName, string info)
        {
            DirectoryInfo disk = new DirectoryInfo(diskName);
            foreach (var item in disk.GetFiles())
            {
                Console.WriteLine(item.Name);
            }
            foreach (var item in disk.GetDirectories())
            {
                Console.WriteLine(item.Name);
            }
            string path = @"D:\лабы\ооп\oop-3sem\13\seddirinfo.txt";
            Directory.CreateDirectory(@"D:\лабы\ооп\oop-3sem\13\sedInspect");
            File.Create(path).Dispose();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(info);
            }
            string newPath = @"D:\лабы\ооп\oop-3sem\13\newseddirinfo.txt";
            File.Copy(path, newPath, true);
            File.Delete(path);
            action($"A works");
        }
        public static void B(string sourse)
        {
            string path = @"D:\лабы\ооп\oop-3sem\13\sedFiles\";
            Directory.CreateDirectory(path);
            string extension = ".txt";
            DirectoryInfo dir = new DirectoryInfo(sourse);
            foreach (var item in dir.GetFiles())
            {
                if (item.Extension == extension)
                {
                    item.CopyTo(path + item.Name, true);
                }
            }
            string newPath = @"D:\лабы\ооп\oop-3sem\13\sedinspect\";
            Directory.Delete(newPath, true);
            Directory.Move(path, newPath);
            action($"B works");
        }
       public static void C(string soursePath, string distPath)
        {
            if (!File.Exists($@"{soursePath}.zip"))
            {
                ZipFile.CreateFromDirectory(soursePath, $@"{soursePath}.zip");
            }
            ZipFile.ExtractToDirectory($@"{soursePath}.zip", distPath);
            action($"C works");
        }
    }
}