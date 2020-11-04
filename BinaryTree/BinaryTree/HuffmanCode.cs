using System;
using System.Collections.Generic;
using System.Text;
using Structure;
namespace BinaryTree
{
    class HuffmanCode
    {
        /// <summary>
        /// take a list of char with weight is how frequent they appear in the file
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>

        public static Dictionary<char, string> Encode(Dictionary<char, float> dict)
        {
            var listNode = new List<Node<KeyValuePair<char, float>>>();
            foreach (KeyValuePair<char, float> pair in dict)
                listNode.Add(new Node<KeyValuePair<char, float>>(pair));

            var heap = new MyHeap<Node<KeyValuePair<char, float>>>
                (listNode, listNode.Count,
                (Node<KeyValuePair<char, float>> a, Node<KeyValuePair<char, float>> b)
                => a.data.Value.CompareTo(b.data.Value));

            Node<KeyValuePair<char, float>> parent, leftChild, rightChild;
            int count = heap.Size;
            //KeyValuePair<char, float> pair;
            while (count > 1)
            {
                leftChild = heap.Pop();
                rightChild = heap.Pop();

                parent = new Node<KeyValuePair<char, float>>(
                    new KeyValuePair<char, float>('?', leftChild.data.Value + rightChild.data.Value),
                    leftChild, rightChild);

                heap.Push(parent);
                count--;
            }
            var list = new Dictionary<char, string>();
            var root = heap.Pop();
            return Translate(root, list, "");
        }

        private static Dictionary<char, string> Translate(Node<KeyValuePair<char, float>> node, Dictionary<char, string> dict, string current)
        {
            var leftChild = node.prev;
            var rightChild = node.next;
            if (leftChild == null)
                if (rightChild == null)
                    // this mean leaf
                    dict.Add(node.data.Key, current);
                else throw new InvalidOperationException("this tree must be complete!");
            else
            {
                Translate(leftChild, dict, current + "0");
                Translate(rightChild, dict, current + "1");
            }

            return dict;
        }
    }
}
