using System;
using Pencil.Gaming.Graphics;
using Practicalis.Utilities;

namespace Practicalis.Rendering
{
    class Shader
    {
        private uint program;

        public Shader()
        {
            program = GL.CreateProgram();

            if (program == 0)
            {
                Console.WriteLine("Failed to create shader, could not find valid memory address to assign to\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void addProgram(string text, ShaderType type)
        {
            uint shader = GL.CreateShader(type);

            if (shader == 0)
            {
                Console.WriteLine("Failed to create shader, could not find valid memory address to assign to\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            GL.ShaderSource(shader, text);
            GL.CompileShader(shader);

            int compiled;
            GL.GetShader(shader, ShaderParameter.CompileStatus, out compiled);

            if (compiled == 0)
            {
                Console.WriteLine(GL.GetShaderInfoLog((int)shader) + "\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            GL.AttachShader(program, shader);
        }

        public void compileShader()
        {
            GL.LinkProgram(program);

            int linked;
            GL.GetProgram(program, ProgramParameter.LinkStatus, out linked);

            if (linked == 0)
            {
                Console.WriteLine(GL.GetProgramInfoLog((int)program) + "\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            int validated;
            GL.GetProgram(program, ProgramParameter.ValidateStatus, out validated);

            if (validated == 0)
            {
                Console.WriteLine(GL.GetProgramInfoLog((int)program) + "\nPress any key to continue...");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }

        public void bind()
        {
            GL.UseProgram(program);
        }

        public void addVertexShader(string text)
        {
            addProgram(text, ShaderType.VertexShader);
        }

        public void addFragmentShader(string text)
        {
            addProgram(text, ShaderType.FragmentShader);
        }

        public void addGeometryShader(string text)
        {
            addProgram(text, ShaderType.GeometryShader);
        }
    }
}
