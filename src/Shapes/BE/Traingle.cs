namespace Shapes.BE
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Shapes.BI;

    /// <summary>
    /// Класс, реализующий геометрическую фигуру треугольника в рамках спецификации ITraingle.
    /// </summary>
    internal class Traingle : IShape, IPolygon, ITraingle
    {
        /// <summary>
        /// Конструктор класса треугольника по длинам трёх его сторон.
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника.</param>
        /// <param name="b">Длина второй стороны треугольника.</param>
        /// <param name="c">Длина третьей стороны треугольника.</param>
        internal Traingle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;

            if (!this.CheckIfThisTraingleCanBeConstuctedByThreeSides())
            {
                throw new ArgumentException("Сумма двух любых сторон треугольника должна быть больше суммы третьей стороны");
            }
        }

        /// <summary>
        /// Длина первой стороны треугольника. Реализация ITraingle.
        /// </summary>
        public double A { get; private set; }

        /// <summary>
        /// Длина второй стороны треугольника. Реализация ITraingle.
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Длина третьей стороны треугольника. Реализация ITraingle.
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// Признак прямоугольного треугольника. Реализация ITraingle.
        /// </summary>
        public bool IsRightTriangle => this.IsThisTriangleRight();

        /// <summary>
        /// Количество точек полигона.
        /// </summary>
        public int NumberOfPoints => 3;

        /// <summary>
        /// Реализация метода IShape.Area, вычисляющего площадь геометрической фигуры - треугольника.
        /// </summary>
        /// <returns>Возвращает площадь треугольника.</returns>
        public double Area()
        {
            return this.GetTraingleAreaByThreeSides();
        }

        /// <summary>
        /// Метод, устанавливающий, является ли настоящий треугольник прямоугольным по теореме Пифагора.
        /// </summary>
        /// <returns>Возвращает true в случае, если треугольник является прямоугольным, в противном - false.</returns>
        private bool IsThisTriangleRight()
        {
            return this.GetAscOrderedSidesByLen().Take(2).Sum(s => Math.Pow(s, 2.0)).Equals(Math.Pow(this.GetAscOrderedSidesByLen().Last(), 2.0));
        }

        /// <summary>
        /// Метод, вычисляющий площадь треугольника по трём его сторонам по теореме Герона.
        /// </summary>
        /// <returns>Возвращает вычисленную площадь треугольника.</returns>
        private double GetTraingleAreaByThreeSides()
        {
            var halfP = (this.A + this.B + this.C) / 2d;
            return Math.Sqrt(halfP * (halfP - this.A) * (halfP - this.B) * (halfP - this.C));
        }

        /// <summary>
        /// Метод, получающий перечисление отсортированных по неубыванию длин настоящего треугольника.
        /// </summary>
        /// <returns>Возвращает перечисление отсортированных в порядке неубывания значений длин настоящего треугольника.</returns>
        private IEnumerable<double> GetAscOrderedSidesByLen()
        {
            return new double[] { this.A, this.B, this.C }.OrderBy(shape => shape);
        }

        /// <summary>
        /// Метод, устанавливающий возможность построения треугольника по заданным длинам трёх его сторон.
        /// </summary>
        /// <returns>Возвращает true, если построение треугольника возможно, false - в противном случае.</returns>
        private bool CheckIfThisTraingleCanBeConstuctedByThreeSides()
        {
            if (this.GetAscOrderedSidesByLen().Take(2).Sum(s => s) > this.GetAscOrderedSidesByLen().Last())
            {
                return true;
            }

            return false;
        }
    }
}
