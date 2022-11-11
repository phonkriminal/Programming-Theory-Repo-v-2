using System;
using UnityEngine;

namespace edeastudio
{
    public abstract class edsShapeAbstract : MonoBehaviour
    {
        public abstract string GetShapeName();
        public abstract void SetShapeName(string shapeName);
        public abstract string GetDescription();
        public abstract void SetDescription(string description);
        public abstract void Start();
        public virtual ShapeTypeEnum ShapeType { get; set; }
    }

    [Serializable]
    public enum ShapeTypeEnum
    {
        Square,
        Triangle,
        Rectangle,
        Circle
    } 
}