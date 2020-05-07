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
        
            Console.WriteLine("Nav");
            if (type == "database") {
                Console.WriteLine("db");
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(path, parameter);
           
                pathTodb = folder;
                Console.WriteLine(pathTodb);
                dbname = parameter;
            } else if (type == "collection") {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(path, pathTodb, parameter);
                Directory.CreateDirectory(folder);
                pathToCollection = folder;
            } 
        }
        public static void create (string type, string parameter) {
            if (type == "collection") {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.SetCurrentDirectory(path);
                Directory.SetCurrentDirectory(dbname);
        
                Directory.CreateDirectory(parameter);
            } else if (type == "document") {
                string path = Path.Combine(pathToCollection, parameter);
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.SetCurrentDirectory(desktop);
    
                using (StreamWriter writer = File.CreateText(path)) ;                
            }
        }
    }

}
