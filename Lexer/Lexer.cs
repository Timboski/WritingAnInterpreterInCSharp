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
                case '-':
                    {
                        token = new Token(Token.MINUS, ch);
                        break;
                    }
                case '!':
                    {
                        token = new Token(Token.BANG, ch);
                        break;
                    }
                case '/':
                    {
                        token = new Token(Token.SLASH, ch);
                        break;
                    }
                case '*':
                    {
                        token = new Token(Token.ASTERISK, ch);
                        break;
                    }
                case '<':
                    {
                        token = new Token(Token.LT, ch);
                        break;
                    }
                case '>':
                    {
                        token = new Token(Token.GT, ch);
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

                        if (char.IsDigit(ch)) return new Token(Token.INT, ReadNumber());

                        token = new Token(Token.ILLEGAL, ch);
                        break;
                    }
            }

            ReadChar();
            return token;
        }

        private string ReadNumber() => ReadSubstringMatchingCriteria(char.IsDigit);

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(ch)) ReadChar();
        }

        private string ReadIdentifier() => ReadSubstringMatchingCriteria(char.IsLetter);

        private string ReadSubstringMatchingCriteria(Func<char, bool> criteria)
        {
            var startPosition = position;
            while (criteria(ch)) ReadChar();
            int length = position - startPosition;
            return input.Substring(startPosition, length);
        }

        private void ReadChar()
        {
            // Get character.
            ch = PeekChar();

            // Increment positions.
            position = readPosition;
            ++readPosition;
        }

        private char PeekChar()
        {
            if (readPosition >= input.Length) return '\0';
            return input[readPosition];
        }
    }
}
