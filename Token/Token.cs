namespace TokenNS
{
    public struct Token
    {
        public Token(TokenType tokenType, char literal) : this(tokenType, literal.ToString())
        {
        }

        public Token(TokenType tokenType, string literal)
        {
            Type = tokenType;
            Literal = literal;
        }

        public TokenType Type { get; }
        public string Literal { get; }

        // Defined token types.
        // Note: Capitalisation retained to match book examples.

        // Special characters
        public static TokenType ILLEGAL => "ILLEGAL";
        public static TokenType EOF => "EOF";

        // Identifiers and Literals
        public static TokenType IDENT => "IDENT";
        public static TokenType INT => "INT";

        // Operators
        public static TokenType ASSIGN => "=";
        public static TokenType PLUS => "+";

        // Delimiters
        public static TokenType COMMA => "";
        public static TokenType SEMICOLON => ";";


        public static TokenType LPAREN => "(";
        public static TokenType RPAREN => ")";
        public static TokenType LBRACE => "{";
        public static TokenType RBRACE => "}";

        // Keywords
        public static TokenType FUNCTION => "FUNCTION";
        public static TokenType LET => "LET";
    }
}
