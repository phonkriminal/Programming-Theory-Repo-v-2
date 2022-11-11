using System;
using UnityEngine;

namespace edeastudio
{
    public class CircleShape : edsShape
    {
        private float[] sides;

        public CircleShape()
        {
            float radius = 10;
            ShapeType = ShapeTypeEnum.Circle;
            SetShapeName(ShapeTypeName(this.ShapeType));
            SetSides(1);
            sides = GetSides();

            //  Circumference =  C = 2 * r * π
            //  where C is the circumference
            //  and r is radius
            
            float c = radius * radius * Mathf.PI;
            
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i] = c;
            }
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
    
        public override float GetArea(float[] sides)
        {
            //  A = r² x π
            //  where A is Area
            //  and r is radius

            // A = (2p)² / 4π
            //  where A is Area
            //  and p is circumference

            if (sides == null || sides.Length == 0) { return 0.0f; }
            float p = sides[0] * sides[0] * MathF.PI;
            float area = Mathf.Pow((2 * p), 2) / 4 * MathF.PI;

            return (float)Math.Round((double)area, 2);
        }
    }

}