namespace Shapes.BI
{
    /// <summary>
    /// Интерфейс геометрической фигуры эллипса.
    /// </summary>
    public interface IEllipse : IShape
    {
        /// <summary>
        /// Получает горизонтальный радиус эллипса.
        /// </summary>
        double R1 { get; }

        /// <summary>
        /// Получает вертикальный радиус эллипса.
        /// </summary>
        double R2 { get; }
    }
}