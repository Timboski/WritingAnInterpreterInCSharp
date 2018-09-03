using System;
using TokenNS;

namespace LexerNS
{
    public class Lexer
    {
        private string input;
        private int position;
        private int readPosition;
        private char ch;

        public Lexer(string input)
        {
            this.input = input;
            ReadChar();
        }

        public Token NextToken()
        {
            SkipWhitespace();

            Token token;
            switch (ch)
            {
                case '=':
                    {
                        token = new Token(Token.ASSIGN, ch);
                        break;
                    }
                case ';':
                    {
                        token = new Token(Token.SEMICOLON, ch);
                        break;
                    }
                case '(':
                    {
                        token = new Token(Token.LPAREN, ch);
                        break;
                    }
                case ')':
                    {
                        token = new Token(Token.RPAREN, ch);
                        break;
                    }
                case ',':
                    {
                        token = new Token(Token.COMMA, ch);
                        break;
                    }
                case '+':
                    {
                        token = new Token(Token.PLUS, ch);
                        break;
                    }
                case '{':
                    {
                        token = new Token(Token.LBRACE, ch);
                        break;
                    }
                case '}':
                    {
                        token = new Token(Token.RBRACE, ch);
                        break;
                    }
                case '\0':
                    {
                        token = new Token(Token.EOF, "");
                        break;
                    }
                default:
                    {
                        if (char.IsLetter(ch))
                        {
                            var identifier = ReadIdentifier();
                            // NOTE: Exit early as ReadIdenfier will have already advanced
                            // the position to the next token.
                            return new Token(Token.LookupIdent(identifier), identifier);
                        }

                        token = new Token(Token.ILLEGAL, ch);
                        break;
                    }
            }

            ReadChar();
            return token;
        }

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(ch)) ReadChar();
        }

        private string ReadIdentifier()
        {
            var startPosition = position;
            while (char.IsLetter(ch)) ReadChar();
            int length = position - startPosition;
            return input.Substring(startPosition, length);
        }

        private void ReadChar()
        {
            // Get character.
            if (readPosition >= input.Length) ch = '\0';
            else ch = input[readPosition];

            // Increment positions.
            position = readPosition;
            ++readPosition;
        }
    }
}
