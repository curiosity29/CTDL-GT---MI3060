using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class Tokenizor
    {
        public List<string> tokens = new List<string>()
        {
            "+", "-", "*", "/", "%", "|", "&", "!", "^", "->", "<->", "(", ")"
        };                          //token
        public void AddToken(List<string> newtokens)
        {
            //this.tokens = this.tokens.AddRange(newtokens);
            foreach (string s in newtokens)
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
}
