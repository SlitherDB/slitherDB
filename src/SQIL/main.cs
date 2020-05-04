using System;
using lexer;
using parser;
using System.IO;
using System.Collections.Generic;
namespace interpreter
{
    public class Transpiler
    {
        public static void Main(string[] args)
        {
            
            Lexer lexer = new Lexer();
            Parser parser = new Parser();
            List<string> programLexed = Lexer.Lex();
            List<string> programParsed = Parser.Parse(programLexed);

        }
       
       
    
    }
}
