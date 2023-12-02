using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleLib
{
    public class Triangle
    {
        /// <summary>
        /// Стороны треугольника отсортированные в порядке убывания
        /// </summary>
        private readonly List<double> _sides;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="a">Сторона 1</param>
        /// <param name="b">Сторона 2</param>
        /// <param name="c">Сторона 3</param>
        /// <exception cref="ArgumentException">Некорректно заданы стороны треугольника</exception>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Некорректно заданы стороны треугольника");

            _sides = new List<double> { a, b, c }
                .OrderByDescending(side => side)
                .ToList();
        }

        /// <summary>
        /// Треугольник остроугольный, прямоугольный или тупоугольный?
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Треугольник не существует</exception>
        public Type GetTriangleType()
        {
            if(!IsExists())
                throw new ArgumentException("Треугольник не существует");

            var squareMaxSide = Math.Pow(_sides[0], 2);
            var squareMinSides = Math.Pow(_sides[1], 2) + Math.Pow(_sides[2], 2);

            if (squareMaxSide > squareMinSides)
                return Type.Obtuse;
            else if (squareMaxSide < squareMinSides)
                return Type.Acute;
            else 
                return Type.Right;
        }

        /// <summary>
        /// Треугольник существует?
        /// </summary>
        /// <returns></returns>
        public bool IsExists()
            => _sides[0] < _sides[1] + _sides[2];
    }
}
