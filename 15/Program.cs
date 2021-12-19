using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace _15
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            First();
            Console.WriteLine();
            Second();
            Console.WriteLine();
            Third();
            Console.WriteLine();
            Fourth();
            Console.WriteLine();
            Fifth();
        }
        private static void First()
        {
            var allProcess = Process.GetProcesses();
            foreach (var process in allProcess)
                try
                {
                    Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName} Priority: {process.BasePriority} ");
                    Console.WriteLine( $"Start time : {process.StartTime}  Total processor time: {process.TotalProcessorTime}\n");
                }
                catch
                {
                    Console.WriteLine();
                }
        }
        private static void Second()
        {
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName} Config datails: {domain.SetupInformation} Base Directory: {domain.BaseDirectory}");
            Console.WriteLine("Assemblies: ");
            foreach (var ass in domain.GetAssemblies()) Console.WriteLine(ass.FullName);

            var newDomain = AppDomain.CreateDomain("Domain");
            newDomain.Load(Assembly.GetExecutingAssembly().GetName());
            AppDomain.Unload(newDomain);
        }
        private static void Third()
        {
            var first = new Thread(ShowSimpleNumbers);
            first.Start();
            first.Name = "SimpleNumbersThread";
            first.Join();
            Console.WriteLine();
        }
        private static void ShowThreadInfo(object thread)
        {
            var currentThread = thread as Thread;
            Console.WriteLine($"Name: {currentThread.Name} Id: {currentThread.ManagedThreadId} Priority: {currentThread.Priority} Status: {currentThread.ThreadState}");
        }
        private static void ShowSimpleNumbers()
        {
            var first = new Thread(ShowThreadInfo);
            first.Start(Thread.CurrentThread);
            first.Join();

            Console.WriteLine("n= ");
            int n = int.Parse(Console.ReadLine());
            for (var i = 1; i <= n; i++)
            {
                var isSimple = true;
                for (var j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                    {
                        isSimple = false;
                        break;
                    }

                if (isSimple)
                {
                    Console.Write($"{i} ");
                    Thread.Sleep(100);
                }
            }
        }
        private static void Fourth()
        {
            var even = new Thread(ShowEvenNumbers) { Priority = ThreadPriority.Highest };
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            Console.WriteLine();
            FirstlyEvenSecondlyOdd();
            Console.WriteLine();
            ShowOneByOne();
        }
        private static void ShowOneByOne()
        {
            var mutex = new Mutex();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            odd.Start();
            even.Start();
            even.Join();
            odd.Join();
            void ShowEvenNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    if (i % 2 == 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                    mutex.ReleaseMutex();
                }
            }
        }
        private static void FirstlyEvenSecondlyOdd()
        {
            var objectToLock = new object();
            var even = new Thread(ShowEvenNumbers);
            var odd = new Thread(ShowOddNumbers);
            even.Start();
            odd.Start();
            even.Join();
            odd.Join();

            void ShowEvenNumbers()
            {
                lock (objectToLock)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        if (i % 2 == 0)
                            Console.Write(i + " ");
                    }
                }
            }

            void ShowOddNumbers()
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);
                    if (i % 2 != 0)
                        Console.Write(i + " ");
                }
            }
        }
        private static void ShowEvenNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
        }
        private static void ShowOddNumbers()
        {
            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                if (i % 2 != 0)
                    Console.Write(i + " ");
            }
        }
             
        private static void Fifth()
        {
            Console.WriteLine();

            TimerCallback timerCallback = new TimerCallback(CurrentTime);
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Thread.Sleep(5000);
            void CurrentTime(object obj)
            {
                Console.WriteLine(DateTime.Now);
            }
        }
    }
}