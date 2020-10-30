using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class HuffmanCode
    {
        public static List<string> Encode(Dictionary<char,long> dict)
        {
            var listNode = new List<BinaryTreeNode<char>>();
            var node = new BinaryTreeNode<char>();
            foreach(char c in dict.Keys)
            {
                node = new BinaryTreeNode<char>(c);
                listNode.Add(node);
            }
            
        }
    }
}
