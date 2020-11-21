using System;
using System.Collections.Generic;
using System.Text;
using static BinaryTree.Interpreter;
namespace BinaryTree
{
    public class Evaluator
    {
        public static double EvaluateExpressionTree(BinaryTreeNode<string> node, Dictionary<string, double> variables)
        {
            double t = 0;
            if (node.IsLeaf)
                t = variables[node.value];  // get variable value with its string representation
            else
            {
                double x = EvaluateExpressionTree(node.leftChild, variables);
                double y = EvaluateExpressionTree(node.rightChild, variables);
                t = EvalBinaryOperator(x, y, node.value);
            }
            return t;
        }
        public static double EvalBinaryOperator(double x, double y, string op)
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
        public static bool EvalBinaryOperator(bool x, bool y, string op)
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
        public static bool EvalUnaryOperator(bool x, string op)
        {
            return !x;
        }

        public static double EvalPostfix(List<string> postfix, Dictionary<string,double> dict)
        {
            double result,d1,d2;
            Stack<object> stack = new Stack<object>() ;
            foreach(string s in postfix)
            {

                if (Interpreter.IsOperator(s))
                {
                    d1 = ReadValue(stack.Pop(), dict);
                    d2 = ReadValue(stack.Pop(), dict);
                    result = EvalBinaryOperator(d2, d1, s);
                    stack.Push(result) ;
                }
                else 
                    stack.Push(s);
            }
            return double.Parse(stack.Pop().ToString());
        }
    }
}
