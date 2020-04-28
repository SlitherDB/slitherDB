using System;
using System.IO;
using System.Text;
//get the slitherdb library (terminal uses the functions in the library)
using datastorageapplication;
namespace slitherTerminal
{

    public class slitherTerminal
    {
        
        public static void Main(string[] args)
        {
            //setup and prompt for a command
            Console.WriteLine("Slither DB terminal alpha");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            prompt("command");
        }
        public static void prompt(string type)
        {
            db slither = new db();
            
            //if the prompt type is command then parse for command
            if (type == "command")
            {
                //just get the prompt
                Console.WriteLine(">");
                var command = Console.ReadLine();
                /* 
                parse the command
                commands are layed out like this:
                command parameter 
                note: commands can have more than one parameter  
                */

                string[] parsedCommand = command.Split();
                if (parsedCommand[0] == "nav")
                {
                    if (parsedCommand[1] == "database")
                    {
                        var name = parsedCommand[2];
                        var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        var folder = Path.Combine(path, name);
                        Directory.CreateDirectory(folder);
                        db.pathTodb = folder;
                    }
                    if (parsedCommand[1] == "collection")
                    {
                        slither.EnterCollection(parsedCommand[2]);
                    }
                    if (parsedCommand[1] == "document")
                    {
                        Console.WriteLine("hehdiuewhdew");
                        slither.EnterDocument(parsedCommand[2]);
                    }
                }

                if (parsedCommand[0] == "delete")
                {
                    if (parsedCommand[1] == "database")
                    {
                        Console.WriteLine("Are you sure You want to delete this database Y/N? > ");
                        var answer = Console.ReadLine();
                        answer = answer.ToLower();
                        if (answer == "y")
                        {
                            slither.Delete(parsedCommand[2], parsedCommand[1]);

                        } 

                    }
                    if (parsedCommand[1] == "collection")
                    {
            
                            Console.WriteLine("Are you sure You want to delete this collection Y/N? > ");
                            var answer = Console.ReadLine();
                            answer = answer.ToLower();
                            if (answer == "y")
                            {
                                slither.Delete(parsedCommand[2], parsedCommand[1]);

                            }

                        
                    }
                }
   
                if (parsedCommand[0] == "create")
                {
                    //if the first parameter is database create a datase
                    if (parsedCommand[1] == "database")
                    {
                        slither.CreateDatabase(parsedCommand[2], "terminal");
         
                    }
                    if (parsedCommand[1] == "collection")
                    {
                        string path = db.pathTodb;
                        slither.CreateCollection(path, parsedCommand[2]);
                    }
                    if (parsedCommand[1] == "document")
                    {
                        slither.CreateDocument(db.pathToCollection, parsedCommand[2]);
                    }
                    if (parsedCommand[1] == "field")
                    {
                        Console.WriteLine("creating field");
                        slither.AddData(db.pathToDocument, parsedCommand[2]);
                    }
                }
                prompt("command");
            }
        }
    }
}
