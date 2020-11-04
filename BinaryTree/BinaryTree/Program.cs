using System;
using System.Collections;
using System.Collections.Generic;
using Structure;
using static System.Console;
namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            new Program();
        }
        Program()
        {

            //SystaxTreeTest();

            TestHuffmanCode();
            
        }

        private void TestHuffmanCode()
        {
            var frequent = new Dictionary<char, float> 
            { { 'a', 0.1f }, { 'b', 0.2f }, { 'c', 0.5f }, { 'd', 0.03f }, {'e', 0.07f } };
            var dict = HuffmanCode.Encode(frequent);
            foreach (object obj in dict)
                WriteLine(obj.ToString());
        }

        public void SyntaxTreeTest()
        {
            Console.WriteLine("Nhập biểu thức: ");
            var expression = "a+b*(c^d-e)^(f+g*h)-i";
            //expression = Console.ReadLine();
            var varList = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };
            var tokenizor = new Tokenizor();
            tokenizor.AddToken(varList);
            var infix = new List<string>(tokenizor.Tokenize(expression));
            var postfix = BinaryTreeNode<string>.infixToPostfix(infix);
            ShowList(infix);
            Console.WriteLine();
            ShowList(postfix);
            //Console.WriteLine("" + BinaryTreeNode.EvaluateExpressionTree(infix));
        }
        public static void ShowList(List<string> list)
        {
            foreach(string s in list)
            {
                Console.Write(s);
            }
        }
    }
    
    
}
