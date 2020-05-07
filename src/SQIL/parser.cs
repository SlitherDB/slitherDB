using System;
using System.IO;
using System.Collections.Generic;
namespace parser
{
    public class Parser
    {

       public static List<string> Parse(List<string> Tokens) {
            List<string> parsedTokens = new List<string>();
            
            int currentToken = 0;
            while (currentToken <= Tokens.Count - 1) {
                
                string currentTokenStr = Tokens[currentToken];
                string[] currentTokenArr = currentTokenStr.Split(",");
                if (currentTokenArr[0] == "STATEMENT") {

                    parsedTokens.Add(currentTokenArr[1]);
                } else if (currentTokenArr[0] == "TYPE") {
                  parsedTokens.Add(currentTokenArr[1]);

               } else if (currentTokenArr[0] == "'") {
                   parsedTokens.Add(currentTokenArr[0]);
               }
                 else if (currentTokenArr[0] == "STRING") {
                    
               
                    parsedTokens.Add(currentTokenArr[1]);
                } else if (currentTokenArr[0] == "NEXT") {
                    
                    parsedTokens.Add("NEXT");
                }
                currentToken++;
            }
            return parsedTokens;

       }
       

    
    }

}
