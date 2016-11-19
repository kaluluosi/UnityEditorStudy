using System;
using UnityEngine;

namespace EditorFramework.Controls
{

    public class Toolbar : ItemsControl
    {

        public Toolbar()
        {
            Style = "toolbar";
        }


        public override void Render()
        {

            GUI.BeginGroup(Position, this);
            GUILayout.BeginHorizontal(Style, GUILayout.Width(Width), GUILayout.Height(Height));
            foreach (var item in Items)
            {
                item.RenderLayout();
            }
            GUILayout.EndHorizontal();
            GUI.EndGroup();
            base.Render();
        }

        public override void RenderLayout()
        {
            GUILayout.BeginHorizontal(Style,LayoutOptions);
            foreach (var item in Items)
            {
                item.RenderLayout();
            }
            GUILayout.EndHorizontal();
            base.RenderLayout();
        }

    }
}
