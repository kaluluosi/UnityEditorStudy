using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public abstract class Visual : GUIContent, IVisual {

        public event EventHandler RenderEvent;


        public static bool DebugMode  { get; set; }

        private string name;
        private Rect position;

        private string imagePath;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return text;
                else
                    return name;
            }
            set
            {
                name = value;
            }
        }
        public virtual Rect Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rect ScreenPosition
        {
            get
            {
                Vector2 pos = GUIUtility.GUIToScreenPoint(Position.position);
                return new Rect(pos, Position.size);
            }
        }
        public virtual Vector2 Size {
            get {
                return Position.size;
            }
        }
        public virtual Quaternion Rotation { get; set; }
        public virtual Vector2 Scale { get; set; }

        public int VisualChildCount { get; set; }

        public IVisual VisualParent { get; set; }

        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                Texture img = LoadImage(value);
                image = img;
            }
        }

        public float X
        {
            get
            {
                return position.x;
            }
            set
            {
                position.x = value;
            }
        }
        public float Y
        {
            get
            {
                return position.y;
            }

            set
            {
                position.y = value;
            }
        }

        public float Width
        {
            get
            {
                return position.width;
            }

            set
            {
                position.width = value;
            }
        }

        public float Height
        {
            get
            {
                return position.height;
            }

            set
            {
                position.height = value;
            }
        }

        public Visual()
        {
            Scale = Vector2.one;
        }


        /// <summary>
        /// 绘制控件,会调用OnRender方法。重写此方法的时候必须要 base.Render()。
        /// </summary>
        public virtual void Render(){
            OnRender(new DrawCanvas(Position,Scale));
        }

        /// <summary>
        /// 绘制控件的时候会调用此方法，用户可以在这个方法里用drawContext绘图。
        /// </summary>
        /// <param name="drawContext">绘图上下文</param>
        public virtual void OnRender(DrawCanvas drawContext) {

            if (DebugMode)
            {
                drawContext.DrawRectangle(new Rect(Vector2.zero, Size), Color.red);
                drawContext.Text(Size, Position.ToString(),Color.red);
            }

            if (RenderEvent != null)
                RenderEvent(this, new EventArgs());
        }


        protected Texture LoadImage(string path) {

            if (string.IsNullOrEmpty(path))
                return EditorGUIUtility.Load("Texture2D Icon") as Texture;


            object resource = EditorGUIUtility.Load(path);
            if (resource is Texture)
                return resource as Texture;
            else
                return EditorGUIUtility.Load("Texture2D Icon") as Texture;

        }

    }
}
