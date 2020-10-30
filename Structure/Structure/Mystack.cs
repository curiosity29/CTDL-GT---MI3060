using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{
    //list stack
    public class MyStack
    {
        Node_1 last;
        protected int count;
        public int Count { get => count; }
        public bool Isempty()
        {
            return last == null;
        }
        public Node_1 Pop()
        {
            if (last == null) throw new InvalidOperationException("stack is empty");
            Node_1 temp = last;
            last = last.next;
            count--;
            return temp;
        }
        public void Push(object data)
        {
            if (last == null) last = new Node_1(data, null);
            else last = new Node_1(data, last);
            count++;
        }
        public void Traverse()
        {
            Console.WriteLine("Traverse:");
            var current = last;
            while (current != null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;
            }
        }
    }
}
