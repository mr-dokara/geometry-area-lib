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
        Radius = radius;
    }
    
    
    /// <summary>
    /// Радиус
    /// </summary>
    public double Radius
    {
        get => _radius;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(Radius));
            _radius = value;
        }
    }

    
    /// <inheritdoc />>
    public double CalculateArea()
    {
        double area = Math.PI * Math.Pow(Radius, 2);

        return area;
    }
}