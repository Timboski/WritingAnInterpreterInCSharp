﻿using AbstractSyntaxTree;
using LexerNS;
using System.Collections.Generic;
using TokenNS;

namespace ParserNS
{
    public class Parser
    {
        private Lexer lexer;
        private Token curToken;
        private Token peekToken;
        private List<string> errors = new List<string>();

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;

            // Read two tokens, so curToken and peekToken are both set.
            NextToken();
            NextToken();
        }

        public ProgramRoot ParseProgram()
        {
            var program = new ProgramRoot();
            while (curToken.Type != Token.EOF)
            {
                var statement = ParseStatement();
                if (statement != null) program.Statements.Add(statement);
                NextToken();
            }
            return program;
        }

        public string[] Errors() => errors.ToArray();

        public void PeekError(TokenType token) 
            => errors.Add($"Expected next token to be {(string)token}, got {(string)peekToken.Type} instead.");

        private IStatement ParseStatement()
        {
            switch (curToken.Type)
            {
                case var token when token == Token.LET: return ParseLetStatement();
                default: return null;
            }
        }

        private IStatement ParseLetStatement()
        {
            var letStatement = new LetStatement(curToken);

            if (!ExpectPeek(Token.IDENT)) return null;
            letStatement.Name = new Identifier(curToken);
            if (!ExpectPeek(Token.ASSIGN)) return null;

            // TODO: We're skipping the expressions until we encounter a semicolon.
            while (!CurrTokenIs(Token.SEMICOLON)) NextToken();
            return letStatement;
        }

        private bool CurrTokenIs(TokenType tokenType) => curToken.Type == tokenType;

        private bool PeekTokenIs(TokenType tokenType) => peekToken.Type == tokenType;

        private bool ExpectPeek(TokenType tokenType)
        {
            if (!PeekTokenIs(tokenType))
            {
                PeekError(tokenType);
                return false;
            }

            NextToken();
            return true;
        }

        private void NextToken()
        {
            curToken = peekToken;
            peekToken = lexer.NextToken();
        }
    }
}