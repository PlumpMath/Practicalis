using System;
using Pencil.Gaming.Graphics;
using Pencil.Gaming.MathUtils;

namespace Practicalis.Rendering
{
    class Mesh
    {
        private int size;
        private int vbo;

        public Mesh()
        {
            GL.GenBuffers(1, out vbo);
        }

        public void addVertices(Vertex[] vertices)
        {
            size = vertices.Length * Vector3.SizeInBytes;
            Vector3[] vertsData = new Vector3[vertices.Length];

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            for (int i = 0; i < vertices.Length; i++)
                vertsData[i] = vertices[i].Position;

            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)size, vertsData, BufferUsageHint.StaticDraw);
        }

        public void draw()
        {
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false,/* Vertices are 3 elements * 4 bytes per float */ 3 * 4, 0);
            
            GL.DrawArrays(BeginMode.Triangles, 0, size);
            
            GL.DisableVertexAttribArray(0);
        }
    }
}