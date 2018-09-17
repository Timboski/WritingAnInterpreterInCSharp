using System.Text;
using TokenNS;

namespace AbstractSyntaxTree
{
    public class ReturnStatement : IStatement
    {
        public ReturnStatement(Token token) => Token = token;

        public Token Token { get; } // The RETURN token.
        public IExpression ReturnValue { get; set; }

        public string String()
        {
            var sb = new StringBuilder();
            sb.Append(TokenLiteral());
            sb.Append(" ");
            if (ReturnValue != null) sb.Append(ReturnValue.String());
            sb.Append(";");
            return sb.ToString();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
