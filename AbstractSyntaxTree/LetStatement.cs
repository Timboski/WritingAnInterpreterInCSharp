using System.Text;
using TokenNS;

namespace AbstractSyntaxTree
{
    public class LetStatement : IStatement
    {
        public LetStatement(Token token) => Token = token;

        public Token Token { get; } // The LET token.
        public Identifier Name { get; set; }
        public IExpression Value { get; set; }

        public string String()
        {
            var sb = new StringBuilder();
            sb.Append(TokenLiteral());
            sb.Append(" ");
            sb.Append(Name.String());
            sb.Append(" = ");
            if (Value != null) sb.Append(Value.String());
            sb.Append(";");
            return sb.ToString();
        }

        public string TokenLiteral() => Token.Literal;
    }
}
