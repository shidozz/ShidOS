using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.Lexer;
using static shiboxos.Ssharp.src.Token;
using static shiboxos.Ssharp.src.Parser;
using static shiboxos.Ssharp.src.AST;
namespace shiboxos.Ssharp.src
{
    internal class main
    {
        public static void Start()
        {
            lexer_T lexer = Init_lexer("var name = salam;");
            Token_T token = Init_Void_Token();
            /*while ((token = Lexer_get_next_token(ref lexer)).type != Token_T.Type.Token_OEF)
            {
                if (token.type == Token_T.Type.Token_ID) {
                    foreach(string kw in Keywords)
                    {
                        if (kw.ToLower() == token.value.ToLower())
                        {
                            token.type = Token_T.Type.Token_KEYWORD;
                        }
                    }
                }
            }*/
            parser_T parser = init_parser(ref lexer);
            k.mDebugger.Send("REUSSI (file: Main.cs ligne: 36)");
            AST_T root = parser_parse(ref parser);
            k.mDebugger.Send("REUSSI (file: Main.cs ligne: 38)");
            Console.WriteLine("root: " + (int) root.type);
            k.mDebugger.Send("REUSSI (file: Main.cs ligne: 40)");
        }


    }
}
