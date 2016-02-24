using System;
using System.IO;

namespace Practicalis.Utilities
{
    class ResourceLoader
    {
        public static string loadShader(string fileName)
        {
            string shader = "";

            using (StreamReader sr = File.OpenText("./Resources/Shaders/" + fileName))
            {
                try
                {
                    shader = sr.ReadToEnd();
                }
                catch (IOException e)
                {
                    Console.WriteLine("ERROR: Could not load shader\n{0}", e.StackTrace);
                }
            }

            return shader;
        }
    }
}
