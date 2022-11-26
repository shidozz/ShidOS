using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.Lexer;
using static shiboxos.Ssharp.src.AST;
using static shiboxos.Ssharp.src.Token;
using static shiboxos.Kernel;

namespace shiboxos.Ssharp.src
{
    internal class Parser
    {
        public struct parser_T
        {
            public lexer_T lexer;
            public Token_T current_token;
        }
        public static Kernel k = new();
        public static parser_T init_parser(ref lexer_T lexer)
        {
            parser_T parser = new();
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 23)");
            parser.lexer = lexer;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 25)");
            parser.current_token = Lexer_get_next_token(ref lexer);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 27)");
            return parser;
        }
        public static void parser_eat(ref parser_T parser, int token_type)
        {
            if (parser.current_token.type == (Token_T.Type)token_type)
            {
                parser.current_token = Lexer_get_next_token(ref parser.lexer);
                k.mDebugger.Send("REUSSI (file: Main.cs, ligne: 32)");
            }
            else
            {
                Console.WriteLine("Token " + parser.current_token.value + " inatendu" + parser.current_token.type);
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 37)");
            }
        }

        public static AST_T parser_parse(ref parser_T parser)
        {
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 42)");
            return parser_parse_statements(ref parser);
        }
        public static AST_T parser_parse_statement(ref parser_T parser)
        {
            switch (parser.current_token.type)
            {
                case Token_T.Type.Token_ID:
                    return parser_parse_id(ref parser);
                case Token_T.Type.Token_KEYWORD:
                    return parser_parse_id(ref parser);
                default:
                    break;
            }
            return new();
        }
        public static AST_T parser_parse_statements(ref parser_T parser)
        {
            AST_T compound = init_ast((int) AST_T.Type.AST_COMPOUND);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 61)");
            compound.compound_value = new AST_T[] { };
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 63)");
            AST_T ast_statement = parser_parse_statement(ref parser);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 65)");
            compound.compound_value[0] = ast_statement;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 66)");
            compound.compound_size += 1;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 68)");
            while (parser.current_token.type != Token_T.Type.Token_SEMI)
            {
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 70)");
                parser_eat(ref parser, (int) Token_T.Type.Token_SEMI);
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 73)");
                ast_statement = parser_parse_statement(ref parser);
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 75)");
                compound.compound_value[0] = ast_statement;
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 77)");
                compound.compound_size += 1;
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 79)");
            }
            return compound;
        }
        public static AST_T parser_parse_expr(ref parser_T parser)
        {

            return new();
        }
        public static AST_T parser_parse_factor(ref parser_T parser)
        {

            return new();
        }
        public static AST_T parser_parse_term(ref parser_T parser)
        {

            return new();
        }
        public static AST_T parser_parse_function(ref parser_T parser)
        {

            return new();
        }
        public static AST_T parser_parse_variable(ref parser_T parser)
        {
            char[] token_value = parser.current_token.value.ToCharArray();
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 107)");
            parser_eat(ref parser,(int) Token_T.Type.Token_ID);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 109)");
            if (parser.current_token.type == Token_T.Type.Token_LPARENT)
                return parser_parse_function(ref parser);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 112)");

            AST_T ast_variable = init_ast((int) AST_T.Type.AST_VARIABLE);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 114)");
            ast_variable.variable_name = token_value;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 116)");
            return ast_variable;
        }
        public static AST_T parser_parse_variable_definition(ref parser_T parser)
        {
            parser_eat(ref parser, (int)Token_T.Type.Token_ID);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 122)");
            char[] variable_definition_name = parser.current_token.value.ToCharArray();
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 124)");
            parser_eat(ref parser, (int)Token_T.Type.Token_ID);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 126)");
            parser_eat(ref parser, (int)Token_T.Type.Token_EQUALS);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 128)");
            AST_T variable_definition_value = parser_parse_expr(ref parser);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 130)");
            AST_T variable_definition = init_ast((int) AST_T.Type.AST_VARIABLE_DEFINITION);
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 132)");
            variable_definition.variable_definition_name = variable_definition_name;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 134)");
            variable_definition.variable_definition_value = variable_definition_value;
            k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 136)");
            return new();
        }
        public static AST_T parser_parse_id(ref parser_T parser)
        {
            if(parser.current_token.value.ToLower() != "var")
            {
                k.mDebugger.Send("REUSSI (file: Parser.cs, ligne: 142)");
                return parser_parse_variable_definition(ref parser);
            }
            else
            {
                return parser_parse_variable(ref parser);
            }
        }
        public static AST_T parser_parse_string(ref parser_T parser)
        {

            return new();
        }
    }
}
