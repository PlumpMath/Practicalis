using System;
using System.Runtime.InteropServices;
using Pencil.Gaming.MathUtils;

namespace Practicalis.Rendering
{
    [StructLayout(LayoutKind.Sequential)]
    struct Vertex
    {
        public Vector2 TexCoord;
        public Vector3 Normal;
        public Vector3 Position;
    }
}
