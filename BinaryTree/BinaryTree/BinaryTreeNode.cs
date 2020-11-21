using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTreeNode<T>
    {

        public BinaryTreeNode<T> leftChild;
        public BinaryTreeNode<T> rightChild;
        public T value;
        public bool IsLeaf
        {
            get { return this.leftChild == null && this.rightChild == null; }
        }
        public BinaryTreeNode(T value)
        {
            this.value = value;
        }
        public BinaryTreeNode()
        {

        }

        public void Spawn(BinaryTreeNode<T> leftChild, BinaryTreeNode<T> rightChild)
        {
            this.leftChild = leftChild;
            this.rightChild = rightChild;
        }

    }
}
