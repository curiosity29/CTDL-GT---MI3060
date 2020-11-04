using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;
namespace Structure
{
    class Program
    {

        static void Main(string[] args)
        {
            new Program();
        }
        Program()
        {
            WriteLine("Freshy start");

            //TestStack();
            //WriteLine();

            //TestQueue();
            //WriteLine("test ended ...\n");

            //TestLinkedList();
            //WriteLine("test ended ...\n");

            //TestDoubleLinkedList();
            //WriteLine();

            TestHeap();
            //WriteLine();



        }
        private void TestHeap()
        {
            MyHeap<int> heap = new MyHeap<int>(100);
            heap.Push(3);
            heap.Push(1);
            heap.Push(2);
            heap.Traverse();
            heap.Push(6);
            heap.Push(9);
            heap.Push(0);
            heap.Push(-1);
            heap.Traverse();

            WriteLine("pop " + heap.Pop());
            WriteLine("pop " + heap.Pop());
            heap.Traverse();
            WriteLine("pop " + heap.Pop());
            WriteLine("pop " + heap.Pop());
            heap.Traverse();


        }
        private void TestStack()
        {
            MyStack stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Traverse();
            WriteLine(stack.Pop().data.ToString());
            stack.Traverse();
            stack.Pop();
            stack.Pop();
            stack.Traverse();
            try
            {
                stack.Pop();
            }
            catch(InvalidOperationException e)
            {
                WriteLine(e.Message);
            }
        }
        private void TestQueue()
        {
            MyQueue q = new MyQueue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Traverse();

            q.Dequeue();
            q.Traverse();
            q.Dequeue();
            q.Traverse();
            try
            {
                q.Dequeue();
                q.Dequeue();
            }
            catch(InvalidOperationException e)
            {
                WriteLine(e.Message);
            }
        }
        private void TestLinkedList()
        {
            MyLinkedList list = new MyLinkedList();

            list.Add("1", 0);
            list.Add("3", 1);
            list.Add("2", 1);

            list.Traverse();

            list.Delete(2);
            list.Traverse();
            list.Delete(0);
            list.Traverse();
            list.Add(4, 1);
            list.Traverse();

            MyLinkedList list2 = new MyLinkedList();
            list2.Add("hai", 0);
            list2.Add("mot", list2.head);
            list2.Add("ba", list2.head.next.next);
            list.Traverse();

            list = list + list2;
            list.Traverse();

            MyCircularlyLinkedList cirlist = new MyCircularlyLinkedList(list);
            WriteLine(cirlist.FindLeft(null).data);
            WriteLine();

            try
            {
                list.Add(0, null);
                list.Add(0, -3);
            }
            catch (InvalidOperationException)
            {
                WriteLine("you cant add after null");
            }

            try
            {
            list.Add(0, -3);
            }
            catch (IndexOutOfRangeException e)
            {
                WriteLine(e.Message);
            }
            WriteLine();
        }
        private void TestDoubleLinkedList()
        {
            MyDoublyLinkedList list1 = new MyDoublyLinkedList();

            list1.Add(4, 0);
            list1.Add(3, 0);
            list1.Add(1, 0);
            list1.Add(2, 1);
            list1.Add(5, 4);
            list1.Traverse();

            list1.Delete(3);
            list1.Traverse();
            list1.Delete(1);
            list1.Traverse();
            list1.Delete(0);
            list1.Traverse();
            WriteLine();

            var list2 = new MyDoublyLinkedList();
            list2.Add("mot", 0);
            list2.Add("hai", 1);
            list1.Add(2, 0);
            var list = list1 + list2;
            list.Traverse();
            WriteLine();
            try
            {
                list.Add("data", 50);
            }
            catch(IndexOutOfRangeException e)
            {
                WriteLine(e.Message);
            }
            try
            {
                (new MyDoublyLinkedList()).Delete(0);
            }
            catch (InvalidOperationException e)
            {
                WriteLine(e.Message);
            }
        }

    }


    
}
