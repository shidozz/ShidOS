using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.main;
using static shiboxos.Ssharp.src.Lexer;

namespace shiboxos.Ssharp.src
{
    internal class Token
    {
        public struct Token_T
        {
            public enum Type
            {
                Token_ID,
                Token_EQUALS,
                Token_STRING,
                Token_SEMI,
                Token_LPARENT,
                Token_RPARENT,
                Token_OEF,
                Token_KEYWORD,
                Token_NUMBER
            }
            public Type type;
            public string value;
            public Token_T(Type type, string value)
            {
                this.type = type;
                this.value = value;
            }
        }

        public static Token_T Init_Token(int type, string value)
        {
            return new((Token_T.Type)type, value);
        }
        public static Token_T Init_Void_Token()
        {
            return new(Token_T.Type.Token_OEF, "");
        }
    }
}
