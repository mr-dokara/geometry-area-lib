using Shouldly;
using GeometryAreaLib.BaseGeometricShapes;

namespace GeometryAreaLib.Tests;

public class TriangleTests
{
    [Fact]
    public void CreateTriangle_NormalEdgeLengths_ShouldBeSuccess()
    {
        // Arrange
        double edgeA = 2.5;
        double edgeB = 5.6;
        double edgeC = 3.7;

        // Act
        var triangle = new Triangle(edgeA, edgeB, edgeC);

        // Assert
        triangle.EdgeA.ShouldBe(edgeA);
        triangle.EdgeB.ShouldBe(edgeB);
        triangle.EdgeC.ShouldBe(edgeC);
    }
    
    [Fact]
    public void CreateTriangle_ZeroEdgeLength_ShouldThrowException()
    {
        // Arrange
        double edgeA = 0;
        double edgeB = 11.2;
        double edgeC = 3.9;

        // Act
        Action act = () => new Triangle(edgeA, edgeB, edgeC);

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
    
    [Fact]
    public void UpdateTriangle_ZeroEdgeLength_ShouldThrowException()
    {
        // Arrange
        double edgeA = 2.5;
        double edgeB = 5.6;
        double edgeC = 3.7;

        var triangle = new Triangle(edgeA, edgeB, edgeC);
        
        // Act
        Action act = () => triangle.EdgeC = 0;

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
    
    [Theory]
    [MemberData(nameof(NormalTrianglesData))]
    public void CalculateArea_NormalEdgeLengths_ShouldBeCorrectArea(double[] edges, double expectedArea)
    {
        // Arrange
        var triangle = new Triangle(edges[0], edges[1], edges[2]);

        // Act
        double result = triangle.CalculateArea();

        // Assert
        var roundedResult = Math.Round(result, 6);
        roundedResult.ShouldBe(expectedArea);
    }
    
    public static IEnumerable<object[]> NormalTrianglesData { get; } = new[]
    {
        new object[]
        {
            new [] { 10.5, 15.8, 6.3 },
            21.741665
        },
        new object[]
        {
            new [] { 64.1, 39.9, 54.2 },
            1076.159338
        },
        new object[]
        {
            new [] { 3.0, 3.0, 3.0 },
            3.897114
        }
    };
    
    [Theory]
    [MemberData(nameof(RightTrianglesData))]
    public void IsRight_ShouldBeSuccess(double[] edges, bool isRight)
    {
        // Arrange
        double edgeA = 3.0;
        double edgeB = 4.0;
        double edgeC = 5.0;

        var triangle = new Triangle(edgeA, edgeB, edgeC);
        
        // Act
        var result = triangle.IsRight;

        // Assert
        result.ShouldBeTrue();
    }
    
    public static IEnumerable<object[]> RightTrianglesData { get; } = new[]
    {
        new object[]
        {
            new [] { 3.0, 4.0, 5.0 },
            true
        },
        new object[]
        {
            new [] { 10.5, 15.8, 6.3 },
            false
        },
        new object[]
        {
            new [] { 5.59732, 4.2, 3.7 },
            true
        },
        new object[]
        {
            new [] { 26.39, 32.95603, 19.74 },
            true
        },
        new object[]
        {
            new [] { 73.1, 45.9, 61.7 },
            false
        }
    };
}