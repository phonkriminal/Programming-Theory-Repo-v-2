using System;
using UnityEngine;
using TMPro;
namespace edeastudio
{
    public class SquareShape : edsShape
    {
        //public float[] sides;
        public SquareShape()
        {
            ShapeType = ShapeTypeEnum.Square;
            SetShapeName(ShapeTypeName(this.ShapeType));
            //SetSides(4);
            //sides = GetSides();

            //inputsSideLength = new TMP_InputField[m_Sides]; 
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

        public override float GetArea(float[] sides)
        {
            float area = float.Parse(inputsSideLength[0].text) * float.Parse(inputsSideLength[0].text);

            return (float)Math.Round((double)area, 2);
        }
        public override float GetArea()
        {
            float area = float.Parse(inputsSideLength[0].text) * float.Parse(inputsSideLength[0].text);
            return (float)Math.Round((double)area, 2);
        }
        public override void Calculate()
        {
            base.Calculate();
            areaText.text = string.Format(GetArea().ToString("0.00"));
        }
    }
}
