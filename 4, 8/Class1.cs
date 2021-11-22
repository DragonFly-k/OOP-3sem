//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _4
//{ //4
//    class List
//    {
//        public class Owner
//        {
//            int id;
//            string owner;
//            string organization;
//            public Owner(int id, string organization, string owner)
//            {
//                this.id = id;
//                this.organization = organization;
//                this.owner = owner;
//            }
//            public void PrintInfo()
//            {
//                Console.WriteLine($"id: {0}, организация: {1}, создатель: {2}", id, organization, owner);
//            }
//        }
//        public class Date
//        {
//            public void PrintDate()
//            {
//                Console.WriteLine("Дата создания: " + DateTime.Now);
//            }
//        }
//        Node tail;
//        Node head;
//        int length;
//        public List()
//        {
//            tail = null;
//            head = null;
//            length = 0;
//        }
//        public Node Head
//        {
//            get => head;
//        }
//        public void AddNode(string info)
//        {
//            Node node = new Node();
//            node.Info = info;
//            if (head == null)
//            {
//                head = node;
//            }
//            else
//            {
//                tail.Next = node;
//            }
//            tail = node;
//            length++;
//        }
//        public void ShowInfo()
//        {
//            Node node = head;
//            while (node != null)
//            {
//                Console.WriteLine(node.Info);
//                node = node.Next;
//            }
//        }
//        public static List operator +(Node node, List list)
//        {
//            node.Next = list.head;
//            list.head = node;
//            if (list.length == 0)
//            {
//                list.tail = list.head;
//            }
//            list.length++;
//            return list;
//        }
//        public static List operator --(List list)
//        {
//            list.head = list.head.Next;
//            list.length--;
//            return list;
//        }
//        public static bool operator !=(List list1, List list2)
//        {
//            if (list1.length != list2.length)
//            {
//                return true;
//            }
//            Node curr1 = list1.head;
//            Node curr2 = list2.head;
//            while (curr1 != null)
//            {
//                if (curr1.Info != curr2.Info)
//                {
//                    return true;
//                }
//                else
//                {
//                    curr1 = curr1.Next;
//                    curr2 = curr2.Next;
//                }
//            }
//            return false;
//        }
//        public static bool operator ==(List list1, List list2)
//        {
//            if (list1.length != list2.length)
//            {
//                return false;
//            }
//            Node curr1 = list1.head;
//            Node curr2 = list2.head;
//            while (curr1 != null)
//            {
//                if (curr1.Info != curr2.Info)
//                {
//                    return false;
//                }
//                else
//                {
//                    curr1 = curr1.Next;
//                    curr2 = curr2.Next;
//                }
//            }
//            return true;
//        }
//        public static List operator *(List list1, List list2)
//        {
//            Node curr2 = list2.head;
//            while (curr2 != null)
//            {
//                list1.tail.Next = curr2;
//                list1.tail = curr2;
//                curr2 = curr2.Next;
//                list1.length++;
//            }
//            return list1;
//        }
//    }
//}