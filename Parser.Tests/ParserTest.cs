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
            var errors = string.Join(Environment.NewLine, parser.Errors());
            Assert.False(
                parser.Errors().Any(), 
                $"Found {parser.Errors().Count()} parser errors:{Environment.NewLine}{errors}"
            );

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
                ++testIndex;
            }
        }

        private void TestLetStatement(IStatement statement, string expectedIdentifier)
        {
            Assert.AreEqual("let", statement.TokenLiteral(), "TokenLiteral not 'let'.");
            var letStatement = statement as LetStatement;
            Assert.NotNull(letStatement, "Statement is not LET statement.");
            Assert.AreEqual(expectedIdentifier, letStatement.Name.Value, "Unexpected Name.Value.");
            Assert.AreEqual(expectedIdentifier, letStatement.Name.TokenLiteral(), "Unexpected Name.TokenLiteral.");
        }
    }
}
