using TokenNS;

namespace AbstractSyntaxTree
{
    public class Identifier : IExpression
    {
        public Identifier(Token token)
        {
            Token = token;
            Value = token.Literal;
        }

        public Token Token { get; } // The IDENT token.
        public string Value { get; }

        public string TokenLiteral() => Token.Literal;
    }
}