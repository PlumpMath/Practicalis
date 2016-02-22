using System;
using Pencil.Gaming;
using Pencil.Gaming.Graphics;

namespace Practicalis
{
    class Program
    {
        static void Main(string[] args)
        {
            GlfwWindowPtr window = Window.createWindow();

            while (!Glfw.WindowShouldClose(window))
            {
                Glfw.PollEvents();

                if (Glfw.GetKey(window, Key.Escape))
                    Glfw.SetWindowShouldClose(window, true);

                GL.ClearColor(Color4.Blue);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                //TODO: Render stuff here
                //render();

                Glfw.SwapBuffers(window);
            }

            Glfw.Terminate();
        }
    }
}
