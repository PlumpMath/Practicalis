using System;
using System.IO;

namespace Practicalis.Utilities
{
    class ResourceLoader
    {
        public static string loadShader(string fileName)
        {
            string shader = "";

            FileStream fs = new FileStream("Resources/Shaders/" + fileName + ".prbin", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            shader = br.ReadString();

            br.Close();
            fs.Close();

            return shader;
        }
    }
}
