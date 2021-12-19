using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace _12
{
    static class Reflector
    {
        public static string GetAssemblyName()
        {
            return typeof(Program).Assembly.GetName().FullName;
        }
        public static bool HasPublicConstructors(string name)
        {
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetConstructors())
            {
                if (item.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }
        public static void PublicMethods(string name, StreamWriter sw)
        {
            Type type = Type.GetType(name, false, true);
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)
                {
                    sw.WriteLine(method.Name);
                }
            }
        }
        public static void FieldsAndProperties(string name, StreamWriter sw)
        {
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetFields())
            {
                sw.WriteLine(item.Name);
            }
            foreach (var item in type.GetProperties())
            {
                sw.WriteLine(item.Name);
            }
        }
        public static void Interfaces(string name, StreamWriter sw)
        {
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetInterfaces())
            {
                sw.WriteLine(item.Name);
            }
        }
        public static void MethodType(string name, string param, StreamWriter sw)
        {
            Type type = Type.GetType(name, false, true);
            foreach (var item in type.GetMethods())
            {
                if (item.GetParameters().Any(e => e.Name == param))
                {
                    sw.WriteLine(item);
                }
            }
        }
        public static void Invoke(string name, string methodName)
        {
            try
            {
                Type type = Type.GetType(name, false, true);
                object obj = Activator.CreateInstance(type);
                string[] param = File.ReadAllLines(@"Invoke.txt");
                MethodInfo method = type.GetMethod(methodName);
                method.Invoke(obj, param);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static object Create(string name)
        {
            return Activator.CreateInstance(Type.GetType(name));
        }
    }
} 