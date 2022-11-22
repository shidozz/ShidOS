using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shiboxos.Ssharp.src.Token;

namespace shiboxos.Ssharp.src
{
    internal class Lexer
    {
        public struct lexer_T
        {
            public char c;
            public int i;
            public string contents;
            public int len;
            public lexer_T(string contents, int len)
            {
                this.c = contents[0];
                this.i = 0;
                // hacky shit ikr
                this.contents = contents + "E";
                this.len = len + 1;
            }
        }

        public static string[] Keywords = new string[] { "var", "let", "const", "print", "clear" }; 

        public static lexer_T Init_lexer(string contents)
        {
            lexer_T lexer = new(contents, contents.Length);
            return lexer;
        }
        public static void Lexer_advance(ref lexer_T lexer)
        {
            lexer.i++;
            lexer.c = lexer.contents[lexer.i];
        }

        public static Token_T Lexer_advance_with_token(ref lexer_T lexer, Token_T token)
        {
            if (lexer.i == lexer.len - 1)
            {
                return Init_Void_Token();
            }
            Lexer_advance(ref lexer);
            return token;
        }
        public static void Lexer_skip_whitespace(ref lexer_T lexer)
        {
            while (lexer.c == ' ' || lexer.c == '\n' || lexer.c == '\0' || lexer.c == '\r')
            {
                Lexer_advance(ref lexer);
            }
        }
        public static Token_T Lexer_get_next_token(ref lexer_T lexer)
        {
            Lexer_skip_whitespace(ref lexer);
            string val = string.Empty;
            if (char.IsNumber(lexer.c))
            {
                return Lexer_collect_num(ref lexer);
            }
            if (lexer.c == '"')
            {
                return Lexer_collect_string(ref lexer);
            }


            if (char.IsDigit(lexer.c))
            {
                return Lexer_collect_id(ref lexer);
            }
            switch (lexer.c)
            {
                case '=':
                    return Lexer_advance_with_token(ref lexer, new(Token_T.Type.Token_EQUALS, lexer.c.ToString()));
                case ';':
                    return Lexer_advance_with_token(ref lexer, new(Token_T.Type.Token_SEMI, lexer.c.ToString()));
                case '(':
                    return Lexer_advance_with_token(ref lexer, new(Token_T.Type.Token_LPARENT, lexer.c.ToString()));
                case ')':
                    return Lexer_advance_with_token(ref lexer, new(Token_T.Type.Token_RPARENT, lexer.c.ToString()));
            }
            while (lexer.i < lexer.len - 1 && lexer.c.ToString().Length == 1 && lexer.c != '\r' && lexer.c != '\0' && lexer.c != ' ' && lexer.c != '\n' && lexer.c != '=' && lexer.c != ';' && lexer.c != '(' && lexer.c != ')' && lexer.c != '"')
            {
                val += lexer.c;
                Lexer_advance(ref lexer);
            }
            if (lexer.i == lexer.len - 1)
            {
                return Init_Void_Token();
            }
            return new Token_T(Token_T.Type.Token_ID, val);
        }
        public static Token_T Lexer_collect_string(ref lexer_T lexer)
        {
            Lexer_advance(ref lexer);
            string value = string.Empty;
            while (lexer.c != '"')
            {
                value += lexer.c;
                Lexer_advance(ref lexer);
            }
            Lexer_advance(ref lexer);
            return new(Token_T.Type.Token_STRING, value);
        }
        public static string Lexer_get_current_as_string(lexer_T lexer)
        {
            string str = string.Empty;
            str += lexer.c;
            return str;
        }

        public static Token_T Lexer_collect_id(ref lexer_T lexer)
        {
            string value = string.Empty;
            while (char.IsLetterOrDigit(lexer.c))
            {
                value += lexer.c;
                Lexer_advance(ref lexer);
            }
            return new(Token_T.Type.Token_ID, value);
        }
        public static Token_T Lexer_collect_num(ref lexer_T lexer)
        {
            string value = string.Empty;
            while (char.IsNumber(lexer.c))
            {
                value += lexer.c;
                Lexer_advance(ref lexer);
            }
            return new(Token_T.Type.Token_NUMBER, value);
        }
    }
}
