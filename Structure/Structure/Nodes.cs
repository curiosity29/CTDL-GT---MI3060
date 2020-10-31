using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{
    public class Node
    {
        public object data;
        public Node prev;
        public Node next;
        public Node() { }
        public Node(object data, Node prev, Node next)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }
    }
    public class Node<T>
    {
        public T data;
        public Node<T> prev;
        public Node<T> next;
        public Node() { }
        public Node(T data, Node<T> prev, Node<T> next)
        {
            this.data = data;
            this.prev = prev;
            this.next = next;
        }
    }
    public class Node_1
    {
        public object data;
        public Node_1 next;
        public Node_1() { }
        public Node_1(object data, Node_1 next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
