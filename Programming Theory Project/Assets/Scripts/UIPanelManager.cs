using System;
using TMPro;
using UnityEngine;

namespace edeastudio
{
    public class UIPanelManager : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text textName;       
        [SerializeField]
        private TMP_Text textInfo;
        [SerializeField]
        private TMP_InputField inputShapeName;
        [SerializeField]
        private TMP_InputField[] inputsSideLength;
        [SerializeField]
        private edsShape sS;
        [SerializeField]
        private GameObject shapeObject;
        private dynamic dynamicShape;
        private float perimeter = 0;
        private float area = 0;
        void Start()
        {
            sS = shapeObject.GetComponent<edsShape>();
            if (sS != null) { CreateDynamicObject(sS); }
        }

        void CreateDynamicObject(edsShape shape)
        {
            if (shape.GetType() == typeof(SquareShape)) { dynamicShape = (SquareShape)Convert.ChangeType(sS, typeof(SquareShape)); }
            else if (shape.GetType() == typeof(CircleShape)) { dynamicShape = (CircleShape)Convert.ChangeType(sS, typeof(CircleShape)); }
            else if (shape.GetType() == typeof(TriangleShape)) { dynamicShape = (TriangleShape)Convert.ChangeType(sS, typeof(TriangleShape)); }
            else if (shape.GetType() == typeof(RectShape)) { dynamicShape = (RectShape)Convert.ChangeType(sS, typeof(RectShape)); }
            
            ShowCurrentInfo();
        }

        public void ShowCurrentInfo()
        {
            dynamicShape.Calculate();
            //if(inputShapeName.text.Length > 0)
            //{
            //    dynamicShape.SetShapeName(inputShapeName.text);
            //}
            //textName.text = dynamicShape.GetShapeName();
            //int index = dynamicShape.GetIndex();
            //float[] length = new float[index];
            
            //for (int i = 0; i < index; i++)
            //{
            //    length[i] = (float)Convert.ChangeType(inputsSideLength[i].text, TypeCode.Single);
            //}
            //dynamicShape.SetSidesLength(length);
            //perimeter = dynamicShape.GetPerimeter();
            //area = dynamicShape.GetArea(length);

            //string info = $"Current info of {dynamicShape.GetShapeName()} \r\n \r\nPerimeter : {perimeter} \r\nArea : {area}";
            //textInfo.text = info;
        }
    }
}
