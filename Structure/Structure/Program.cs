using System;
using System.Collections;
namespace Structure
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MyQueue q = new MyQueue();
            Queue q1 = new Queue();
            
        }
    }

        /// <summary>
        /// 
        /// </summary>

    public class MyQueue
    {
        Node head;
        Node tail;
        public MyQueue()
        {
            head = null;
            tail = null;
        }
        public bool Isempty()
        {
            return (head == null);
        }
        public void Enqueue(object obj)
        {
            Node p = new Node();
            p.data = obj;
            p.next = null;
            if (tail == null)
                if (head == null)
                    head = p;
                else p = head;
            else
            {
                tail = tail.next;
                tail.next.next = p;
            }
        }
        public void Dequeue(object data)
        {
            if (tail == null)
                if (head == null)
                    throw new InvalidOperationException("Error: cant dequeue empty queue");
                else head = null;

        }
    }
}
