using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public class Visual
    {
        //To do
        //publick VisualCollection _children;

        public virtual Rect Rect { get; set; }
        public virtual Rect ClientRect {
            get {
                return new Rect(0, 0, Rect.width, Rect.height);
            }
        }
        public virtual Quaternion Rotation { get; set; }
        public virtual Vector2 Scale { get; set; }

        public int VisualChildCount { get; set; }

        public Visual VisualParent { get; set; }

        public Visual()
        {
            Scale = Vector2.one;
        }

        public void Render()
        {
            OnRender(new DrawCanvas(Rect,Scale));
        }

        public virtual void OnRender(DrawCanvas drawContext)
        {

        }

    }
}
