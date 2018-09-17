using System.Collections.Generic;
using System.Linq;

namespace AbstractSyntaxTree
{
    /// <summary>
    /// NOTE: Changed name to ProgramRoot so does not get
    /// confused with a 'Program' entry class.
    /// </summary>
    public class ProgramRoot : INode
    {
        public List<IStatement> Statements { get; } = new List<IStatement>();

        public string String() => 
            string.Join("", Statements.Select(s => s.ToString()));

        public string TokenLiteral()
        {
            if (!Statements.Any()) return "";
            return Statements[0].TokenLiteral();
        }
    }
}
