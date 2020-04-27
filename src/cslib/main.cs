using System;
using System.IO;
using System.Text;
namespace datastorageapplication
{

    class db
    {
        public static string pathTodb = "NO DATABASE HAS BEEN NAVIGATED INTO";
        public void CreateDatabase(string name, string calledfrom)
        {

            string path = name + ".txt";

            // The line below will create a text file, my_file.txt, in 
            // the Text_Files folder in D:\ drive.
            // The CreateText method that returns a StreamWriter object

             if (calledfrom == "terminal")
            {
                Console.WriteLine("Creating database");
            }
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folder = Path.Combine(path, name);
                Directory.CreateDirectory(folder);
                pathTodb = folder;



        }
        public void EnterDatabase(string name)
        {
    
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var folder = Path.Combine(path, name);
            Directory.CreateDirectory(folder);
            pathTodb = folder;
        }
        public void CreateCollection(string database, string collectionName)
        {
            string path = Path.Combine(pathTodb, collectionName);
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Directory.SetCurrentDirectory(pathTodb);
            using (StreamWriter writer = File.CreateText(collectionName)) ;
        
        }

    }
}
