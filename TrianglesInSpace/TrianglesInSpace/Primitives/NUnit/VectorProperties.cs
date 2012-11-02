using QuickCheck;
using QuickCheck.NUnit;

// ReSharper disable InconsistentNaming

namespace TrianglesInSpace.Primitives.NUnit
{
    public class VectorProperties : TestProperties
    {
        static VectorProperties()
        {
            Quick.Register(typeof(VectorGenerator).Assembly);
        }

        private void AssertEqual(object x, object y)
        {
            Diff(x, y).WithEpsilon(1e-6).AssertEmpty();
        }

        public void Normalised_Vector_has_length_of_1(Vector a)
        {
            var x = a.Normalise().Length;
            var y = 1.0;

            AssertEqual(x, y);
        }

        public void Addition_is_commutative(Vector a, Vector b)
        {
            var x = a + b;
            var y = b + a;

            AssertEqual(x, y);
        }

        public void Addition_is_associative(Vector a, Vector b, Vector c)
        {
            var x = a + (b + c);
            var y = (a + b) + c;

            AssertEqual(x, y);
        }

        public void Scalar_multiplication_distributes_over_vector_addition(double lambda, Vector a, Vector b)
        {
            var x = lambda * (a + b);
            var y = lambda * a + lambda * b;

            AssertEqual(x, y);
        }

        public void Zero_is_the_addition_identity(Vector a)
        {
            var x = Vector.Zero + a;
            var y = a;

            AssertEqual(x, y);
        }

        public void Vector_minus_itself_is_zero(Vector a)
        {
            var x = a - a;
            var y = Vector.Zero;

            AssertEqual(x, y);
        }

        public void Subtraction_is_same_as_addition_of_negative(Vector a, Vector b)
        {
            var x = a - b;
            var y = a + (-b);

            AssertEqual(x, y);
        }

        public void Multiplication_by_scalar_is_commutative(double a, Vector b)
        {
            var x = a * b;
            var y = b * a;

            AssertEqual(x, y);
        }

        public void Division_is_same_as_multiplication_by_reciprocal(Vector a, double b)
        {
            var x = a / b;
            var y = a * (1 / b);

            AssertEqual(x, y);
        }

        public void Dot_product_is_commutative(Vector a, Vector b)
        {
            var x = Vector.Dot(a, b);
            var y = Vector.Dot(b, a);

            AssertEqual(x, y);
        }

        public void Dot_product_distributes_over_scalar_multiplication(double lambda, Vector a, Vector b)
        {
            var x = Vector.Dot(a, lambda * b);
            var y = Vector.Dot(a * lambda, b);
            var z = lambda * Vector.Dot(a, b);

            AssertEqual(x, y);
            AssertEqual(x, z);
            AssertEqual(y, z);
        }

        public void Dot_product_distributes_over_vector_addition(Vector a, Vector b, Vector c)
        {
            var x = Vector.Dot(a, b + c);
            var y = Vector.Dot(a, b) + Vector.Dot(a, c);

            AssertEqual(x, y);
        }
    }
}
