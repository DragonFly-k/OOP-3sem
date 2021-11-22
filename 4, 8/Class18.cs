using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{ //8
    class List<T> : IGeneric<T> where T : class
    {
        Node<T> tail;
        Node<T> head;
        public List()
        {
            tail = null;
            head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T info)
        {
            Node<T> node = new Node<T>();
            node.Info = info;
            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }
            tail = node;
        }
        public void Delete(T info)
        {
            Node<T> curr = head;
            Node<T> prev = null;
            while (curr != null)
            {
                if (curr.Info.Equals(info))
                {
                    if (prev != null)
                    {
                        prev.Next = curr.Next;
                        if (curr.Next == null)
                            tail = prev;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                }
                prev = curr;
                curr = curr.Next;
            }
        }
        public void Show()
        {
            Node<T> node = head;
            Console.Write($"\n");
            while (node != null)
            {
                
                Console.WriteLine(node.Info);
                node = node.Next;
            }
        }
    }
}