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
            SyntaxTreeTest();

            SyntaxStringTest();
            //TestHuffmanCode();

            
        }





        

        private void TestHuffmanCode()
        {
            var frequent = new Dictionary<char, float>
            { { 'a', 0.1f }, { 'b', 0.2f }, { 'c', 0.5f }, { 'd', 0.03f }, {'e', 0.07f } };
            var dict = HuffmanCode.Encode(frequent);
            foreach (object obj in dict)
                WriteLine(obj.ToString());
        }

        public void SyntaxStringTest()
        {
            var varList = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };

            Console.WriteLine("Nhập biểu thức: ");

            var expression = "b*a+b*(c^d-e)^(f+g*h)-i";
            //expression = Console.ReadLine();

            var tokenizor = new Tokenizor();
            tokenizor.AddToken(varList);
            var infix = new List<string>(tokenizor.Tokenize(expression));
            var postfix = Interpreter.infixToPostfix(infix);

            ShowList(infix);
            Console.WriteLine();
            ShowList(postfix);

            //Console.WriteLine("" + BinaryTreeNode.EvaluateExpressionTree(infix));

            var dict = new Dictionary<string, double> 
            { { "a", 1 }, { "b", 2 }, { "c", 3 }, { "d", 4 }, { "e", 5 }, { "f", 1 }, { "g", 2 }, { "h", 1 }, {"i", 4 } };
            Console.WriteLine();
            Console.WriteLine(Evaluator.EvalPostfix(postfix, dict));
        }

        private void SyntaxTreeTest()
        {
            var varList = new List<string>() { "a", "b", "c", "d", "e", "f", "g", "h", "i" };

            Console.WriteLine("Nhập biểu thức: ");

            var expression = "b*a+b*(c^d-e)^(f+g*h)-i";
            //expression = Console.ReadLine();

            var tokenizor = new Tokenizor();
            tokenizor.AddToken(varList);
            var infix = new List<string>(tokenizor.Tokenize(expression));
            var rootNode = Interpreter.BuildTree(infix);

            ShowList(infix);
            Console.WriteLine();
            BinaryTree<string> tree = new BinaryTree<string>(rootNode);
            tree.Traverse();

            //Console.WriteLine("" + BinaryTreeNode.EvaluateExpressionTree(infix));

            var dict = new Dictionary<string, double>
            { { "a", 1 }, { "b", 2 }, { "c", 3 }, { "d", 4 }, { "e", 5 }, { "f", 1 }, { "g", 2 }, { "h", 1 }, {"i", 4 } };
            Console.WriteLine();
            Console.WriteLine(Evaluator.EvaluateExpressionTree(rootNode, dict));
        }
        public static void ShowList(List<string> list)
        {
            foreach (string s in list)
            {
                Console.Write(s);
            }
        }



        #region test
        private void TestProblem1(int[] arr)
        {
            var length = arr.Length;
            int j = length;
            for (int i = 0; i < length; i++)
            {
                if (arr[i] == 1)
                {
                    while (arr[j] == 0)
                        j++;
                    arr[i] = 0;
                    arr[j] = 1;
                }
            }
        }
        private static void FindMax(long length, int[] arr)
        {
            WriteLine("max :");
            long sum = 0;
            long imax = 0, jmax = 0;
            long max = 0;
            long i = 0;


            for (long j = 0; j < length; j++)
            {
                sum += arr[j];
                if (sum > max)
                {
                    imax = i;
                    jmax = j;
                    max = sum;
                }
                if (sum + arr[j] < 0)
                {
                    i = j + 1;
                    sum = 0;
                }
            }
            for (long k = imax; k <= jmax; k++)
            {
                Console.WriteLine(arr[k]);
            }
        }
        private void TestProblem2()
    {
        var arr = RandomArray();
        FindMax(arr.Length, arr);
    }

    private int[] RandomArray()
    {
        WriteLine("random array: ");
        int[] arr;
        long length = (long)Math.Pow(10, 1);
        arr = new int[length];
        var random = new Random();

        for (long k = 0; k < length; k++)
            arr[k] = (int)(random.Next() * Math.Pow(-1, random.Next()) / 10000000);

        for (int k = 0; k < length; k++)
        {
            Console.WriteLine(arr[k]);
        }
        return arr;
    }

    }




    
    #endregion
}
