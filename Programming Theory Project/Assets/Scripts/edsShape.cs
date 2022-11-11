using System;

namespace edeastudio
{
    public class edsShape : edsShapeAbstract    // INHERITANCE
    {
        protected string m_ShapeName;
        protected int m_Sides;
        protected float[] m_sidesLenght;
        protected string m_Description;
        protected ShapeTypeEnum shapeType;

        public override void Start()
        {
            if (m_ShapeName.Length == 0) { m_ShapeName = this.name; }
        }

        public virtual void SetSides(int sides)
        {
            m_Sides = sides;
        }

        public virtual float[] GetSides()
        {
            m_sidesLenght = new float[m_Sides];
            return m_sidesLenght;
        }

        public virtual void SetSidesLength(float[] sidesLength)
        {
            for (int i = 0; i < sidesLength.Length; i++)
            {
                m_sidesLenght[i] = sidesLength[i];
            }
        }
        public virtual int GetIndex()
        {
            return m_Sides;
        }

        public override void SetShapeName(string shapeName)
        {
            m_ShapeName = shapeName;
        }

        public override string GetShapeName()
        {
            return m_ShapeName;
        }

        public override string GetDescription()
        {
            return m_Description;
        }

        public override void SetDescription(string description)
        {
            m_Description = description;
        }

        public override ShapeTypeEnum ShapeType { get => shapeType; set => shapeType = value; }

        public virtual string ShapeTypeName(ShapeTypeEnum typeEnum) { return System.Enum.GetName(typeof(ShapeTypeEnum), typeEnum); }

        public virtual float GetPerimeter()
        {
            float p = 0;
            for (int i = 0; i < m_Sides; i++)
            {
                p += m_sidesLenght[i];
            }
            return (float)Math.Round((double)p, 2);
        }
        
        public virtual float GetArea(float[] sides) { return 0; }
    }
}