using System;

namespace edeastudio
{
    public class SquareShape : edsShape
    {
        public float[] sides;
        public SquareShape()
        {
            ShapeType = ShapeTypeEnum.Square;
            SetShapeName(ShapeTypeName(this.ShapeType));
            SetSides(4);
            sides = GetSides();
            for (int i = 0; i < sides.Length; i++)
            {
                sides[i] = 1;
            }
        }
        public override float GetArea(float[] sides)
        {
            float area = sides[0] * sides[0];

            return (float)Math.Round((double)area, 2);
        }
    }
}
