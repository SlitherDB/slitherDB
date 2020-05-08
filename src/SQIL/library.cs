

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
        public static Dictionary<string, string> variables = new Dictionary<string, string>();  
        public static string pathTodb = "null";
        public static string pathToCollection = "NO COLLECTION HAS BEEN NAVIGATED INTO";
        public static string pathToDocument = "NO  HAS BEEN NAVIGATED INTO";
        static string dbname = "null";


        public static void echo(string type, string parmeter)
        {
   
            
            if (type == "message") {
                Console.WriteLine(parmeter);
            } else if (type == "queryStr") {
                
                          string[] documents = Directory.GetFiles(pathToCollection);
            List<string> texts = new List<string>();

            for (int i = 0; i < documents.Length; i++)
            {
            

                string path = Path.Combine(pathToCollection, documents[i]);
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.SetCurrentDirectory(desktop);
                string text = System.IO.File.ReadAllText(path);
                
                if (documents[i] != "/Users/home/Desktop/db/data/.DS_Store")
                {

                    if (text.Contains(parmeter))
                    {
                        texts.Add(text);
                        if (i == documents.Length - 1)
                        {
                            if (texts.Count == 0)
                            {
                                
                                texts.Add("null");
                            }
                            if (texts[texts.Count - 1] == "null")
                            {
                                
                            }
                            else
                            {
                                Console.WriteLine(string.Join(Environment.NewLine + Environment.NewLine, texts.ToArray()));
                            }
                        }
                    }
                

            }

        }
        } else if (type == "default") {
            
            Console.WriteLine(variables[parmeter]);
        } else if (type == "query") {
            Console.WriteLine(variables[parmeter]);
        }
        }
        public static void var(string type, string parameter) {
            
            if (type == "default") {
                
                string[] varsplit = parameter.Split('=');
                string name = varsplit[0];
                string value = varsplit[1];
                variables.Add(name, value);
                
            } else if (type == "query") {
                
                string[] varsplit = parameter.Split('=');
                string name = varsplit[0];
                string value = varsplit[1];
                string[] documents = Directory.GetFiles(pathToCollection);
                List<string> texts = new List<string>();

                for (int i = 0; i < documents.Length; i++)
                {
                

                    string path = Path.Combine(pathToCollection, documents[i]);
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    Directory.SetCurrentDirectory(desktop);
                    string text = System.IO.File.ReadAllText(path);
                    
                    if (documents[i] != "/Users/home/Desktop/db/data/.DS_Store")
                    {

                        if (text.Contains(value))
                        {
                            texts.Add(text);
                            if (i == documents.Length - 1)
                            {
                                if (texts.Count == 0)
                                {
                                    
                                    texts.Add("null");
                                }
                             
                                    
                                    variables.Add(name, string.Join(Environment.NewLine + Environment.NewLine, texts.ToArray()));
                                    
                                
                            }
                        }
                    

                }

            }
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
