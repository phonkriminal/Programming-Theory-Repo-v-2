using System;
using UnityEngine;

namespace edeastudio
{
    public class CircleShape : edsShape
    {
        //private float[] sides;

        public CircleShape()
        {

            ShapeType = ShapeTypeEnum.Circle;
            SetShapeName(ShapeTypeName(this.ShapeType));
            //SetSides(1);
            //sides = GetSides();

        }

        public override void Start()
        {
            base.Start();
            inputsSideLength[0].text = "5";
            Calculate();
        }
        public override void SetSidesLength(float[] sidesLength)
        {
            float radius = sidesLength[0];
            float c = radius * radius * Mathf.PI;

            for (int i = 0; i < sidesLength.Length; i++)
            {
                m_sidesLenght[i] = c;
            }
        }

        public override float GetPerimeter()
        {
            //  Circumference =  C = 2 * r * π
            //  where C is the circumference
            //  and r is radius
            float radius = float.Parse(inputsSideLength[0].text);

            float c = radius * radius * Mathf.PI;

            //for (int i = 0; i < sides.Length; i++)
            //{
            //    sides[i] = c;
            //}

            return (float)Math.Round((double)c, 2);
        }
        public override float GetArea()
        {
            //  A = r² x π
            //  where A is Area
            //  and r is radius

            // A = (2p)² / 4π
            //  where A is Area
            //  and p is circumference

            float radius = float.Parse(inputsSideLength[0].text);

            
            float p = radius * radius * MathF.PI;
            float area = Mathf.Pow((2 * p), 2) / 4 * MathF.PI;

            return (float)Math.Round((double)area, 2);
        }

        public override void Calculate()
        {
            base.Calculate();
            perimeterText.text = string.Format(GetPerimeter().ToString("0.00"));
            areaText.text = string.Format(GetArea().ToString("0.00"));
        }

    }

}