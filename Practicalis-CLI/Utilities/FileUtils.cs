using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Practicalis.Utilities
{
    class FileUtils
    {
        public static string loadTextFile(string fileName)
        {
            string file = "";

            using (StreamReader sr = File.OpenText(fileName))
            {
                try
                {
                    file = sr.ReadToEnd();
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: Could not load file!\n{0}", e.StackTrace);
                }
            }

            return file;
        }

        public static bool binarizeDirectory(string directory, bool subDirectories)
        {
            string[] files;

            if (subDirectories)
                files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            else
                files = Directory.GetFiles(directory, "*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                if (Regex.IsMatch(file, @"prbin"))
                    Console.WriteLine("Skipping already binarized file {0}", file);
                else
                {
                    Console.WriteLine("Binarizing {0}", file);

                    writeBinary(file);
                }
            }
            return true;
        }

        public static bool writeBinary(string fileName, string data = "")
        {
            FileStream fs = new FileStream(fileName + ".prbin", FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);

            if (data != String.Empty)
            {
                try
                {
                    w.Write(data);
                    w.Close();
                    fs.Close();

                    return true;
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: Could not write to file!\n{0}", e.StackTrace);

                    return false;
                }
            }
            else
            {
                try
                {
                    w.Write(loadTextFile(fileName));
                    w.Close();
                    fs.Close();

                    return true;
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: Could not write to file!\n{0}", e.StackTrace);

                    return false;
                }
            }
        }
    }
}
