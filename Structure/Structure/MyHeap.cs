using System;
using System.Collections.Generic;
using System.Text;

namespace Structure
{
    /// <summary>
    /// min heap
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyHeap <T>
    {
        private T[] tree;
        private int size;
        #region initialize
        public delegate int MyComparer(T node1, T node2);
        public MyComparer Compare;
        MyHeap(MyComparer compareFunction)
        {
            this.Compare = compareFunction;
        }
        public int Size { get => size; }
        public MyHeap(int maxSize)
        {
            tree = new T[maxSize + 1];
            // how to check if T is comparable?
            if (tree[0] is IComparable) Compare = (T a, T b) => ((IComparable)a).CompareTo(b);
            else throw new InvalidCastException("this type is not Comparable");
        }
        public MyHeap(ICollection<T> list, int maxSize)
        {
            tree = new T[maxSize + 1];
            foreach (T node in list)
                this.Push(node);
        }
        #endregion
        public T Peek()
        {
            return tree[0];
        }
        public void Push(T obj)
        {
            int index = size+1;
            tree[index] = obj;
            while(index > 1)
                if (Compare(tree[index],tree[index/2]) < 0)
                {
                    Swap(index, index / 2);
                    index /= 2;
                }
                else break;
            size++;
        }
        private void Swap(int index1, int index2)
        {
            T temp = tree[index1];
            tree[index1] = tree[index2];
            tree[index2] = temp;
        }
        public void Pop()
        {
            if (size == 0) throw new InvalidOperationException("empty");
            //swap
            tree[1] = tree[size];
            int index = 1;
            int smallChid = SmallChild(index);
            while(smallChid > 0)
            {
                if (Compare(tree[index],tree[smallChid]) > 0)
                    Swap(index, smallChid);
                else break;
                index = smallChid;
                smallChid = SmallChild(index);
            }
            size--;
        }

        public int SmallChild(int index)
        {
            index *= 2;
            if (size < index) return -1;
            if (size < index + 1) return index;
            if (Compare(tree[index],tree[index + 1]) < 0)
                return index;
            else return index+1;
        }

        public void Traverse()
        {
            Console.WriteLine("Traverse:");
            for(int i =1; i<= size;i++)
                Console.WriteLine(tree[i]);
        }
    }

    public class MyHeap1<T>
    {
        
    }


}
