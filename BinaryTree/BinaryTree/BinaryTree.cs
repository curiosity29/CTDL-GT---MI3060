using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        BinaryTreeNode<T> root;

        public void PostSearch()
        {

        }

        public BinaryTree(BinaryTreeNode<T> root)
        {
            this.root = root;
        }
        public void Traverse()
        {
            Traverse(root);
        }
        public void Traverse(BinaryTreeNode<T> node)
        {
            if (node.leftChild != null) Traverse(node.leftChild);
            Console.WriteLine(node.value.ToString());
            if (node.rightChild != null) Traverse(node.rightChild);
        }
    }

    public class Forest
    {

    }



    
}
