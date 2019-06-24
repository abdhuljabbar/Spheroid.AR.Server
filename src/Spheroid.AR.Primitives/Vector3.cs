using System.Diagnostics;

namespace Spheroid.AR
{
    [DebuggerDisplay("X={X}, Y={Y}, Z={Z}")]
    public readonly struct Vector3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
