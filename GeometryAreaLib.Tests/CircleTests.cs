using Shouldly;
using GeometryAreaLib.BaseGeometricShapes;

namespace GeometryAreaLib.Tests;

public class CircleTests
{
    [Fact]
    public void CreateCircle_NormalRadius_ShouldBeSuccess()
    {
        // Arrange
        double radius = 8.3;

        // Act
        var circle = new Circle(radius);

        // Assert
        circle.Radius.ShouldBe(radius);
    }
    
    [Fact]
    public void CreateCircle_ZeroRadiusLength_ShouldThrowException()
    {
        // Arrange
        double radius = 0;

        // Act
        Action act = () => new Circle(radius);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
    
    [Fact]
    public void UpdateCircle_ZeroRadiusLength_ShouldThrowException()
    {
        // Arrange
        double radius = 61.3;

        var circle = new Circle(radius);
        
        // Act
        Action act = () => circle.Radius = 0;

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
    
    [Theory]
    [MemberData(nameof(NormalCirclesData))]
    public void CalculateArea_NormalRadiusLengths_ShouldBeCorrectArea(double radius, double expectedArea)
    {
        // Arrange
        var circle = new Circle(radius);

        // Act
        double result = circle.CalculateArea();

        // Assert
        var roundedResult = Math.Round(result, 6);
        roundedResult.ShouldBe(expectedArea);
    }
    
    public static IEnumerable<object[]> NormalCirclesData { get; } = new[]
    {
        new object[]
        {
            6.3,
            124.689812
        },
        new object[]
        {
            39.9,
            5001.44692
        },
        new object[]
        {
            3.0,
            28.274334
        }
    };
}