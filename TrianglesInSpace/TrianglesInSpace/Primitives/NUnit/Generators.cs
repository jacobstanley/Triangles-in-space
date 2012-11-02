using System;
using QuickCheck;
using QuickCheck.Random;

namespace TrianglesInSpace.Primitives.NUnit
{
    public class AngleGenerator : IGenerator<Angle>
    {
        public Angle Arbitrary(IRandom gen, int size)
        {
            bool positive = gen.Bool();
            double angle = gen.Double(size, 0, Math.PI);
            return new Angle(positive ? angle : -angle);
        }
    }

    public class VectorGenerator : IGenerator<Vector>
    {
        public Vector Arbitrary(IRandom gen, int size)
        {
            return new Vector(gen.Double(size), gen.Double(size));
        }
    }
}
