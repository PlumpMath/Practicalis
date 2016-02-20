using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Practicalis
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var game = new GameWindow())
            {
                game.Load += (sender, e) =>
                {
                    //TODO: Load game settings, initialize textures and sounds
                    game.VSync = VSyncMode.On;
                };

                game.Resize += (sender, e) =>
                {
                    GL.Viewport(0, 0, game.Width, game.Height);
                };

                game.UpdateFrame += (sender, e) =>
                {
                    //TODO: Handle input and game logic
                    if (game.Keyboard[Key.Escape])
                        game.Exit();
                };

                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                    GL.MatrixMode(MatrixMode.Projection);
                    GL.LoadIdentity();
                    GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

                    GL.Begin(PrimitiveType.Triangles);

                    GL.Color3(Color.MintCream);
                    GL.Vertex2(-1.0f, 1.0f);
                    GL.Color3(Color.Magenta);
                    GL.Vertex2(0.0f, -1.0f);
                    GL.Color3(Color.MidnightBlue);
                    GL.Vertex2(1.0f, 1.0f);

                    GL.End();

                    game.SwapBuffers();
                };

                game.Run(60.0);
            }
        }
    }
}
