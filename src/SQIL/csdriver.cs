using System;
using lexer;
using parser;
using evaluator;
using System.IO;
using System.Collections.Generic;
namespace interpreter
{
    public class Interpreter
    {
        public static void SQLInterpreter(string[] file)
        {
            
            Lexer lexer = new Lexer();
            Parser parser = new Parser();
            Evaluator evaluator = new Evaluator();
           
            List<string> programLexed = Lexer.Lex(file);
            List<string> programParsed = Parser.Parse(programLexed);

            Evaluator.evaluate(programParsed);


            
            
        }
       
       
    
    }
}
