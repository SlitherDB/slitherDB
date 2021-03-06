using System;
using System.IO;
using System.Collections.Generic;
namespace lexer
{
    public class Lexer
    {

       
        static int line = 0;
        static List<string> Tokens = new List<string>();

        public static List<string> Lex(string[] file)
        {
                    
            //Get the SQIL file

            
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
                        Tokens.Add("STATEMENT,echo");
                    
                        
                    } else if (currentToken == "message") {
                        Tokens.Add("TYPE,message");
                    } 
                    else if(currentToken == "'") {
                  
                        //The string token is a bit more complicated but not much
                        Tokens.Add("'");
                        //This basically just gets the text between two ' and then gets that as a string
                        int start_index = currentLineStr.IndexOf("'")+1;
                        int end_index = currentLineStr.LastIndexOf("'");
                        int length = end_index-start_index;
                        string stringToken = currentLineStr.Substring(start_index,length);
                        Tokens.Add("STRING," + stringToken);
                        
                        
                        
                    } else if (currentToken == "nav") {
                        Tokens.Add("STATEMENT,nav");

                    } else if (currentToken == "database") {
                        Tokens.Add("TYPE,database");
                    }  else if (currentToken == "create") {
                        Tokens.Add("STATEMENT,create");
                    } else if (currentToken == "collection") {
                        Tokens.Add("TYPE,collection");
                    } else if (currentToken == "document") {
                        Tokens.Add("TYPE,document");
                    } else if (currentToken == "field") {
                    
                        Tokens.Add("TYPE,field");
                    } else if (currentToken == "query") {
                
                        Tokens.Add("TYPE,query");
                    } else if (currentToken == "var") {
                       
                        Tokens.Add("STATEMENT,var");
                    } else if (currentToken == "default") {
                        Tokens.Add("TYPE,default");
                    }
                    else if (currentToken == ";") {
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
