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

        public Triangle(double a, double b, double c)
        {
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
