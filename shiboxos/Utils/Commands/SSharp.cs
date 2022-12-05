using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.Lexer;
using static shiboxos.Ssharp.src.Token;
using static shiboxos.Ssharp.src.Parser;
using static shiboxos.Ssharp.src.AST;
using Console = System.Console;

namespace shiboxos.Utils.Commands
{
    internal class SSharp : ICommand
    {
        public SSharp()
        {
            Name = "SSharp";
            Description = "ShidozzSharp Est Un Langage De Programmation Orientee System D'Exploitation";
        }
        public override void Execute(string[] args = null)
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
            AST_T root = parser_parse(ref parser);
            Console.WriteLine("root: " + (int)root.type);
            Console.WriteLine("size: " + (int)root.compound_size);
        }


    }
}
