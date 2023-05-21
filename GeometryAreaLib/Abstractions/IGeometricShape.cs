namespace GeometryAreaLib.Abstractions;

/// <summary>
/// Геометрическая фигура
/// </summary>
public interface IGeometricShape
{
    /// <summary>
    /// Вычисление площади фигуры
    /// </summary>
    /// <returns>Площадь фигуры</returns>
    double CalculateArea();
}