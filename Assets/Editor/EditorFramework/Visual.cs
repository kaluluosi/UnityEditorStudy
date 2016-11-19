using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public abstract class Visual:GUIContent
    {
        //To do
        //publick VisualCollection _children;

        public string Name { get; set; }
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

        private string imagePath;
        public string ImagePath
        {
            get
            {
                return ImagePath;
            }
            set
            {
                imagePath = value;
                Texture img = LoadImage(value);
                image = img;
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
