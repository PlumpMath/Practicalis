using System;
using Pencil.Gaming;
using Pencil.Gaming.Graphics;

namespace Practicalis
{
    class Window
    {
        private readonly int WIDTH = 800;
        private readonly int HEIGHT = 600;
        private readonly string TITLE = "Practicalis";

        public GlfwWindowPtr window;

        public int INSTANCE;

        public Window() { INSTANCE++; }

        public void createWindow()
        {
            if (!Glfw.Init())
            {
                Console.WriteLine("ERROR: Could not initialize GLFW");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Opening GLFW window instance #{0}", INSTANCE);
                window = Glfw.CreateWindow(WIDTH, HEIGHT, TITLE, GlfwMonitorPtr.Null, GlfwWindowPtr.Null);
                Glfw.MakeContextCurrent(window);

                Glfw.SetWindowSizeCallback(window, (GlfwWindowPtr window, int width, int height) =>
                {
                    GL.Viewport(0, 0, width, height);
                });
            }
        }

        public string getGLVersion()
        {
            return GL.GetString(StringName.Version);
        }

        public void initGraphics()
        {
            GL.ClearColor(Color4.Black);

            GL.Enable(EnableCap.VertexArray);

            GL.FrontFace(FrontFaceDirection.Cw);
            GL.CullFace(CullFaceMode.Back);
            GL.Enable(EnableCap.CullFace);
            GL.Enable(EnableCap.DepthTest);

            GL.Enable(EnableCap.FramebufferSrgb);
        }

        public void clearScreen()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }
    }
}
