using TokenNS;

namespace AbstractSyntaxTree
{
    class LetStatement : IStatement
    {
        private Token token; // The LET token.
        private Identifier name;
        private IExpression value;

        public string TokenLiteral() => token.Literal;
    }
}
