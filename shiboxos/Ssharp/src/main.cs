using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace shiboxos.Ssharp.src
{
    internal class main
    {
        public main()
        {
            Token t = new();
            Lexer lex = new();
            Lexer.lexer_T lexer = lex.Init_lexer("var name = \"john doe\";\nprint(name);".ToCharArray());
            Token.Token_T token = t.Init_Void_Token();
            while ((token = lex.Lexer_get_next_token(lexer)).type != Token.Token_T.Type.Token_OEF)
            {
                Console.WriteLine("TOKEN(" + token.type + "" + token.value + ")");
            }
        }


    }
}
