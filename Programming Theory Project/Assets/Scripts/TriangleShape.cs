using System;
using UnityEngine;

namespace edeastudio
{
    public class TriangleShape : edsShape
    {
        //private float[] sides;

        public TriangleShape()
        {
            ShapeType = ShapeTypeEnum.Triangle;
            SetShapeName(ShapeTypeName(this.ShapeType));
            //SetSides(3);
            //sides = GetSides();
        }

        public override void Start()
        {
            base.Start();

            for (int i = 0; i < inputsSideLength.Length; i++)
            {
                inputsSideLength[i].text = "1";
                Debug.Log(inputsSideLength.Length + " " + inputsSideLength[i].text);
            }

            Calculate();
        }

        //  POLYMORPHISM
        #region POLYMORPHISM

        public override float GetArea()
        {

            // HEURONE FORMULA
            // Area = Sqrt(s * (s - a)(s - b)(s - c))
            // where s = perimeter / 2

            float a = float.Parse(inputsSideLength[0].text);    // sides[0];
            float b = float.Parse(inputsSideLength[1].text);    // sides[1];
            float c = float.Parse(inputsSideLength[2].text);    // sides[2];

            float halfPerimeter = (a + b + c) / 2;
            float underTheSqrt = halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c);
            float area = Mathf.Sqrt(underTheSqrt);

            return (float)Math.Round((double)area, 2);
        }
        #endregion
    }
}