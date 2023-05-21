using GeometryAreaLib.Abstractions;

namespace GeometryAreaLib.BaseGeometricShapes;

/// <summary>
/// Треугольник
/// </summary>
public class Triangle : IGeometricShape
{
    private double _edgeA, _edgeB, _edgeC;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="edgeA">Длинна стороны A</param>
    /// <param name="edgeB">Длинна стороны B</param>
    /// <param name="edgeC">Длинна стороны C</param>
    public Triangle(double edgeA, 
        double edgeB,
        double edgeC)
    {
        EdgeA = edgeA;
        EdgeB = edgeB;
        EdgeC = edgeC;
    }
    
    
    /// <summary>
    /// Длинна стороны A
    /// </summary>
    public double EdgeA {
        get => _edgeA;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(EdgeA));
            _edgeA = value;
        } 
    }
    
    /// <summary>
    /// Длинна стороны B
    /// </summary>
    public double EdgeB {
        get => _edgeB;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(EdgeB));
            _edgeB = value;
        } 
    }
    
    /// <summary>
    /// Длинна стороны C
    /// </summary>
    public double EdgeC {
        get => _edgeC;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(EdgeC));
            _edgeC = value;
        } 
    }

    /// <summary>
    /// Является ли треугольник прямоугольным
    /// </summary>
    public bool IsRight
    {
        get
        {
            double sqrEdgeA = Math.Pow(EdgeA, 2);
            double sqrEdgeB = Math.Pow(EdgeB, 2);
            double sqrEdgeC = Math.Pow(EdgeC, 2);

            double maxSqrEdge = Math.Max(sqrEdgeA, Math.Max(sqrEdgeB, sqrEdgeC));
            double sumOtherEdges = sqrEdgeA + sqrEdgeB + sqrEdgeC - maxSqrEdge;
            
            double difference = Math.Abs(maxSqrEdge * .00001);
            
            return Math.Abs(maxSqrEdge - sumOtherEdges) < difference;
        }
    }


    /// <inheritdoc />>
    public double CalculateArea()
    {
        double p = (EdgeA + EdgeB + EdgeC) / 2;
        double area = Math.Sqrt(p * (p - EdgeA) * (p - EdgeB) * (p - EdgeC));
        
        return area;
    }
}