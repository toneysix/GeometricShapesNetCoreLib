namespace Shapes.BE
{
    using System;
    using Shapes.BI;

    /// <summary>
    /// Класс, реализующий геометрическую фигуру эллипса в рамках спецификации IEllipse.
    /// </summary>
    internal class Ellipse : IShape, IEllipse
    {
        /// <summary>
        /// Конструктор класса эллипса по двум её радиусам.
        /// </summary>
        /// <param name="r1">Горизонтальный радиус эллипса.</param>
        /// <param name="r2">Вертикальный радиус эллипса.</param>
        /// <exception cref="ArgumentException">Эллипс с указанными радиусами не валиден.</exception>
        internal Ellipse(double r1, double r2)
        {
            this.R1 = r1;
            this.R2 = r2;

            if (!this.CheckIfEllipseRadiusValid())
            {
                throw new ArgumentException($"Эллипс с указанными радиусами {this.R1} и {this.R2} не валиден");
            }
        }

        /// <summary>
        /// Конструктор класса эллипса при вырождении его в окружность.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        /// <exception cref="ArgumentException">Окружность с указанными радиусом не валидна.</exception>
        internal Ellipse(double r)
        {
            this.R1 = r;
            this.R2 = r;

            if (!this.CheckIfEllipseRadiusValid())
            {
                throw new ArgumentException($"Окружность с указанными радиусом {this.R1} не валидна");
            }
        }

        /// <summary>
        /// Горизонтальный радиус эллипса. Реализация IEllipse.
        /// </summary>
        public double R1 { get; private set; }

        /// <summary>
        /// Вертикальный радиус эллипса. Реализация IEllipse.
        /// </summary>
        public double R2 { get; private set; }

        /// <summary>
        /// Реализация метода IShape.Area, вычисляющего площадь геометрической фигуры - эллипса.
        /// </summary>
        /// <returns>Возвращает площадь эллипса.</returns>
        public double Area()
        {
            return this.GetEllipseArea();
        }

        /// <summary>
        /// Метод, вычисляющий площадь эллипса.
        /// </summary>
        /// <returns>Возвращает площадь эллипса.</returns>
        private double GetEllipseArea()
        {
            return Math.PI * this.R1 * this.R2;
        }

        /// <summary>
        /// Метод, валидирующий радиусы эллипса.
        /// </summary>
        /// <returns>Возвращает true, если радиусы заданы валидно, false - в противном случае.</returns>
        private bool CheckIfEllipseRadiusValid()
        {
            if (this.R1 > 0 && this.R2 > 0)
            {
                return true;
            }

            return false;
        }
    }
}
