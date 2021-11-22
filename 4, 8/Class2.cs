//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _4
//{ //4
//    class Node
//    {
//        string inf;
//        Node next;
//        public string Info
//        {
//            get => inf;
//            set => inf = value;
//        }
//        public Node Next
//        {
//            get => next;
//            set => next = value;
//        }
//    }
//    static class StaticOperations
//    {
//        public static int Count(List list)
//        {
//            int count = 0;
//            Node curr = list.Head;
//            while (curr != null)
//            {
//                count++;
//                curr = curr.Next;
//            }
//            return count;
//        }
//        public static string ListString(List list)
//        {
//            string str = "";
//            Node curr = list.Head;
//            while (curr != null)
//            {
//                str = str + curr.Info + ", ";
//                curr = curr.Next;
//            }
//            return str;
//        }
//        public static string LongestInfo(List list)
//        {
//            Node curr = list.Head;
//            string str = curr.Info;
//            while (curr != null)
//            {
//                if (curr.Info.Length > str.Length)
//                {
//                    str = curr.Info;
//                }
//                curr = curr.Next;
//            }
//            return str;
//        }
//        public static string FormatText(this string str)
//        {
//            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
//        }
//    }

//    static class Extensions
//    {
//        public static int CountFirstCapitalLetters(this List list)
//        {
//            Node curr = list.Head;
//            int count = 0;
//            while (curr != null)
//            {
//                if (char.IsUpper(curr.Info[0]))
//                {
//                    count++;
//                }
//                curr = curr.Next;
//            }
//            return count;
//        }
//        public static bool CheckRepeatings(this List list)
//        {
//            Node curr = list.Head;
//            while (curr != null)
//            {
//                Node node = curr.Next;
//                while (node != null)
//                {
//                    if (node.Info == curr.Info)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        node = node.Next;
//                    }
//                }
//                curr = curr.Next;
//            }
//            return false;
//        }
//    }
//}
