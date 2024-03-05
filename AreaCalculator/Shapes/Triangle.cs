namespace AreaCalculator.Shapes;

public class Triangle : IShape
{
    private const double Tolerance = 0.000001;
    private readonly Lazy<bool> isRight;

    public readonly double[] Sides;
    public bool IsRight => isRight.Value;

    public Triangle(double[] sides)
    {
        ValidateTriangle(sides);

        Sides = sides;
        isRight = new Lazy<bool>(IsRightTriangle);
    }

    public double CalculateArea()
    {
        var p = Sides.Sum() / 2;
        return Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
    }

    private static void ValidateTriangle(double[] sides)
    {
        if (sides is not {Length: 3})
            throw new ArgumentException("To create a triangle you need 3 sides");

        if (sides[0] + sides[1] <= sides[2] || sides[1] + sides[2] <= sides[0] || sides[0] + sides[2] <= sides[1])
            throw new ArgumentException("A triangle with such sides cannot exist");
    }

    private bool IsRightTriangle()
    {
        var sortedArray = Sides.OrderBy(x => x).ToArray();
        return Math.Abs(Math.Pow(sortedArray[0], 2) + Math.Pow(sortedArray[1], 2) - Math.Pow(sortedArray[2], 2)) <
               Tolerance;
    }
}