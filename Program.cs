using System;
using System.IO;

namespace nofilter
{
    class Program
    {
        static void Main(string[] args)
        {
            // take ownership of the C:\Program Files\WindowsApps\Microsoft.MinecraftUWP_1.19.202.0_x64__8wekyb3d8bbwe\data folder (folder is dynamic?)
            // then delete profanity_filter.wlist
            
            // set dynamic vars
            const string programName = "Minecraft Bedrock Edition Language Filter Remover v2.0.1 For Minecraft Bedrock Edition (Universal)";
            //(better?) const string filterLocation = "C:\\Program Files\\WindowsApps\\Microsoft.MinecraftUWP_1.19.1003.0_x64__8wekyb3d8bbwe\\data\\profanity_filter.wlist";
            
            // the following line is meant to be "prep" for custom install directorys.
            var customInstallDir = "C:\\Program Files\\WindowsApps\\";
            
            var filterLocation = Directory.GetDirectories(customInstallDir, "Microsoft.MinecraftUWP_*", SearchOption.TopDirectoryOnly)[0] + "\\data\\profanity_filter.wlist";
            // Console.WriteLine(filterLocation); //as a temp test
            // end of section
            
            Console.WriteLine(programName);
            Console.Title = programName;
            if (!File.Exists(filterLocation))
            {
                Console.Write("No profanity_filter.wlist found\nAre the Minecraft files in a custom install directory? [Y/n]");
                var input = Console.ReadKey();
                if (!(input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Y ? true : false)) {
                    Console.Title = "Aborted.\n[Any key to exit]";
                    Console.ReadKey();
                    return;
                }
                Console.Clear();
                Console.Write("Where are the Minecraft files?: ");
                customInstallDir = Console.ReadLine();
                Main();
            }
            // check if the user actually wants to delete the filter by asking them if they want to continue if they say y or enter then delete the file
            Console.Write("Are you sure you want to delete the profanity filter? [Y/n]");
            var input = Console.ReadKey();
            Console.WriteLine();
            bool run = input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Y ? true : false;
            if (!run)
            {
                Console.WriteLine("Aborted.\n[Any key to exit]");
                Console.Title = "Aborted.";
                Console.ReadKey();
                return;
            }
            

            Console.WriteLine("Taking Ownership..");
            Console.Title = "Owning..";
            // take ownership of the file]
            File.SetAttributes(filterLocation, FileAttributes.Normal);
            Console.WriteLine("Done.");
            Console.WriteLine("Deleting profanity_filter.wlist");
            Console.Title = "Deleting..";
            // delete profanity_filter.wlist
            File.Delete(filterLocation);
            Console.WriteLine("Done.");
            Console.WriteLine("Finished.\n[Any key to exit]");
            Console.Title = "Finished.";
            Console.ReadKey();
        }
    }
}
