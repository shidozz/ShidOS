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
            bool itsKw = false;
            lexer_T lexer = Init_lexer(@"
                var name = ""john doe"";
                var nombre = 10;
                print(name);
            ");
            Token_T token = Init_Void_Token();
            while ((token = Lexer_get_next_token(ref lexer)).type != Token_T.Type.Token_OEF)
            {
                itsKw = false;
                if (token.type == Token_T.Type.Token_STRING)
                    Console.WriteLine("String : \"" + token.value + "\"");
                else if (token.type == Token_T.Type.Token_ID) {
                    foreach(string kw in Keywords)
                    {
                        if (kw.ToLower() == token.value.ToLower())
                        {
                            itsKw = true;
                            token.type = Token_T.Type.Token_KEYWORD;
                            Console.WriteLine("Keyword : " + token.value);
                        }
                    }
                    if(itsKw == false)
                        Console.WriteLine("Identifier : " + token.value); 
                }
                else if (token.type == Token_T.Type.Token_LPARENT)
                    Console.WriteLine("Left Parent : " + token.value);
                else if (token.type == Token_T.Type.Token_RPARENT)
                    Console.WriteLine("Right Parent : " + token.value);
                else if (token.type == Token_T.Type.Token_EQUALS)
                    Console.WriteLine("Equals : " + token.value);
                else if (token.type == Token_T.Type.Token_SEMI)
                    Console.WriteLine("Semi Colons : " + token.value);
                else if (token.type == Token_T.Type.Token_NUMBER)
                    Console.WriteLine("Number : " + token.value);
            }
        }


    }
}
