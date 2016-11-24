using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public abstract class Panel:ControlContainer
    {
        [Obsolete("没什么卵用，因此废弃")]
        public bool IsInVisableArea(Control control) {

            Rect rect = control.Position;
            Rect area = new Rect() { position = Vector2.zero,size = Size };

            Vector2 p1 = rect.position;
            Vector2 p2 = new Vector2(rect.x + rect.width, rect.y);
            Vector2 p3 = new Vector2(rect.x, rect.y + rect.height);
            Vector2 p4 = new Vector2(rect.x + rect.width, rect.y + rect.height);

            bool result = area.Contains(p1) || area.Contains(p2) || area.Contains(p3) || area.Contains(p4);

//             if (DebugMode)
//                 Debug.Log(control.Name + " 在"+Name+" "+area+"内:" + result);
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
