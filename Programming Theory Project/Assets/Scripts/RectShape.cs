using System;

namespace edeastudio
{
    public class RectShape : edsShape
    {
        private float[] sides;

        public RectShape()
        {
            ShapeType = ShapeTypeEnum.Rectangle;
            SetShapeName(ShapeTypeName(this.ShapeType));
            SetSides(4);
            sides = GetSides();
            sides[0] = 1;
            sides[1] = 2;
            sides[2] = 1;
            sides[3] = 2;    
        }
        public override float GetArea(float[] sides)
        {
            float area = sides[0] * sides[1];

            return (float)Math.Round((double)area, 2);
        }
    }
}