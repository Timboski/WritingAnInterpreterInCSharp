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
            var token = MakeToken();
            ReadChar();
            return token;
        }

        private Token MakeToken()
        {
            switch (ch)
            {
                case '=': return new Token(Token.ASSIGN, ch);
                case ';': return new Token(Token.SEMICOLON, ch);
                case '(': return new Token(Token.LPAREN, ch);
                case ')': return new Token(Token.RPAREN, ch);
                case ',': return new Token(Token.COMMA, ch);
                case '+': return new Token(Token.PLUS, ch);
                case '{': return new Token(Token.LBRACE, ch);
                case '}': return new Token(Token.RBRACE, ch);
                case '\0': return new Token(Token.EOF, "");
                default: return new Token(Token.ILLEGAL, ch);
            }
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
