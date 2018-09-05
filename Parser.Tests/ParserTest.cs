using AbstractSyntaxTree;
using LexerNS;
using NUnit.Framework;
using System;
using System.Linq;
using TokenNS;

namespace ParserNS.Tests
{
    [TestFixture]
    public class ParserTest
    {
        [TestCase]
        public void TestLetStatements()
        {
            // Arrange.
            var input = string.Join(System.Environment.NewLine, new [] {
                "let x = 5;",
                "let y = 10;",
                "let foobar = 838383;"
            });

            // Act.
            var lexer = new Lexer(input);
            var parser = new Parser(lexer);
            var program = parser.ParseProgram();

            // Assert.
            Assert.NotNull(program, "ParseProgram() returned null");
            Assert.AreEqual(3, program.Statements.Count(), "program.Statements does not contain 3 statements.");

            // Arrange (some more).
            var tests = new[] {"x", "y", "foobar"};
            int testIndex = 0;
            foreach (var expectedIdentifier in tests)
            {
                var statement = program.Statements[testIndex];
                TestLetStatement(statement, expectedIdentifier);
            }
        }

        private void TestLetStatement(IStatement statement, string expectedIdentifier)
        {
            Assert.AreSame((string)Token.LET, (string)statement.TokenLiteral(), "TokenLiteral not 'let'.");
            var letStatement = statement as LetStatement;
            Assert.NotNull(letStatement, "Statement is not LET statement.");
            Assert.AreSame(expectedIdentifier, letStatement.Name.Value, "Unexpected Name.Value.");
            Assert.AreSame(expectedIdentifier, letStatement.Name.TokenLiteral(), "Unexpected Name.TokenLiteral.");
        }
    }
}
