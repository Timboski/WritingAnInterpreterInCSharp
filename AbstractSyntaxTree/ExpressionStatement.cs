using TokenNS;

namespace AbstractSyntaxTree
{
    public class ExpressionStatement : IStatement
    {
        public ExpressionStatement(Token token) => Token = token;

        public Token Token { get; } // The RETURN token.
        public IExpression Expression { get; set; }

        public string String()
        {
            if (Expression == null) return "";
            return Expression.String();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
