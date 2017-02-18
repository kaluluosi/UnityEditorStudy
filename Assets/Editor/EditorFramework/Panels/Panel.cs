using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using EditorFramework;

namespace EditorFramework.Panels
{
    /// <summary>
    /// 面板容器基类
    /// </summary>
    public abstract class Panel : Control,IControlContainer
    {
        public Panel()
        {
            items = new ControlCollection(this);
        }

        private ControlCollection items;
        public virtual ControlCollection Items {
            get { return items; }
            set { items = value; }
        }

        /// <summary>
        /// 判断item是不是在父容器的可视范围内
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool IsInView(Control item)
        {
            Rect rect = item.Position;
            Rect area = new Rect() { position = Vector2.zero,size = Size };

            Vector2 p1 = rect.position;
            Vector2 p2 = new Vector2(rect.x + rect.width, rect.y);
            Vector2 p3 = new Vector2(rect.x, rect.y + rect.height);
            Vector2 p4 = new Vector2(rect.x + rect.width, rect.y + rect.height);

            bool result = area.Contains(p1) || area.Contains(p2) || area.Contains(p3) || area.Contains(p4);

            return result;
        }


        public override void Render()
        {
            GUILayout.BeginArea(Position);

            RenderContent();

            GUILayout.EndArea();

        }

        public override void RenderLayout()
        {
            RenderContent();
            base.RenderLayout();
        }
        protected abstract void RenderContent();


    }
}
