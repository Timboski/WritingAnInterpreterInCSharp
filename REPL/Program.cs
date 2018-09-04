using LexerNS;
using System;
using TokenNS;

namespace REPL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello {Environment.UserName}! This is the Monkey programming language!");
            Console.WriteLine("Feel free to type in commands");

            while (true)
            {
                Console.Write(">>");
                var input = Console.ReadLine();
                var lexer = new Lexer(input);

                for (var tok = lexer.NextToken(); tok.Type != Token.EOF; tok = lexer.NextToken())
                {
                    Console.WriteLine($"{{Type:{(string)tok.Type} literal:{tok.Literal}}}");
                }
            }
        }
    }
}
