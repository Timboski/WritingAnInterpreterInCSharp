using NUnit.Framework;
using TokenNS;

namespace LexerNS.Tests
{
    [TestFixture]
    public class LexerTest
    {
        [TestCase]
        public void TestNextToken_ReducedSet()
        {
            // Arrange
            var input = "=+(){},;";

            var tests = new(TokenType expectedType, string expectedLiteral)[] {
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

            // Act and Assert
            TestNextToken(input, tests);
        }

        [TestCase]
        public void TestNextToken_RealMonkey()
        {
            // Arrange
            var input = string.Join(System.Environment.NewLine, new[] {
                "let five = 5;",
                "let ten = 10;",
                "",
                "let add = fn(x, y) {",
                "  x + y;",
                "};",
                "",
                "let result = add(five, ten);"
            });

            var tests = new(TokenType expectedType, string expectedLiteral)[] {
                ( Token.LET, "let" ),
                ( Token.IDENT, "five" ),
                ( Token.ASSIGN, "=" ),
                ( Token.INT, "5" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "ten" ),
                ( Token.ASSIGN, "=" ),
                ( Token.INT, "10" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "add" ),
                ( Token.ASSIGN, "=" ),
                ( Token.FUNCTION, "fn" ),
                ( Token.LPAREN, "(" ),
                ( Token.IDENT, "x" ),
                ( Token.COMMA, "," ),
                ( Token.IDENT, "y" ),
                ( Token.RPAREN, ")" ),
                ( Token.LBRACE, "{" ),
                ( Token.IDENT, "x" ),
                ( Token.PLUS, "+" ),
                ( Token.IDENT, "y" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.RBRACE, "}" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "result" ),
                ( Token.ASSIGN, "=" ),
                ( Token.IDENT, "add" ),
                ( Token.LPAREN, "(" ),
                ( Token.IDENT, "five" ),
                ( Token.COMMA, "," ),
                ( Token.IDENT, "ten" ),
                ( Token.RPAREN, ")" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.EOF, "" )
            };

            // Act and Assert
            TestNextToken(input, tests);
        }

        [TestCase]
        public void TestNextToken_WithAddedGiberish()
        {
            // Arrange
            var input = string.Join(System.Environment.NewLine, new[] {
                "let five = 5;",
                "let ten = 10;",
                "",
                "let add = fn(x, y) {",
                "  x + y;",
                "};",
                "",
                "let result = add(five, ten);",
                "!-/*5;",
                "5 < 10 > 5;"
            });

            var tests = new(TokenType expectedType, string expectedLiteral)[] {
                ( Token.LET, "let" ),
                ( Token.IDENT, "five" ),
                ( Token.ASSIGN, "=" ),
                ( Token.INT, "5" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "ten" ),
                ( Token.ASSIGN, "=" ),
                ( Token.INT, "10" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "add" ),
                ( Token.ASSIGN, "=" ),
                ( Token.FUNCTION, "fn" ),
                ( Token.LPAREN, "(" ),
                ( Token.IDENT, "x" ),
                ( Token.COMMA, "," ),
                ( Token.IDENT, "y" ),
                ( Token.RPAREN, ")" ),
                ( Token.LBRACE, "{" ),
                ( Token.IDENT, "x" ),
                ( Token.PLUS, "+" ),
                ( Token.IDENT, "y" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.RBRACE, "}" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.LET, "let" ),
                ( Token.IDENT, "result" ),
                ( Token.ASSIGN, "=" ),
                ( Token.IDENT, "add" ),
                ( Token.LPAREN, "(" ),
                ( Token.IDENT, "five" ),
                ( Token.COMMA, "," ),
                ( Token.IDENT, "ten" ),
                ( Token.RPAREN, ")" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.BANG, "!" ),
                ( Token.MINUS, "-" ),
                ( Token.SLASH, "/" ),
                ( Token.ASTERISK, "*" ),
                ( Token.INT, "5" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.INT, "5" ),
                ( Token.LT, "<" ),
                ( Token.INT, "10" ),
                ( Token.GT, ">" ),
                ( Token.INT, "5" ),
                ( Token.SEMICOLON, ";" ),
                ( Token.EOF, "" )
            };

            // Act and Assert
            TestNextToken(input, tests);
        }

        private static void TestNextToken(string input, (TokenType expectedType, string expectedLiteral)[] tests)
        {
            // Act
            var l = new Lexer(input);
            int testIndex = 0;
            foreach (var (expectedType, expectedLiteral) in tests)
            {
                var token = l.NextToken();

                // Assert
                Assert.AreEqual((string)expectedType, (string)token.Type, $"tests[{testIndex}] - tokentype wrong");
                Assert.AreEqual(expectedLiteral, token.Literal, $"tests[{testIndex}] - literal wrong");

                ++testIndex;
            }
        }
    }
}
