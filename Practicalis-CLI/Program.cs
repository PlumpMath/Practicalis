using System;
using Practicalis.Utilities;

namespace Practicalis
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runLoop = true;

            string command;
            string[] verbNoun;
            string[] commandInfo;

            if (args.Length > 0)
            {
                runLoop = false;

                command = args[0];
                verbNoun = command.Split('-');
                commandInfo = verbNoun[1].Split(':');
                
                runCommand(verbNoun, commandInfo);
            }

            while (runLoop)
            {
                Console.Write("Please enter a command: ");
                command = Console.ReadLine().ToString();
                verbNoun = command.Split('-');
                commandInfo = verbNoun[1].Split(' ');

                runCommand(verbNoun, commandInfo);
            }
        }

        private static void runCommand(string[] verbNoun, string[] commandInfo)
        {
            switch (verbNoun[0])
            {
                case "Binarize":
                    switch (commandInfo[0])
                    {
                        case "File":
                            if (FileUtils.writeBinary(commandInfo[1]))
                                Console.WriteLine(commandInfo[1] + ".prbin written successfully");
                            break;
                        case "Directory":
                            if (FileUtils.binarizeDirectory(commandInfo[1], false))
                                Console.WriteLine("Files in {0} binarized successfully!", commandInfo[1]);
                            break;
                        case "Resources":
                            if (FileUtils.binarizeDirectory("Resources", true))
                                Console.WriteLine("Successfully binarized all Resource files");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid command and try again.");
                    break;
            }
        }
    }
}
