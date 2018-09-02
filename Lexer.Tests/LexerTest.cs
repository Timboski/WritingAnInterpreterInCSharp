using NUnit.Framework;
using Token;

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
                ( Token.Token.ASSIGN, "=" ),
                ( Token.Token.PLUS, "+" ),
                ( Token.Token.LPAREN, "(" ),
                ( Token.Token.RPAREN, ")" ),
                ( Token.Token.LBRACE, "{" ),
                ( Token.Token.RBRACE, "}" ),
                ( Token.Token.COMMA, "," ),
                ( Token.Token.SEMICOLON, ";" ),
                ( Token.Token.EOF, "" )
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
