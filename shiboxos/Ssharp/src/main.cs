using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.Lexer;
using static shiboxos.Ssharp.src.Token;
namespace shiboxos.Ssharp.src
{
    internal class main
    {
        public static void Start()
        {
            lexer_T lexer = Init_lexer(@"
                var name = ""john doe"";
                print(name);
            ");
            Token_T token = Init_Void_Token();
            while ((token = Lexer_get_next_token(ref lexer)).type != Token_T.Type.Token_OEF)
            {
                if (token.type == Token_T.Type.Token_STRING)
                    Console.WriteLine("String : " + token.value);
                else if (token.type == Token_T.Type.Token_ID)
                    Console.WriteLine("Identifier : " + token.value);
                else if (token.type == Token_T.Type.Token_LPARENT)
                    Console.WriteLine("Left Parent : " + token.value);
                else if (token.type == Token_T.Type.Token_RPARENT)
                    Console.WriteLine("Right Parent : " + token.value);
                else if (token.type == Token_T.Type.Token_EQUALS)
                    Console.WriteLine("Equals : " + token.value);
                else if (token.type == Token_T.Type.Token_KEYWORD)
                    Console.WriteLine("Keyword : \"" + token.value + "\"");
                else if (token.type == Token_T.Type.Token_SEMI)
                    Console.WriteLine("Semi Colons : " + token.value);
            }
        }


    }
}
