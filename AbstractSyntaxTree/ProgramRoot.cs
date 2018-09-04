using System.Linq;

namespace AbstractSyntaxTree
{
    /// <summary>
    /// NOTE: Changed name to ProgramRoot so does not get
    /// confused with a 'Program' entry class.
    /// </summary>
    public class ProgramRoot : INode
    {
        private IStatement[] statements;

        public string TokenLiteral()
        {
            if (!statements.Any()) return "";
            return statements[0].TokenLiteral();
        }
    }
}
