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
        public BinaryTree(ICollection<T> collection)
        {

        }
    }

    public class Forest
    {

    }


    public class BinaryTreeNode<T>
    {

        #region
        public BinaryTreeNode<T> leftChild;
        public BinaryTreeNode<T> rightChild;
        public T value;
        public BinaryTreeNode(T value)
        {
            this.value = value;
        }
        public BinaryTreeNode()
        {
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

    }
}
