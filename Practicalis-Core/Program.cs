using System;
using Pencil.Gaming;
using Pencil.Gaming.Graphics;
using Pencil.Gaming.MathUtils;
using Practicalis.Rendering;
using Practicalis.Utilities;

namespace Practicalis
{
    class Program
    {
        static Window gameWindow = new Window();
        static Mesh mesh;
        static Shader shader;

        static void Main(string[] args)
        {
            ///
            /// NOTE: All GL functions must come after the window and context are created
            ///
            gameWindow.createWindow();
            if (gameWindow.Equals(null))
            {
                Console.WriteLine("ERROR: Could not start game window\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            Console.WriteLine("Using OpenGL version {0}", gameWindow.getGLVersion());
            gameWindow.initGraphics();

            mesh = new Mesh();
            shader = new Shader();

            Vertex[] data = new Vertex[3];

            data[0].Position = new Vector3(-1, -1, 0);
            data[1].Position = new Vector3(0, 1, 0);
            data[2].Position = new Vector3(1, -1, 0);

            mesh.addVertices(data);

            shader.addVertexShader(ResourceLoader.loadShader("example.vert"));
            shader.addFragmentShader(ResourceLoader.loadShader("example.frag"));
            shader.compileShader();

            while (!Glfw.WindowShouldClose(gameWindow.window))
            {
                Glfw.PollEvents();

                if (Glfw.GetKey(gameWindow.window, Key.Escape))
                    Glfw.SetWindowShouldClose(gameWindow.window, true);

                render();

                Glfw.SwapBuffers(gameWindow.window);
            }

            Glfw.Terminate();
        }

        static void render()
        {
            gameWindow.clearScreen();

            shader.bind();
            mesh.draw();
        }
    }
}
