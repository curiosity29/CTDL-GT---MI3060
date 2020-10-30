using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{

    public class MyLinkedList
    {
        public Node_1 head = new Node_1(); //no info
        protected int count;
        public int Count { get => count; }

        /// <summary>
        /// find node at specified index statring from 0
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node_1 FindIndex(int index)
        {
            if (count <= index || index < 0) throw new IndexOutOfRangeException();
            var indexNode = head;
            for (int i = 0; i < index; i++)
            {
                indexNode = indexNode.next;
            }
            return indexNode.next;
        }
        /// <summary>
        /// add after a node in list
        /// </summary>
        /// <param name="data"></param>
        /// <param name="leftNode"></param>
        public void Add(object data, Node_1 leftNode)  //insert
        {
            if (leftNode == null)
                if (head.next == null)
                    head.next = new Node_1(data, null);
                else throw new InvalidOperationException("cant add after null when not empty");
            // ValidateNode();
            else leftNode.next = new Node_1(data, leftNode.next);
            count++;
        }
        /// <summary>
        /// add at index
        /// </summary>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public void Add(object data, int index)
        {
            if (index == 0) head.next = new Node_1(data, head.next);
            else
            {
                Node_1 indexNode = FindIndex(index - 1);
                indexNode.next = new Node_1(data, indexNode.next);
            }
            count++;
        }
        public void Delete(Node_1 node)
        {
            FindLeft(node).next = node.next;
            count--;
        }
        
        public void Delete(int index)
        {
            if (index == 0) head.next = head.next.next;
            else
            {
                Node_1 indexNode = FindIndex(index - 1);
                indexNode.next = indexNode.next.next;   //indexNode.next can't be null
            }
            count--;
        }
        //left of null is last
        public Node_1 FindLeft(Node_1 node)
        {
            if (head == null) throw new InvalidOperationException("List is empty");
            var before = head;
            while (before.next != node)
            {
                if (before.next == null) break;
                before = before.next;
            }
            if (before.next != node) throw new InvalidOperationException("Node not in list");
            return before;
        }
        //combine
        public static MyLinkedList operator + (MyLinkedList list1, MyLinkedList list2)
        {
            list1.FindLeft(null).next = list2.head.next;
            return list1;
        }
        public void Traverse()
        {
            Node_1 current = head.next;
            Console.WriteLine("traversal:");
            while(current != null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;
            }
        }
        private void ValidateNode(Node_1 node)
        {
            if (node == null) return;   //let null is an element after last
            FindLeft(node);
        }
    }
    public class MyCircularlyLinkedList : MyLinkedList
    {
        MyCircularlyLinkedList()
        {
            head.next = head;
        }
        /// <summary>
        /// take over input LinkedList
        /// </summary>
        /// <param name="list"></param>
        public MyCircularlyLinkedList(MyLinkedList list)
        {
            head = list.head;
        }
        public new Node_1 FindLeft(Node_1 node)
        {
            if (node == head)
            {
                return base.FindLeft(null);
            }
            else return base.FindLeft(node);
        }
        //combine
        public static MyCircularlyLinkedList operator + (MyCircularlyLinkedList list1, MyCircularlyLinkedList list2)
        {
            list1.FindLeft(list1.head).next = list2.head.next;
            return list1;
        }
    }

    public class MyDoublyLinkedList
    {
        public Node head = new Node();
        public Node tail;
        protected int count;
        public int Count { get; }
        
        // could make another find starting from tail when index > count/2
        public Node FindIndex(int index)
        {
            if (count <= index || index < 0) throw new IndexOutOfRangeException("index out of list's bound");
            var indexNode = head;
            for (int i = 0; i < index; i++)
            {
                indexNode = indexNode.next;
            }
            return indexNode.next;
        }
        public void Add(object data, Node left)
        {
            if (left == null)
                if (head.next == null)
                {
                    var node = new Node(data, head, null);
                    head.next = node;
                    tail = node;
                }
                else throw new InvalidOperationException("cant add after null");
            else
            {
                var right = left.next;
                var node = new Node(data, left, right);
                left.next = node;
                if (right != null) right.prev = node;
            }
            count++;
        }
        public void Add(object data, int index)
        {
            if(index == 0)
            {
                Node right = head.next;
                Node node = new Node(data, head, right);
                if (right == null) tail = node;
                else right.prev = node;
                head.next = node;
            }
            else if(index == count)
            {
                Node left = tail;
                tail = new Node(data, left, null);
                left.next = tail;
            }
            else
            {
                Node right;
                right = FindIndex(index);
                Node left = right.prev;
                Node node = new Node(data, left, right);
                left.next = node;
                right.prev = node;
            }
            count++;
        }
        public void Delete(Node node)
        {
            if (node == null) throw new InvalidOperationException("cant delete null");
            if (node.prev == null) throw new InvalidOperationException("naf nis?");
            node.prev.next = node.next;
            count--;
        }
        public void Delete(int index)
        {
            if (index == 0)
                if (tail != null) head.next = head.next.next;
                else throw new InvalidOperationException("list is empty");
            else
            {
                Node node = FindIndex(index);
                node.prev.next = node.next;
            }
            count--;
        }
        public static MyDoublyLinkedList operator + (MyDoublyLinkedList list1, MyDoublyLinkedList list2)
        {
            list1.tail.next = list2.head.next;
            return list1;
        }
        public void Traverse()
        {
            Node current = head.next;
            Console.WriteLine("traversal:");
            while (current != null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;
            }
        }

    }
    public class MyCircularlyDoublyLinkedList : MyDoublyLinkedList
    {
        MyCircularlyDoublyLinkedList()
        {
            head.prev = head;
            head.next = head;
        }
        public new void Add(object data, Node left)
        {
            if (left == null)
                throw new InvalidOperationException("cant add after null");
            else base.Add(data, left);
            count++;
        }
        public static MyCircularlyDoublyLinkedList operator + (MyCircularlyDoublyLinkedList list1, MyCircularlyDoublyLinkedList list2)
        {
            list2.tail.next = list1.head;
            list1.head.prev.next = list2.head.next;
            return list1;
        }
    }
}
