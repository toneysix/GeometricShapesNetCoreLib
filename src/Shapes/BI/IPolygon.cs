namespace Shapes.BI
{
    /// <summary>
    /// Интерфейс полигона.
    /// </summary>
    public interface IPolygon : IShape
    {
        /// <summary>
        /// Получить количество точек, приходящихся на полигон.
        /// </summary>
        int NumberOfPoints { get; }
    }
}