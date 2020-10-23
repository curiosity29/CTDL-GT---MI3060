using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{
    public class MyLinkedList
    {
        public Node_1 head;

        public void AddAfter(object data, Node_1 leftNode)
        {
            //ValidateNode(leftnode);
            if (leftNode == null)
                if (head.next == null)
                    head.next = new Node_1(data, null);
                else throw new InvalidOperationException("cant add after null");
            else leftNode.next = new Node_1(data, leftNode.next);
        }
        public void Delete(object data, Node_1 node)
        {
            FindLeft(node).next = node.next;
        }
        public Node_1 FindLeft(Node_1 node)
        {
            var before = head;
            while (before.next != node && before.next != head)
                before = before.next;
            if (before.next != node) throw new InvalidOperationException("Node not in list");
            return before;
        }
        private void ValidateNode(Node_1 node)
        {
            if (node == null) return;   //null is last element
            FindLeft(node);
        }

    }
    public class MyCircularlyLinkedList : MyLinkedList
    {
        MyCircularlyLinkedList()
        {
            head.next = head;
        }
        public new Node_1 FindLeft(Node_1 node)
        {
            if (node == head)
            {
                return base.FindLeft(null);
            }
            else return base.FindLeft(node);
        }
    }

    public class MyDoublyLinkedList
    {
        public Node head;

        public void AddAfter(object data, Node left)
        {
            if (left == null)
                if (head.next == null)
                    head.next = new Node(data, head, null);
                else throw new InvalidOperationException("cant add after null");
            else
            {
                var right = left.next;
                var node = new Node(data, left, right);
                left.next = node;
                right.prev = node;
            }
            
        }
        public void Delete(Node node)
        {
            if (node == null) throw new InvalidOperationException("cant delete null");
            if (node.prev == null)
                node.prev.next = node.next;
            if (node.next == null)
                node.next.prev = node.prev;
        }
    }
    public class MyCircularlyDoublyLinkedList : MyDoublyLinkedList
    {
        MyCircularlyDoublyLinkedList()
        {
            head.prev = head;
            head.next = head;
        }
        public new void AddAfter(object data, Node left)
        {
            if (left == null)
                throw new InvalidOperationException("cant add after null");
            else base.AddAfter(data, left);
        }
    }
}
