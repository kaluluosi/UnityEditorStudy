using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Controls
{

    public class ToolBar : Control
    {

        public ToolBar()
        {
            Enable = true;
            Style = "toolbar";
        }

        public override void Draw()
        {
            if (IgnoreLayout)
            {
                GUILayout.BeginArea(Rect,new GUIContent(), Style);
                Controls.DrawAll();
                GUILayout.FlexibleSpace();
                GUILayout.EndArea();
            }else
            {
                GUILayout.BeginHorizontal(Style);
                Controls.DrawAll();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }
}

