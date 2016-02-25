using System;
using Practicalis.Utilities;

namespace Practicalis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter a command: ");
                string command = Console.ReadLine().ToString();
                string[] verbnoun = command.Split('-');
                string[] commandInfo = verbnoun[1].Split(' ');

                switch (verbnoun[0])
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
}
