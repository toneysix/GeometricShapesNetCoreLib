namespace Shapes.BI
{
    /// <summary>
    /// Интерфейс геометрической фигуры.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Метод, рассчитывающий площадь геометрической фигуры.
        /// </summary>
        /// <returns>Возвращает площадь геометрической фигуры.</returns>
        double Area();
    }
}
