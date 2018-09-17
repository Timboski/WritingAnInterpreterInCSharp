using TokenNS;

namespace AbstractSyntaxTree
{
    public class ExpressionStatement : IStatement
    {
        public ExpressionStatement(Token token) => Token = token;

        public Token Token { get; } // The RETURN token.
        public IExpression Expression { get; set; }

        public string TokenLiteral() => Token.Literal;
    }
}
