namespace Token
{
    public struct Token
    {
        public TokenType type;
        public string literal;

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
