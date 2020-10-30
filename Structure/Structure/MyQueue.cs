using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{

    /// <summary>
    /// queue
    /// </summary>
    public class MyQueue
    {
        Node head;
        Node tail;
        public bool Isempty()
        {
            return (head == null);
        }
        public void Enqueue(object obj)
        {

            if (head == null)
            {
                Node node = new Node(obj, null, null);
                head = node;
                tail = node;
            }
            else
            {
                Node node = new Node(obj, tail, null);
                tail.next = node;
                tail = node;
            }
        }
        public void Dequeue()
        {
            if (tail == null) throw new InvalidOperationException("Error: cant dequeue empty queue");
            else tail = tail.prev;
            if (tail == null) head = null;
        }

        internal void Traverse()
        {
            Console.WriteLine("Traverse:");
            var current = tail;
            while (current != null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.prev;
            }
        }
    }
}
