using System;

namespace edeastudio
{
    public class RectShape : edsShape
    {

        public RectShape()
        {
            ShapeType = ShapeTypeEnum.Rectangle;
            SetShapeName(ShapeTypeName(this.ShapeType));
        }

        public override void Start()
        {
            base.Start();
            
            inputsSideLength[0].text = "2";
            inputsSideLength[1].text = "1";
            inputsSideLength[2].text = "2";
            inputsSideLength[3].text = "1";

            Calculate();
        }

        public override void Calculate()
        {
            base.Calculate();
            areaText.text = string.Format(GetArea().ToString("0.00"));
        }

        public override float GetArea()
        {
            float a = float.Parse(inputsSideLength[0].text);
            float b = float.Parse(inputsSideLength[1].text);
            float area = a * b;

            return (float)Math.Round((double)area, 2);
        }
    }
}