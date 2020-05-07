using System;
using System.IO;
using System.Collections.Generic;
using Outputlib;
namespace evaluator
{
    public class Evaluator
    {

       


        public static void evaluate(List<string> Program)
        {
            string statement = "null";
            string type = "null";
            string param = "null";
            outputlib output = new outputlib();
            int tokenIndex = 0;
            string token = Program[0];
            while (tokenIndex != Program.Count) {
        
                token = Program[tokenIndex];
                if (token == "echo") {
                    statement = "echo";
                } else if (token == "message") {
                    type = "message";
                } else if (token == "'") {
               
                    param = Program[tokenIndex + 1];
                } else if (token == "nav") {
                    statement = "nav";
                } else if (token == "database") {
                    type = "database";
                }  else if (token == "create") {
                    statement = "create";
                } else if (token == "collection") {
                    type = "collection";
                } else if (token == "document") {
                    type = "document";
                } else if (token == "field") {
                    
                    type = "field";
                }
                 else if (token == "NEXT") {
                 
                    if (statement == "echo") {
                        
                        outputlib.echo(type, param);
                    }
                    else if (statement == "nav") {
                        outputlib.nav(type, param);
                    }
                    else if (statement == "create") {
          
                        outputlib.create(type, param);
                    }
                }
                tokenIndex++;
            }
            
            
            
        }
    }

}
