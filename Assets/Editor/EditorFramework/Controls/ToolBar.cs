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
            Content = new GUIContent(Text, ToolTip);

            if (IgnoreLayout)
            {
                GUILayout.BeginArea(Rect,Content, Style);
                Controls.DrawAll();
                GUILayout.FlexibleSpace();
                GUILayout.EndArea();
            }else
            {
                GUILayout.BeginHorizontal(Content,Style);
                Controls.DrawAll();
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

        }
    }
}

