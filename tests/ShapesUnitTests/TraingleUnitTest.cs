namespace ShapesUnitTests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using Shapes.Factory;

    /// <summary>
    /// Класс, реализующий модульное тестирование геометрических фигур треугольника через интерфейс ITraingle реализации Traingle.
    /// </summary>
    [TestFixture]
    public class TraingleUnitTest
    {
        /// <summary>
        /// Метод, тестирующий реализацию метода ITraingle.Area на предмет корректного расчёта площади по трём заданным сторонам треугольника.
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника.</param>
        /// <param name="b">Длина второй стороны треугольника.</param>
        /// <param name="c">Длина третьей стороны треугольника.</param>
        /// <param name="expectedArea">Ождиаемое значение площади треугольника, округленное до целого числа по математическому правилу.</param>
        /// <remarks>Получаемая площадь округляется по законам математического округления.</remarks>
        [Test]
        [TestCase(3, 4, 5, 6)]   
        [TestCase(10, 6, 6, 17)]
        [TestCase(15, 12, 9, 54)]
        public void AreaMethodTest(double a, double b, double c, double expectedArea)
        {
            // Arrange 
            var traingle = ShapeFactory.CreateTraingleByThreeSides(a, b, c);

            // Act
            var traingleArea = Math.Round(traingle.Area(), MidpointRounding.AwayFromZero);

            // Assert
            Assert.AreEqual(traingleArea, expectedArea);
        }

        /// <summary>
        /// Метод, тестирующий реализацию свойства ITraingle.IsRightTriangle.
        /// </summary>
        /// <param name="a">Длина первой стороны треугольника.</param>
        /// <param name="b">Длина второй стороны треугольника.</param>
        /// <param name="c">Длина третьей стороны треугольника.</param>
        /// <param name="expectedValue">Ожидаемое значение признака прямоугольного треугольника, заданного длинами его сторон.</param>
        [Test]
        [TestCase(3, 4, 5, true)]
        [TestCase(10, 6, 6, false)]
        [TestCase(15, 12, 9, true)]
        public void IsRightTrianglePropertyTest(double a, double b, double c, bool expectedValue)
        {
            // Arrange 
            var traingle = ShapeFactory.CreateTraingleByThreeSides(a, b, c);

            // Act & Assert
            Assert.AreEqual(traingle.IsRightTriangle, expectedValue);
        }

        /// <summary>
        /// Метод, тестирующий реализацию свойства IPolygon.NumberOfPoint.
        /// </summary>
        [Test]
        public void NumberOfPointPropertyTest()
        {
            // Arrange 
            var traingle = ShapeFactory.CreateTraingleByThreeSides(3, 4, 5);

            // Act & Assert
            Assert.AreEqual(traingle.NumberOfPoints, 3);
        }
    }
}