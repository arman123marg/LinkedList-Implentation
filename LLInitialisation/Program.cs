using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLInitialisation
{
    class Node
    {
        public int value;
        public Node next;
        public Node prev;
        public Node(int val)
        {
            value = val;
            next = null;
            prev = null;
        }
    }
    class MyLinkedList
    {
        private Node head;
        private Node tail;
        int size;
        public MyLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public bool IsEmpty()
        {
            return size == 0;
        }
        public void AddFirst(int val)
        {
            Node node = new Node(val);
            if (head == null)
            {
                head = tail = null;

            }
            else
            {
                head.prev = node;
                node.next = head;
                head = node;
            }
            size++;

        }
        public void AddLast(int val)
        {
            Node node = new Node(val);
            if (head == null)
            {
                head = tail = node;
            }
            else
            {
                tail.next = node;
                node.prev = tail;
                tail = node;
            }
            size++;
        }
        public void Add(int val)
        {
            AddLast(val);
        }
        public void Insert(int val, int pos)
        {
            if (pos > size || pos < 0)
            {
                throw new Exception("this position doesn't exsist");
            }
            if (pos == size)
            {
                AddLast(val);

            }
            else if (pos == 0)
            {
                AddFirst(val);
            }
            else
            {
                Node node = new Node(val);
                Node cur = head;
                int curpos = 0;
                while (curpos < pos)
                {
                    cur = cur.next;
                    curpos++;
                }
                node.next = cur;
                node.prev = cur.prev;
                cur.prev.next = node;
                cur.prev = node;
                size++;

            }

        }
        public void RemoveFirst()
        {
            if (head == tail)
            {
                head = tail = null;
                size = 0;
                return;
            }
            head = head.next;
            head.prev.next = null;
            head.prev = null;
            size--;
        }
        public void RemoveLast()
        {
            if (head == tail)
            {
                head = tail = null;
                size = 0;
                return;
            }
            tail = tail.prev;
            tail.next.prev = null;
            tail.next = null;
            size--;
        }
        public void Remove(int pos)
        {
            if (pos < 0 || pos > size)
            {
                throw new Exception("this position doesn't exsist");
            }
            else if (pos == size)
            {
                RemoveLast();
            }
            else if (pos == 0)
            {
                RemoveFirst();
            }
            else
            {
                Node cur = head;
                int curpos = 0;
                while (curpos < pos)
                {
                    cur = cur.next;
                    curpos++;
                }
                cur.prev.next = cur.next;
                cur.next.prev = cur.prev;
                cur = null;
            }
        }
        public void Print()
        {
            Node cur = head;

            while (cur != null)
            {
                Console.Write(cur.value + "\t");
                cur = cur.next;
            }
            Console.WriteLine();
        }
        public int this[int index]
        {
            get
            {
                if (index < 0 || index > size)
                {
                    throw new Exception("this  Index doesn't exist");
                }
                Node cur = head;
                int curindex = 0;
                while (curindex < index)
                {
                    cur = cur.next;
                    curindex++;
                }
                return cur.value;
            }
            set
            {
                if (index < 0 || index > size)
                {
                    throw new Exception("this  Index doesn't exist");
                }
                Node cur = head;
                int curindex = 0;
                while (curindex < index)
                {
                    cur = cur.next;
                    curindex++;
                }
                cur.value = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList myLinkedList = new MyLinkedList();
            myLinkedList.Add(4);
            myLinkedList.Print();
            myLinkedList.AddFirst(7);
            myLinkedList.Print();
            myLinkedList.AddLast(6);
            myLinkedList.Print();
            myLinkedList.Insert(10, 1);
            myLinkedList.Print();
            //myLinkedList.Remove(2);
            //myLinkedList.Print();
            //myLinkedList.RemoveFirst();
            //myLinkedList.Print();
            //myLinkedList.RemoveLast();
            //myLinkedList.Print();
            Console.WriteLine("-----------------------------");
            myLinkedList[2] = 40;
            myLinkedList.Print();
        }
    }
}
