using NUnit.Framework;
using TokenNS;

namespace Lexer.Tests
{
    [TestFixture]
    public class LexerTest
    {
        [TestCase]
        public void TestNextToken()
        {
            // Arrange
            var input = "=+(){},;";

            var tests = new (TokenType expectedType, string expectedLiteral)[] {
                ( Token.ASSIGN, "=" ),
                ( Token.PLUS, "+" ),
                ( Token.LPAREN, "(" ),
                ( Token.RPAREN, ")" ),
                ( Token.LBRACE, "{" ),
                ( Token.RBRACE, "}" ),
                ( Token.COMMA, "," ),
                ( Token.SEMICOLON, ";" ),
                ( Token.EOF, "" )
            };

            // Act
            var l = new Lexer(input);
            int testIndex = 0;
            foreach (var (expectedType, expectedLiteral) in tests)
            {
                var token = l.NextToken();

                // Assert
                Assert.Equals(token.Type, expectedType, $"tests[{testIndex}] - tokentype wrong");
                Assert.Equals(token.Literal, expectedLiteral, $"tests[{testIndex}] - literal wrong");

                ++testIndex;
            }
        }
    }
}
