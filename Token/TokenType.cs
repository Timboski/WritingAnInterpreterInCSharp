namespace Token
{
    public struct TokenType
    {
        private readonly string tokenType;

        public TokenType(string tt)
        {
            tokenType = tt;
        }

        // Cnversion from TokenType to string
        public static implicit operator string(TokenType tt)
        {
            return tt.tokenType;
        }
        //  Conversion from string to TokenType
        public static implicit operator TokenType(string s)
        {
            return new TokenType(s);
        }
    }
}