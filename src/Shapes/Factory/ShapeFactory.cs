namespace Shapes.Factory
{
    using System;
    using Shapes.BE;
    using Shapes.BI;

    /// <summary>
    /// Класс фабрики геометрических фигур на плоскости.
    /// </summary>
    public static class ShapeFactory
    {
        /// <summary>
        /// Метод, создающий окружность по её радиусу.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        /// <returns>Возвращает неизменяемый экземпляр реализации окружности ICircle.</returns>
        /// <exception cref="ArgumentException">Возникает в случае передачи отрицательного радиуса.</exception>
        public static ICircle CreateCircleByRadius(double r)
        {
            return new Circle(r);
        }

        /// <summary>
        /// Метод, создающий эллипс по двум его радиусам.
        /// </summary>
        /// <param name="r1">Горизонтальный радиус эллипса.</param>
        /// <param name="r2">Вертикальный радиус эллипса.</param>
        /// <returns>Возвращает неизменяемый экземпляр реализации интерфейса эллипса IEllipse.</returns>
        /// <exception cref="ArgumentException">Возникает в случае указания отрицательных радиусов.</exception>
        public static IEllipse CreateEllipseByRadius(double r1, double r2)
        {
            return new Ellipse(r1, r2);
        }

        /// <summary>
        /// Метод, создающий произвольный треугольник по трём заданным длинам его сторон.
        /// </summary>
        /// <param name="a">Длина первой стороны.</param>
        /// <param name="b">Длина второй стороны.</param>
        /// <param name="c">Длина третьей стороны.</param>
        /// <returns>Возвращает неизменяемый экземпляр реализации треугольника ITraingle.</returns>
        /// <exception cref="ArgumentException">Возникает в случае, если сумма любой пары сторон треугольника меньше третьей стороны.</exception>
        public static ITraingle CreateTraingleByThreeSides(double a, double b, double c)
        {
            return new Traingle(a, b, c);
        }
    }
}