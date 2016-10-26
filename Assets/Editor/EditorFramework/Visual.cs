using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public abstract class Visual
    {
        //To do
        //publick VisualCollection _children;

        public virtual Rect Position { get; set; }
        public virtual Rect Size {
            get {
                return new Rect(0, 0, Position.width, Position.height);
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

        public virtual void Render()
        {
            OnRender(new DrawCanvas(Position,Scale));
        }

        public virtual void OnRender(DrawCanvas drawContext) {

        }

        protected Texture LoadImage(string path) {
            if (string.IsNullOrEmpty(path)) return null;

            object resource = EditorGUIUtility.Load(path);

            if (resource is Texture)
                return resource as Texture;

            Debug.LogWarningFormat("{0} 资源不存在", path);

            return null;
        }


    }
}
