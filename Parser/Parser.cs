using System;
using AbstractSyntaxTree;
using LexerNS;
using TokenNS;

namespace ParserNS
{
    public class Parser
    {
        private Lexer lexer;
        private Token curToken;
        private Token peekToken;

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;

            // Read two tokens, so curToken and peekToken are both set.
            NextToken();
            NextToken();
        }

        public ProgramRoot ParseProgram() => null;

        private void NextToken()
        {
            curToken = peekToken;
            peekToken = lexer.NextToken();
        }
    }
}
