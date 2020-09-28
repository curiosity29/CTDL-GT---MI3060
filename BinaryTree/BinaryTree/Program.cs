using System;
using System.Collections;
using System.Collections.Generic;
namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
        Program()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //input
            Console.WriteLine("Nhập biểu thức: ");
            var expression = "a+b*(c^d-e)^(f+g*h)-i";
            //
            var varList = new List<string>() { "a", "b", "c", "d", "e","f","g", "h", "i" };
            var tokenizor = new Tokenizor();
            tokenizor.AddToken(varList);
            var infix = new List<string>(tokenizor.Tokenize(expression));
            var postfix = BinaryTreeNode.infixToPostfix(infix);
            foreach (string s in infix)
            {
                Console.Write(s);
            }
            Console.WriteLine();
            foreach (string s in postfix)
            {
                Console.Write(s);
            }
            //Console.WriteLine("" + BinaryTreeNode.EvaluateExpressionTree(infix));
        }
    }

    public class Tokenizor
    {
        public List<string> tokens = new List<string>()
        {
            "+", "-", "*", "/", "%", "|", "&", "!", "^", "->", "<->", "(", ")"
        };                          //token
        public void AddToken(List<string> newtokens)
        {
            //this.tokens = this.tokens.AddRange(newtokens);
            foreach(string s in newtokens)
            {
                tokens.Add(s);
            }
        }
        //tokenization:
        public List<string> Tokenize(string input)
        {
            string token = "";
            var list = new List<string>();
            foreach (char c in input)
            {
                if (c != ' ')
                {
                    token += c;
                    if (tokens.Contains(token))
                    {
                        list.Add(token);
                        token = "";
                    }
                }
            }
            if (token.Trim() != "") throw new Exception("unexpected token!");
            return list;
        }
    }
    public class BinaryTreeNode
    {
        public BinaryTreeNode leftChild;
        public BinaryTreeNode rightChild;
        public string value;
        public BinaryTreeNode(string value)
        {
            this.value = value;
        }
        //  identifier:
        static List<string> operatorList = new List<string>()
        {
            "+", "-", "*", "/", "%", "|", "&", "!", "^", "->", "<->"
        };                           //operator
        internal static int GetPriority(string s)
        {
            switch (s)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }
        public bool IsLeaf
        {
            get { return this.leftChild == null && this.rightChild == null; }
        }
        private static bool IsOperator(string s)
        {
            foreach (string op in operatorList) if (s == op) return true;
            return false;
        }
        private static bool IsOperand(string s)
        {
            throw new NotImplementedException("khong lam ma doi co an");
        }
        // convert infix notation (input) to postfix notation
        public static List<string> infixToPostfix(List<string> expression)
        {
            var result = new List<string>();
            var stack = new Stack<string>();
            foreach (string s in expression)
            {
                if (IsOperator(s))
                {
                    //push all operator got more priority than s to stack then push s
                    while (stack.Count > 0 && GetPriority(s) <= GetPriority(stack.Peek())) result.Add(stack.Pop());    // a*a+b --> meet + push(*)
                    stack.Push(s);
                }
                else if (s == "(") stack.Push(s);
                //  If s is ")", pop and output from the stack   
                // until an "(" is encountered.  
                else if (s == ")")
                {
                    while (stack.Peek() != "(") result.Add(stack.Pop());
                    stack.Pop();
                }
                //  push opperand
                else result.Add(s);
            }
            //push remain
            while (stack.Count > 0) result.Add(stack.Pop());
            return result;
        }

    }
    public class Evaluator
    {
        public static double EvaluateExpressionTree(BinaryTreeNode node, Dictionary<string, double> variables)
        {
            double t = 0;
            if (node.IsLeaf)
                t = variables[node.value];  // get variable value with its string representation
            else
            {
                double x = EvaluateExpressionTree(node.leftChild, variables);
                double y = EvaluateExpressionTree(node.rightChild, variables);
                t = evalBinaryOperator(x, y, node.value);
            }
            return t;
        }
        public static double evalBinaryOperator(double x, double y, string op)
        {
            switch (op)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "*": return x * y;
                case "/": return x / y;
                case "^": return Math.Pow(x, y);
                default: throw new Exception("unrecognized operator");
            }
        }
        public static bool evalBinaryOperator(bool x, bool y, string op)
        {
            switch (op)
            {
                case "|": return x || y;
                case "&": return x && y;
                case "^": return x ^ y;
                case "->": return !x || y;
                case "<->": return x = y;
                default: throw new Exception("unrecognized operator");
            }
        }
        public static bool evalUnaryOperator(bool x, string op)
        {
            return !x;
        }
    }
}
