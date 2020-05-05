using System;
using System.IO;
using System.Collections.Generic;
namespace lexer
{
    public class Lexer
    {

       
        static int line = 0;
        static List<string> Tokens = new List<string>();

        public static List<string> Lex()
        {
            
            //Get the SQIL file
            string[] file = System.IO.File.ReadAllLines("project.SQIL");
            //Go through each line of the program
            while (line <= file.Length - 1) {
                //Get the current line that needs to be Lexed 
                string currentLineStr = file[line];
                //Splis the line into tokens by spaces
                string[] currentLine = currentLineStr.Split();
                int currentTokenIndex = 0;
                //Go through each token on the line
                while (currentTokenIndex <= currentLine.Length - 1) {
                    //get the current token
                    string currentToken = currentLine[currentTokenIndex];
                    //add whatever the current token is to the Tokens list
                    if (currentToken == "echo") {
                        Tokens.Add("STATEMENT:echo");
                    
                        
                    } else if (currentToken == "message") {
                        Tokens.Add("TYPE:message");
                    } 
                    else if(currentToken == "'") {
                        //The string token is a bit more complicated but not much
                        Tokens.Add("'");
                        //This basically just gets the text between two ' and then gets that as a string
                        int start_index = currentLineStr.IndexOf("'")+1;
                        int end_index = currentLineStr.LastIndexOf("'");
                        int length = end_index-start_index;
                        string stringToken = currentLineStr.Substring(start_index,length);
                        Tokens.Add("STRING:" + stringToken);
                        
                        
                        
                    } else if (currentToken == ";") {
                        Tokens.Add("NEXT");
                        
                    } 
                    currentTokenIndex++;
                }

                line++;
            }
            return Tokens;
            
            
        }
    }

}
