namespace AreaCalculator.Shapes;

public class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius < 0)
            throw new ArgumentException("Radius cannot be negative");
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}