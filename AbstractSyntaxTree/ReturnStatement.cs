using TokenNS;

namespace AbstractSyntaxTree
{
    public class ReturnStatement : IStatement
    {
        public ReturnStatement(Token token) => Token = token;

        public Token Token { get; } // The RETURN token.
        public IExpression ReturnValue { get; set; }

        public string TokenLiteral() => Token.Literal;
    }
}
