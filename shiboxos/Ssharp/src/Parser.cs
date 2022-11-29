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
            parser.lexer = lexer;
            parser.current_token = Lexer_get_next_token(ref lexer);
            return parser;
        }
        public static void parser_eat(ref parser_T parser, Token_T.Type token_type)
        {
            if (parser.current_token.type == token_type)
            {
                parser.current_token = Lexer_get_next_token(ref parser.lexer);
                Console.WriteLine("Token(Value: " + parser.current_token.value + ",Type: " + (int)parser.current_token.type + ")");
            }
            else
            {
                Console.WriteLine("Token.Inatendu(Value: " + parser.current_token.value + ",Type: " + (int) parser.current_token.type + ")");
            }
        }

        public static AST_T parser_parse(ref parser_T parser)
        {
            return parser_parse_statements(ref parser);
        }
        public static AST_T parser_parse_statement(ref parser_T parser)
        {
            switch (parser.current_token.type)
            {
                case Token_T.Type.Token_ID:
                    return parser_parse_id(ref parser);
                default:
                    return new();
            }
        }
        public static AST_T parser_parse_statements(ref parser_T parser)
        {
            AST_T compound = init_ast(AST_T.Type.AST_COMPOUND);
            compound.compound_value = new AST_T[] { };
            AST_T ast_statement = parser_parse_statement(ref parser);
            k.mDebugger.Send("ast_statement = " + ((int) ast_statement.type));
            compound.compound_value = new AST_T[] { ast_statement };
            compound.compound_size += 1;
            while (parser.current_token.type != Token_T.Type.Token_SEMI)
            {
                parser_eat(ref parser, Token_T.Type.Token_SEMI);
                ast_statement = parser_parse_statement(ref parser);
                compound.compound_value[0] = ast_statement;
                compound.compound_size += 1;
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
            
            parser_eat(ref parser, Token_T.Type.Token_ID);

            if (parser.current_token.type == Token_T.Type.Token_LPARENT)
                return parser_parse_function(ref parser);

            AST_T ast_variable = init_ast(AST_T.Type.AST_VARIABLE);
            
            ast_variable.variable_name = token_value;
            
            return ast_variable;
        }
        public static AST_T parser_parse_variable_definition(ref parser_T parser)
        {
            parser_eat(ref parser, Token_T.Type.Token_ID);
            
            char[] variable_definition_name = parser.current_token.value.ToCharArray();
            
            parser_eat(ref parser, Token_T.Type.Token_ID);
            
            parser_eat(ref parser, Token_T.Type.Token_EQUALS);
            
            AST_T variable_definition_value = parser_parse_expr(ref parser);
            
            AST_T variable_definition = init_ast(AST_T.Type.AST_VARIABLE_DEFINITION);
            
            variable_definition.variable_definition_name = variable_definition_name;
            
            variable_definition.variable_definition_value = variable_definition_value;
            return variable_definition;
        }
        public static AST_T parser_parse_id(ref parser_T parser)
        {
            if(parser.current_token.value.ToLower() != "var")
            {
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
