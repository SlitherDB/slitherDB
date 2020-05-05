using System;
using System.IO;
using System.Collections.Generic;
namespace Outputlib
{
    public class outputlib
    {

       


        public static void echo(string type, string parmeter)
        {
            
            if (type == "message") {
                Console.WriteLine(parmeter);
            }
        }
    }

}
