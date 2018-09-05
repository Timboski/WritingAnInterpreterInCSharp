using System.Linq;

namespace AbstractSyntaxTree
{
    /// <summary>
    /// NOTE: Changed name to ProgramRoot so does not get
    /// confused with a 'Program' entry class.
    /// </summary>
    public class ProgramRoot : INode
    {
        public IStatement[] Statements { get; set; }

        public string TokenLiteral()
        {
            if (!Statements.Any()) return "";
            return Statements[0].TokenLiteral();
        }
    }
}
