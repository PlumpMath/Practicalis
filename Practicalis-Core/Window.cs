using System;
using Pencil.Gaming;
using Pencil.Gaming.Graphics;

namespace Practicalis
{
    class Window
    {
        private static readonly int WIDTH = 800;
        private static readonly int HEIGHT = 600;
        private static readonly string TITLE = "Practicalis";

        static GlfwWindowPtr window;

        public static GlfwWindowPtr createWindow()
        {
            if (!Glfw.Init())
            {
                Console.WriteLine("ERROR: Could not initialize GLFW");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            window = Glfw.CreateWindow(WIDTH, HEIGHT, TITLE, GlfwMonitorPtr.Null, GlfwWindowPtr.Null);

            Glfw.MakeContextCurrent(window);

            return window;
        }
    }
}
