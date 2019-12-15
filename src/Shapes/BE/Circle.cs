namespace Shapes.BE
{
    using Shapes.BI;

    /// <summary>
    /// Класс, представляющий реализацию геометрической фигуры окружности по спецификации ICircle.
    /// </summary>
    internal class Circle : Ellipse, IShape, ICircle
    {
        /// <summary>
        /// Конструктор класса окружности по её радиусу.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        internal Circle(double r)
            : base(r)
        {
        }

        /// <summary>
        /// Радиус окружности. Реализация ICircle.
        /// </summary>
        public double R => this.R1;

        /// <summary>
        /// Метод, преобразующий окружность как частный случай эллипса в эллипс. Реализация метода ICircle.ToEllipse.
        /// </summary>
        /// <returns>Возвращает неизменяемый экземпляр реализации спецификации IEllipse.</returns>
        public IEllipse ToEllipse()
        {
            return this;
        }
    }
}
