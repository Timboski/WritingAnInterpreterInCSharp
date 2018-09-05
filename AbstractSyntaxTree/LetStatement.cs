using TokenNS;

namespace AbstractSyntaxTree
{
    public class LetStatement : IStatement
    {
        public LetStatement(Token token) => Token = token;

        public Token Token { get; } // The LET token.
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public string TokenLiteral() => Token.Literal;
    }
}
