//libraries
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace datastorageapplication
{

    class db
    {
        
        //the path to the database or collection you are currently in
        public static string pathTodb = "NO DATABASE HAS BEEN NAVIGATED INTO";
        public static string pathToCollection = "NO COLLECTION HAS BEEN NAVIGATED INTO";
        public static string pathToDocument = "NO  HAS BEEN NAVIGATED INTO";
        //create a database
        public void CreateDatabase(string name, string calledfrom)
        {

            string path;


            //if the function is being called from the terminal then write a message for the terminal user
            if (calledfrom == "terminal")
            {
                Console.WriteLine("Creating database");
            }
            //get the path to the desktop folder
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //create the fill directory of the database example: desktop/database
            var folder = Path.Combine(path, name);
            //and finaly create the directory and set the path to the DB to the folders directory
                Directory.CreateDirectory(folder);
                pathTodb = folder;



        }
        public Object Document(string name)
        {
            Dictionary<string, string> Fields = new Dictionary<string, string>();
            return Fields;

        }
        public void AddData(string document, string data)
        {
            string[] DataStr = data.Split('=');
            if (DataStr.Length < 2)
            {
                Console.WriteLine("Error: Field must have a value!");
            }
            else
            {
                //get the path to the desktop folder
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                //create the fill directory of the document example: desktop/db/document
                var folder = Path.Combine(pathTodb, pathToCollection, document);
                File.AppendAllText(folder, data + Environment.NewLine);

            }


        }
        //these three things are the same as the nav command for the terminal
        public void EnterDatabase(string name)
        {
    
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var folder = Path.Combine(path, pathToCollection, name);
            Directory.CreateDirectory(folder);
            pathTodb = folder;
        }
        public void EnterDocument(string name)

        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var folder = Path.Combine(pathToCollection, name);
            pathToDocument = folder;
        }
        public void EnterCollection(string name)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var folder = Path.Combine(path, pathTodb, name);
            Directory.CreateDirectory(folder);
            pathToCollection = folder;

        }
        //creates a collection in a database
        public void CreateCollection(string database, string collectionName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.SetCurrentDirectory(path);
            Directory.SetCurrentDirectory(database);
       
            Directory.CreateDirectory(collectionName);
         

        }
        //creates a document in a collection
        public void CreateDocument(string collection, string documentName)
        {
            string path = Path.Combine(pathToCollection, documentName);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.SetCurrentDirectory(desktop);
  
            using (StreamWriter writer = File.CreateText(path)) ;
        }
        public string FindDocument(string document)
        {
            string path = Path.Combine(pathToCollection, document);
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.SetCurrentDirectory(desktop);
            string text = System.IO.File.ReadAllText(path);
            Console.WriteLine(text);
            return text;
        }
        //can delete anything
     
        public void Delete(string name, string type)
        {
            if (type == "database")
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
      
                Directory.Delete(Path.Combine(path, name));
            }
            if (type == "collection")
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.Delete(Path.Combine(pathTodb, name));
            }
           
        }
        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        public void ClearDocument()
        {
            System.IO.File.WriteAllText(pathToDocument, string.Empty);
        }
        public int ChangeField(string fieldName) 
        {
            string[] fieldNameArr = fieldName.Split(':');
            int fieldLine = 0;
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.SetCurrentDirectory(path);
            System.IO.StreamReader file = new System.IO.StreamReader(pathToDocument);
            int x = 1;
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string name = fieldNameArr[0];
                Console.WriteLine(name);
                if (line.Substring(0, name.Length) == name)
                {

                    fieldLine = x;
              
                    string[] arrLine = File.ReadAllLines(pathToDocument);
                    try
                    {
                        //  Block of code to try
                        arrLine[fieldLine - 1] = fieldName;
                        file.Dispose();
                        File.WriteAllLines(pathToDocument, arrLine);
                        file = new System.IO.StreamReader(pathToDocument);
                    }
                    catch (Exception e)
                    {
                        //  Block of code to handle errors
                        return 0;
                    }
                   



                    
                    

                    
                    
                }
                x++;
            }
            return 0;
        }
        public string Query(string query)
        {
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

                    if (text.Contains(query))
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
                                return "null";
                            }
                            else
                            {
                                return string.Join(Environment.NewLine + Environment.NewLine, texts.ToArray());
                            }
                        }

                    }
          
                    
                }
                
            
                
                
            }
            return "Query:" + query;

        }
    }
}
