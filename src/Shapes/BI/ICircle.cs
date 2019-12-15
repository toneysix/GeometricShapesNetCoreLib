namespace Shapes.BI
{
    /// <summary>
    /// Интерфейс геометрической фигуры окружности.
    /// </summary>
    public interface ICircle : IShape
    {
        /// <summary>
        /// Получает радиус окружности.
        /// </summary>
        double R { get; }

        /// <summary>
        /// Метод, приводящий окружность к эллипсу.
        /// </summary>
        /// <returns>Возвращает неизменяемый экземпляр реализации интерфейса эллипса.</returns>
        IEllipse ToEllipse();
    }
}
