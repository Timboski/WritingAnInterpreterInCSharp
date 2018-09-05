using TokenNS;

namespace AbstractSyntaxTree
{
    public class Identifier : IExpression
    {
        public Token Token { get; set; } // The IDENT token.
        public string Value { get; set; }

    public string TokenLiteral() => Token.Literal;
    }
}