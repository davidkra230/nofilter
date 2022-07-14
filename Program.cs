using System;
using System.IO;

namespace nofilter
{
    class Program
    {
        static void Main(string[] args)
        {
            //take ownership of the C:\Program Files\WindowsApps\Microsoft.MinecraftUWP_1.19.202.0_x64__8wekyb3d8bbwe\data folder (folder is dynamic?)
            //then delete profanity_filter.wlist
            
            //set dynamic vars
            const string programName = "Minecraft Bedrock Edition Language Filter Remover v2.0.1 For Minecraft Bedrock Edition 1.19.10";
            const string filterLocation = "C:\\Program Files\\WindowsApps\\Microsoft.MinecraftUWP_1.19.1003.0_x64__8wekyb3d8bbwe\\data\\profanity_filter.wlist";
            //end of section
            
            Console.WriteLine(programName);
            Console.Title = programName;
            if (!File.Exists(filterLocation))
            {            
                Console.WriteLine("No profanity_filter.wlist found\n[Any key to exit]");
                Console.Title = "Aborted.";
                Console.ReadKey();
                return;
            }
            //check if the user actually wants to delete the filter by asking them if they want to continue if they say y or enter then delete the file
            Console.Write("Are you sure you want to delete the profanity filter? [Y/n]");
            var input = Console.ReadKey();
            Console.WriteLine();
            bool run = input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Y ? true : false;
            if (!run)
            {
                Console.WriteLine("Aborted.");
                Console.Title = "Aborted.";
                Console.ReadKey();
                return;
            }
            

            Console.WriteLine("Taking Ownership..");
            Console.Title = "Owning..";
            //take ownership of the file]
            File.SetAttributes(filterLocation, FileAttributes.Normal);
            Console.WriteLine("Done.");
            Console.WriteLine("Deleting profanity_filter.wlist");
            Console.Title = "Deleting..";
            //delete profanity_filter.wlist
            File.Delete(filterLocation);
            Console.WriteLine("Done.");
            Console.WriteLine("Finished.\n[Any key to exit]");
            Console.Title = "Finished.";
            Console.ReadKey();
        }
    }
}
