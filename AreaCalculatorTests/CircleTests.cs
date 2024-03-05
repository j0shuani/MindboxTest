using AreaCalculator.Shapes;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

public class CircleTests
{
    [TestCase(0)]
    [TestCase(2.0)]
    public void Circle_ShouldCalculateCorrectArea(double radius)
    {
        var expectedArea = Math.PI * radius * radius;
        var circle = new Circle(radius);
        circle.CalculateArea().Should().Be(expectedArea);
    }

    [Test]
    public void Circle_ShouldThrowExceptionOnIncorrectInput()
    {
        FluentActions.Invoking(() => new Circle(-1)).Should().Throw<ArgumentException>()
            .WithMessage("Radius cannot be negative");
    }
}