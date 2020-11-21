using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Interpreter
    {
        #region basic identifier
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
 
        public static bool IsOperator(string s)
        {
            foreach (string op in operatorList) if (s == op) return true;
            return false;
        }
        public static bool IsOperand(string s)
        {
            throw new NotImplementedException("khong lam ma doi co an");
        }

        #endregion

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


        public static BinaryTreeNode<string> BuildTree(List<string> expression)
        {
            var operatorStack = new Stack<BinaryTreeNode<string>>();
            var operandStack = new Stack<BinaryTreeNode<string>>();
            BinaryTreeNode<string> node;
            foreach(string s in expression)
            {
                if (IsOperator(s))
                {
                    while (operatorStack.Count > 0 && GetPriority(s) <= GetPriority(operatorStack.Peek().value)) //result.Add(stack.Pop());
                    {
                        node = operatorStack.Pop();
                        node.rightChild = operandStack.Pop();
                        node.leftChild = operandStack.Pop();
                        operandStack.Push(node);
                    }
                    operatorStack.Push(new BinaryTreeNode<string>(s));
                }
                else if (s == "(") operatorStack.Push(new BinaryTreeNode<string>("("));
                else if (s == ")")
                {
                    while (operatorStack.Peek().value != "(") //result.Add(stack.Pop());
                    {
                        node = operatorStack.Pop();
                        node.rightChild = operandStack.Pop();
                        node.leftChild = operandStack.Pop();
                        operandStack.Push(node);
                    }
                    operatorStack.Pop();     //pop "("
                }
                //operand
                else operandStack.Push(new BinaryTreeNode<string>(s));
            }
            node = operatorStack.Pop();
            node.rightChild = operandStack.Pop();
            node.leftChild = operandStack.Pop();
            return node;
        }



        public static double ReadValue(object x, Dictionary<string, double> dict)
        {
            double a;
            if (double.TryParse(x.ToString(), out a))
                return double.Parse(x.ToString());
            else
                return dict[x.ToString()];

        }
    }
}
