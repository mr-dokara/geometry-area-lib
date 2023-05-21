using GeometryAreaLib.Abstractions;

namespace GeometryAreaLib.BaseGeometricShapes;

/// <summary>
/// Круг
/// </summary>
public class Circle : IGeometricShape
{
    private double _radius;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="radius">Радиус</param>
    public Circle(double radius)
    {
        ValidateRadius(radius, nameof(Radius));
        
        _radius = radius;
    }
    
    
    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            ValidateRadius(value, nameof(Radius));
            _radius = value;
        }
    }

    
    /// <inheritdoc />>
    public double CalculateArea()
    {
        double area = Math.PI * Math.Pow(_radius, 2);

        return area;
    }
    
    private void ValidateRadius(double radius, string paramName)
    {
        if (radius <= 0)
        {
            throw new ArgumentOutOfRangeException(paramName, "Радиус должен быть положительным числом.");
        }
    }
}