using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFileSystem
{
    public static class Commands
    {
        public static void Clear()
        {
            Console.Clear();
        }
        public static void Quit()
        {
            Environment.Exit(0);
        }

        public static void Help(string com = "ok")
        {
            bool fund = false;
            string[] command = { "cd", "help", "dir", "quit", "copy", "cls", "del", "md", "rd", "rename", "type", "import", "export" };
            foreach (string i in command)
            {
                if (i != com.ToLower())
                {
                    continue;
                }
                fund = true;
            }
            if (com == "ok")
            {
                Console.WriteLine("help   -------> Provides Help information for commands.");
                Console.WriteLine("cd     -------> Change the current default directory to .");
                Console.WriteLine("cls    -------> Clear the screen.");
                Console.WriteLine("dir    -------> List the contents of directory .");
                Console.WriteLine("quit   -------> Quit the shell.");
                Console.WriteLine("copy   -------> Copies one or more files to another location");
                Console.WriteLine("del    -------> Deletes one or more files.");
                Console.WriteLine("md     -------> Creates a directory.");
                Console.WriteLine("rd     -------> Removes a directory.");
                Console.WriteLine("rename -------> Renames a file.");
                Console.WriteLine("type   -------> Displays the contents of a text file.");
                Console.WriteLine("import -------> import text file(s) from your computer");
                Console.WriteLine("export -------> export text file(s) to your computer");
            }
            else if (com != "ok" && fund)
            {
                switch (com)
                {
                    case "cd":
                        Console.WriteLine("Change the current default directory to the directory given in the argument.");
                        break;
                    case "cls":
                        Console.WriteLine("Clear the screen.");
                        break;
                    case "dir":
                        Console.WriteLine("List the contents of directory given in the argument.");
                        break;
                    case "quit":
                        Console.WriteLine("Quit the shell.");
                        break;
                    case "copy":
                        Console.WriteLine("Copies one or more files to another location.");

                        break;
                    case "del":
                        Console.WriteLine("Delete file.");

                        break;
                    case "help":
                        Console.WriteLine("Provides Help information for commands.");

                        break;
                    case "md":
                        Console.WriteLine("Creates directory.");

                        break;
                    case "rd":
                        Console.WriteLine("Removes  directory.");

                        break;
                    case "rename":
                        Console.WriteLine("Rename file.");

                        break;
                    case "type":
                        Console.WriteLine("Displays the contents of a text file.");

                        break;
                    case "import":
                        Console.WriteLine("import text file(s) from your computer ");
                        break;
                    case "export":
                        Console.WriteLine("export text file(s) to your computer ");
                        break;
                }
            }
            else if (fund == false)
            {
                Console.WriteLine("Error: " + com + " This command is not supported by the project.");
            }
        }
        public static void CreateDirectory(string name=" ")
        {
            if (name == " ")
            {
                Console.WriteLine("ERROR!!! ");
            }
            else
            {
                if (OS.current.SearchDirectory(name) == -1)
                {
                    if (FAT.GetAvilableCluster() != -1)
                    {
                        Directory_Entry d = new Directory_Entry(name, 0x10, 0);
                        OS.current.file_dir.Add(d);
                        OS.current.WriteDirectory();
                        if (OS.current.parent != null)
                        {
                            OS.current.parent.UpdateContent(OS.current.GetDirectoryEntry());
                            OS.current.parent.WriteDirectory();
                        }
                        FAT.WriteFat();
                    }
                    else
                    {
                        Console.WriteLine("ERROR!!! :  the File is full.");
                    }
                }
                else
                {
                    Console.WriteLine("ERROR!!! : this directory \" " + name + " \" is already exists.");
                }
            }
        }
    }
}
