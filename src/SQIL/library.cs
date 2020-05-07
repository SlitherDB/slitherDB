using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Outputlib
{
    public class outputlib
    {
        public static string pathTodb = "null";
        public static string pathToCollection = "NO COLLECTION HAS BEEN NAVIGATED INTO";
        public static string pathToDocument = "NO  HAS BEEN NAVIGATED INTO";
        static string dbname = "null";


        public static void echo(string type, string parmeter)
        {
            
            if (type == "message") {
                Console.WriteLine(parmeter);
            }

        }
        public static void nav(string type, string parameter) {
        
           
            if (type == "database") {
         
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(path, parameter);
           
                pathTodb = folder;
                
                dbname = parameter;
            } else if (type == "collection") {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(path, pathTodb, parameter);
                Directory.CreateDirectory(folder);
                pathToCollection = folder;
            } else if (type == "document") {
  
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(pathToCollection, parameter);
                pathToDocument = folder;
            }
        }
        public static void create (string type, string parameter) {

            if (type == "collection") {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.SetCurrentDirectory(path);
                Directory.SetCurrentDirectory(dbname);
        
                Directory.CreateDirectory(parameter);
            } 
            if (type == "document") {
                string path = Path.Combine(pathToCollection, parameter);
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.SetCurrentDirectory(desktop);
    
                using (StreamWriter writer = File.CreateText(path)) ;                
            } 
            if (type == "field") {
                
                string[] DataStr = parameter.Split(':');
                
                if (DataStr.Length < 2)
                {
                    Console.WriteLine("Error: Field must have a value!");
                }
                else
                {
                    //get the path to the desktop folder
                    var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //create the fill directory of the document example: desktop/db/document
                    var folder = Path.Combine(pathTodb, pathToCollection, pathToDocument);
                    File.AppendAllText(folder, parameter + Environment.NewLine);

                }
            }
        }
    }

}
