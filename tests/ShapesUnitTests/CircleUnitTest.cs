namespace ShapesUnitTests
{
    using NUnit.Framework;
    using System;
    using Shapes.Factory;

    /// <summary>
    /// Класс, реализующий модульное тестирование окружности через интерфейс ICircle реализации Circle.
    /// </summary>
    [TestFixture]
    public class CircleUnitTest
    {
        /// <summary>
        /// Метод, тестирующий реализацию ICircle.Area метода.
        /// </summary>
        /// <param name="circleRadius">Радиус окружности для её создания и тестирования.</param>
        /// <param name="expectedArea">Ожидаемое значение площади окружности от её радиуса.</param>
        /// <remarks>Точность значения площади ограничена 5 знаками после запятой.</remarks>
        [Test]
        [TestCase(3, 28.27433)]
        [TestCase(1, 3.14159)]
        public void AreaMethodTest(double circleRadius, double expectedArea)
        {
            // Arrange
            var circle = ShapeFactory.CreateCircleByRadius(circleRadius);

            // Act
            var circleArea = Math.Round(circle.Area(), 5);

            // Assert
            Assert.AreEqual(expectedArea, circleArea);
        }

        /// <summary>
        /// Метод, тестирующий реализацию ICircle.ToEllipse метода.
        /// </summary>
        /// <param name="circleRadius">Радиус окружности для её создания и тестирования.</param>
        [Test]
        [TestCase(3)]
        [TestCase(1)]
        public void ToEllipseMethodTest(double circleRadius)
        {
            // Arrange
            var circle = ShapeFactory.CreateCircleByRadius(circleRadius);

            // Act
            var ellipse = circle.ToEllipse();

            // Assert
            Assert.IsTrue(ellipse != null);
            Assert.AreEqual(circleRadius, ellipse.R1);
            Assert.AreEqual(circleRadius, ellipse.R2);
        }
    }
}
