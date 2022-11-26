using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shiboxos.Ssharp.src
{
    internal class AST
    {
        public class AST_T
        {
            public enum Type
            {
                AST_VARIABLE_DEFINITION,
                AST_VARIABLE,
                AST_FUNCTION_CALL,
                AST_STRING,
                AST_COMPOUND
            };
            public Type type;

            // AST VARIABLE DEFINITION

            public char[] variable_definition_name;
            public AST_T variable_definition_value;

            // AST VARIABLE

            public char[] variable_name;

            // AST FUNCTION CALL

            public char[] function_call_name;
            public AST_T function_call_argument;
            public int function_call_argument_size;

            // AST STRING

            public char[] string_value;

            // AST COMPOUND

            public AST_T[] compound_value;
            public int compound_size;

        };
        public static AST_T init_ast(AST_T.Type type)
        {
            AST_T ast = new AST_T();
            ast.type = type;
            return ast;
        }
    }
}
