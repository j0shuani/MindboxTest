using AreaCalculator.Shapes;
using FluentAssertions;
using NUnit.Framework;

namespace AreaCalculatorTests;

public class TriangleTests
{
    [TestCaseSource(nameof(GetCorerctInputValues))]
    public void Triangle_ShouldCalculateCorrectArea(double[] sides, double expectedArea)
    {
        var triangle = new Triangle(sides);
        triangle.CalculateArea().Should().Be(expectedArea);
    }

    [TestCaseSource(nameof(GetRandomTriangleTypeCorerctInputValues))]
    public void Triangle_ShouldRecognizeARightTriangle(double[] sides, bool isRight)
    {
        var triangle = new Triangle(sides);
        triangle.IsRight.Should().Be(isRight);
    }

    [TestCaseSource(nameof(GetIncorerctInputValues))]
    public void Triangle_ShouldThrowExceptionOnIncorrectInput(double[] sides, string expectedMessage)
    {
        FluentActions.Invoking(() => new Triangle(sides)).Should().Throw<ArgumentException>()
            .WithMessage(expectedMessage);
    }

    private static IEnumerable<object> GetCorerctInputValues()
    {
        yield return new object[] {new double[] {2, 2, 3}, 1.984313483298443};
        yield return new object[] {new double[] {4, 2, 3}, 2.9047375096555625};
        yield return new object[] {new[] {2.5, 2, 3}, 2.4803918541230536};
    }

    private static IEnumerable<object> GetRandomTriangleTypeCorerctInputValues()
    {
        yield return new object[] {new double[] {3, 4, 5}, true};
        yield return new object[] {new double[] {3, 3, 5}, false};
    }

    private static IEnumerable<object> GetIncorerctInputValues()
    {
        yield return new object[] {null, "To create a triangle you need 3 sides"};
        yield return new object[] {new double[] {0, 1}, "To create a triangle you need 3 sides"};
        yield return new object[] {new double[] {1, 2, 3}, "A triangle with such sides cannot exist"};
        yield return new object[] {new double[] {-2, -2, 3}, "A triangle with such sides cannot exist"};
    }
}