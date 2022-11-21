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
            public uint i;
            public char[] contents;
            public lexer_T(char c, uint i, char[] contents)
            {
                this.c = c;
                this.i = i;
                this.contents = contents;
            }
        }
        public lexer_T Init_lexer(char[] contents)
        {
            lexer_T lexer = new();
            lexer.i = 0;
            lexer.c = contents[lexer.i];
            lexer.contents = contents;
            return lexer;
        }
        public void Lexer_advance(lexer_T lexer)
        {
            if (lexer.c != (char)0 && lexer.i < lexer.contents.ToString().Length)
            {
                lexer.i++;
                lexer.c = lexer.contents[lexer.i];
            }
        }

        public Token_T Lexer_advance_with_token(lexer_T lexer, Token_T token)
        {
            Lexer_advance(lexer);
            return token;
        }
        public void Lexer_skip_whitespace(lexer_T lexer)
        {
            while (lexer.c != (char)0 || lexer.c == 10)
            {
                Lexer_advance(lexer);
            }
        }
        public Token_T Lexer_get_next_token(lexer_T lexer)
        {
            while (lexer.c != (char)0 && lexer.i < lexer.contents.ToString().Length)
            {
                if (lexer.c == ' ' || lexer.c == 10)
                    Lexer_skip_whitespace(lexer);
                if (char.IsDigit(lexer.c))
                {
                    return Lexer_collect_id(lexer);
                }
                if (lexer.c == '"')
                {
                    return Lexer_collect_string(lexer);
                }

                switch (lexer.c)
                {
                    case '=':
                        return Lexer_advance_with_token(lexer, new(Token_T.Type.Token_EQUALS, lexer.c.ToString()));
                    case ';':
                        return Lexer_advance_with_token(lexer, new(Token_T.Type.Token_SEMI, lexer.c.ToString()));
                    case '(':
                        return Lexer_advance_with_token(lexer, new(Token_T.Type.Token_LPARENT, lexer.c.ToString()));
                    case ')':
                        return Lexer_advance_with_token(lexer, new(Token_T.Type.Token_RPARENT, lexer.c.ToString()));

                }
            }
            Token t = new();
            return t.Init_Void_Token();
        }
        public Token_T Lexer_collect_string(lexer_T lexer)
        {
            string value = string.Empty;
            while (lexer.c != '"')
            {
                value += lexer.c;
                Lexer_advance(lexer);
            }
            Lexer_advance(lexer);
            return new(Token_T.Type.Token_STRING, value);
        }
        public string Lexer_get_current_as_string(lexer_T lexer)
        {
            string str = ((char)0).ToString();
            str += lexer.c;
            str += ((char)0);
            return str;
        }

        public Token_T Lexer_collect_id(lexer_T lexer)
        {
            string value = ((char)0).ToString();
            while (char.IsDigit(lexer.c))
            {
                value += lexer.c;
                Lexer_advance(lexer);
            }
            return new(Token_T.Type.Token_ID, value);
        }
    }
}
