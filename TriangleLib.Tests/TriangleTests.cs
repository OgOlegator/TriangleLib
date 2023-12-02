namespace TriangleLib.Tests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(1, 3, 2.5, Type.Obtuse)]
        [InlineData(1.145, 3, 2, Type.Obtuse)]
        [InlineData(100.249, 300, 271.58, Type.Obtuse)]
        [InlineData(1.5, 3, 3.9, Type.Obtuse)]
        [InlineData(211.249, 300, 271.58, Type.Acute)]
        [InlineData(1, 3, 3, Type.Acute)]
        [InlineData(19, 31, 25, Type.Acute)]
        [InlineData(8, 6, 10, Type.Right)]
        [InlineData(4, 5, 3, Type.Right)]
        public void GetTriangleType_TriangleTypeCalc_success(double a, double b, double c, Type expected)
        {
            var result = new Triangle(a, b, c).GetTriangleType();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 3, 2)]
        [InlineData(1, 3, 1)]
        [InlineData(100, 300, 199)]
        [InlineData(1499, 3000, 1501)]
        public void GetTriangleType_CheckTriangleExists_error(double a, double b, double c)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(a, b, c).GetTriangleType());
        }

        [Theory]
        [InlineData(1, 3, 2.5, true)]
        [InlineData(1, 3, 2, false)]
        [InlineData(1.145, 3, 2, true)]
        [InlineData(100, 300, 199, false)]
        [InlineData(1499, 3000, 1501, false)]
        [InlineData(1499, 3000, 1502, true)]
        [InlineData(1499, 3000, 1501.0001, true)]
        [InlineData(1, 3, 3, true)]
        public void IsExists_TriangleExistsCalc_success(double a, double b, double c, bool expected)
        {
            var result = new Triangle(a, b, c).IsExists();

            Assert.Equal(expected, result);
        }
    }
}