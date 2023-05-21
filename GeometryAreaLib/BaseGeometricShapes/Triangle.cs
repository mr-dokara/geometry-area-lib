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
        ValidateEdge(edgeA, nameof(EdgeA));
        ValidateEdge(edgeB, nameof(EdgeB));
        ValidateEdge(edgeC, nameof(EdgeC));
        
        _edgeA = edgeA;
        _edgeB = edgeB;
        _edgeC = edgeC;
    }
    
    
    /// <summary>
    /// Длинна стороны A
    /// </summary>
    public double EdgeA {
        get => _edgeA;
        set
        {
            ValidateEdge(value, nameof(EdgeA));
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
            ValidateEdge(value, nameof(EdgeB));
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
            ValidateEdge(value, nameof(EdgeC));
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
            double sqrEdgeA = Math.Pow(_edgeA, 2);
            double sqrEdgeB = Math.Pow(_edgeB, 2);
            double sqrEdgeC = Math.Pow(_edgeC, 2);

            double maxSqrEdge = Math.Max(sqrEdgeA, Math.Max(sqrEdgeB, sqrEdgeC));
            double sumOtherEdges = sqrEdgeA + sqrEdgeB + sqrEdgeC - maxSqrEdge;
            
            double difference = Math.Abs(maxSqrEdge * .00001);
            
            return Math.Abs(maxSqrEdge - sumOtherEdges) < difference;
        }
    }


    /// <inheritdoc />>
    public double CalculateArea()
    {
        double p = (_edgeA + _edgeB + _edgeC) / 2;
        double area = Math.Sqrt(p * (p - _edgeA) * (p - _edgeB) * (p - _edgeC));
        
        return area;
    }
    
    private void ValidateEdge(double edge, string paramName)
    {
        if (edge <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "Длина стороны должна быть положительным числом.");
        }
    }
}