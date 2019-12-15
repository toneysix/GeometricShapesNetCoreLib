namespace Shapes.BI
{
    /// <summary>
    /// Интерфейс геометрической фигуры треугольника.
    /// </summary>
    public interface ITraingle : IPolygon, IShape
    {
        /// <summary>
        /// Получает длину первой стороны треугольника.
        /// </summary>
        double A { get; }

        /// <summary>
        /// Получает длину второй стороны треугольника.
        /// </summary>
        double B { get; }

        /// <summary>
        /// Получает длину третьей стороны треугольника.
        /// </summary>
        double C { get; }

        /// <summary>
        /// Получает признак того, что треугольник является прямоугольным.
        /// </summary>
        bool IsRightTriangle { get; }
    }
}
