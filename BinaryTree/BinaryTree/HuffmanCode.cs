using System;
using System.Collections.Generic;
using System.Text;
using Structure;
namespace BinaryTree
{
    class HuffmanCode
    {
        public static List<string> Encode(Dictionary<char,long> dict)
        {
            var heap = new MyHeap<KeyValuePair<char, long>>(dict, dict.Count+5);
            heap.Compare = (KeyValuePair<char, long> a, KeyValuePair<char, long> b) => a.Value.CompareTo(b.Value);


            //var listNode = new List<BinaryTreeNode<char>>();
            //var node = new BinaryTreeNode<char>();
            //foreach(char c in dict.Keys)
            //{
            //    node = new BinaryTreeNode<char>(c);
            //    listNode.Add(node);
            //}
            return default;
        }
    }
}
