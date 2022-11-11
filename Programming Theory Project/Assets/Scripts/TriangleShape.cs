using System;
using UnityEngine;

namespace edeastudio
{
    public class TriangleShape : edsShape
    {
        private float[] sides;

        public TriangleShape()
        {
            ShapeType = ShapeTypeEnum.Triangle;
            SetShapeName(ShapeTypeName(this.ShapeType));
            SetSides(3);
            sides = GetSides();
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i] = 1;
            }
        }

        //  POLYMORPHISM
        #region POLYMORPHISM

        public override float GetArea(float[] sides)
        {
            if (sides == null || sides.Length == 0) { return 0f; }

            // HEURONE FORMULA
            // Area = Sqrt(s * (s - a)(s - b)(s - c))
            // where s = perimeter / 2

            float a = sides[0];
            float b = sides[1];
            float c = sides[2];

            float halfPerimeter = (a + b + c) / 2;
            float underTheSqrt = halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c);
            float area = Mathf.Sqrt(underTheSqrt);

            return (float)Math.Round((double)area, 2);
        }
        #endregion
    }
}