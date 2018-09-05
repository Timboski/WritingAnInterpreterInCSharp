using TokenNS;

namespace AbstractSyntaxTree
{
    public class LetStatement : IStatement
    {
        public Token Token { get; set; } // The LET token.
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public string TokenLiteral() => Token.Literal;
    }
}
