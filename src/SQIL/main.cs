using System;
using lexer;
using parser;
using evaluator;
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
            Evaluator evaluator = new Evaluator();
           
            List<string> programLexed = Lexer.Lex();
            List<string> programParsed = Parser.Parse(programLexed);

            Evaluator.evaluate(programParsed);
            
           

            
            
        }
       
       
    
    }
}
