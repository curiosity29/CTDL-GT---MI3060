using System;
using System.Collections.Generic;
using System.Text;

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
