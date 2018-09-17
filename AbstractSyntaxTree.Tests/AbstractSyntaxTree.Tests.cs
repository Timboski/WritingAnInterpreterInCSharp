using NUnit.Framework;
using TokenNS;

namespace AbstractSyntaxTree.Tests
{
    [TestFixture]
    public class AbstractSyntaxTreeTest
    {
        [TestCase]
        public void TestString()
        {
            // Arrange
            var lhsIdentifierToken = new Token(Token.IDENT, "myVar");
            var rhsIdentifierToken = new Token(Token.IDENT, "anotherVar");
            var letToken = new Token(Token.LET, "let");

            var letStatement = new LetStatement(letToken)
            {
                Name = new Identifier(lhsIdentifierToken),
                Value = new Identifier(rhsIdentifierToken)
            };

            var program = new ProgramRoot();
            program.Statements.Add(letStatement);

            // Act
            var programString = program.String();

            // Assert
            var expected = "let myVar = anotherVar;";
            Assert.AreEqual(expected, programString);
        }
    }
}