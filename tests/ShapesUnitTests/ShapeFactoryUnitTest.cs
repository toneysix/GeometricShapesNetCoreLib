namespace ShapesUnitTests
{
    using NUnit.Framework;
    using System;
    using Shapes.Factory;
    using Shapes.BI;

    /// <summary>
    /// Класс, модульно тестирующий фабрику геометрических фигур на плоскости.
    /// </summary>
    [TestFixture]
    public class ShapeFactoryUnitTest
    {
        /// <summary>
        /// Метод, тестирующий реализацию метода ShapeFactory.CreateTraingleByThreeSides на предмет корректного создания треугольника по трём его сторонам.
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника.</param>
        /// <param name="b">Длина второй стороны треугольника.</param>
        /// <param name="c">Длина третьей стороны треугольника.</param>
        [Test]
        [TestCase(3, 4, 5)]
        [TestCase(10, 6, 6)]
        [TestCase(15, 12, 9)]
        public void CreateTraingleByThreeSidesMethodTest(double a, double b, double c)
        {
            // Arrange & Act
            ITraingle traingle = null;
            Assert.DoesNotThrow(() => traingle = ShapeFactory.CreateTraingleByThreeSides(a, b, c));

            // Assert
            Assert.AreEqual(traingle.A, a);
            Assert.AreEqual(traingle.B, b);
            Assert.AreEqual(traingle.C, c);
        }

        /// <summary>
        /// Метод, тестирующий реализацию метода ShapeFactory.CreateTraingleByThreeSides на предмет возникновения исключительных ситуаций при задании невалидной конфигурации треугольника по трём сторонам.
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника.</param>
        /// <param name="b">Длина второй стороны треугольника.</param>
        /// <param name="c">Длина третьей стороны треугольника.</param>
        [Test]
        [TestCase(1, 3, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(1, 5, 6)]
        public void CreateTraingleByThreeSidesMethodTest_2(double a, double b, double c)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateTraingleByThreeSides(a, b, c));
        }

        /// <summary>
        /// Метод, тестирующий реализацию метода ShapeFactory.CreateCircleByRadius на предмет корректного создания окружности по её радиусу.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        [Test]
        [TestCase(0.5)]
        [TestCase(1)]
        [TestCase(2)]    
        public void CreateCircleByRadiusMethodTest(double r)
        {
            // Arrange & Act
            ICircle circle = null;
            Assert.DoesNotThrow(() => circle = ShapeFactory.CreateCircleByRadius(r));

            // Assert
            Assert.AreEqual(circle.R, r);
        }

        /// <summary>
        /// Метод, тестирующий реализацию метода ShapeFactory.CreateCircleByRadius на предмет возникновения исключений при задании невалидного радиуса окружности.
        /// </summary>
        /// <param name="r">Радиус окружности.</param>
        [Test]
        [TestCase(-0.5)]
        [TestCase(-1)]
        [TestCase(0)]
        public void CreateCircleByRadiusMethodTest_2(double r)
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateCircleByRadius(r));
        }
    }
}
