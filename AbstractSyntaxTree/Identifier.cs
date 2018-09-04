using TokenNS;

namespace AbstractSyntaxTree
{
    internal class Identifier : IExpression
    {
        Token token; // The IDENT token.
        string value;

        public string TokenLiteral() => token.Literal;
    }
}