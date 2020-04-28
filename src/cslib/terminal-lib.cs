//libraries
using System;
using System.IO;
using System.Text;
namespace datastorageapplication
{

    class db
    {
        //the path to the database or collection you are currently in
        public static string pathTodb = "NO DATABASE HAS BEEN NAVIGATED INTO";
        public static string pathToCollection = "NO COLLECTION HAS BEEN NAVIGATED INTO";
        public static string pathToDocument = "NO DOCUMENT HAS BEEN NAVIGATED INTO";
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
        public void AddData(string document, string data)
        {
            //get the path to the desktop folder
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //create the fill directory of the document example: desktop/db/document
            var folder = Path.Combine(pathTodb, pathToCollection, document);
            File.AppendAllText(folder, data + Environment.NewLine);




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
    }
}
