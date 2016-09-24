using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Controls
{
    public class ClickEventArgs:EventArgs
    {
        public Button Source { get;private set; }
        public ClickEventArgs(Button source)
        {
            Source = source;
        }
    }

    public class Button : Control
    {
        public static Vector2 DefaultSize = new Vector2(100, 30);

        public Button(string text)
        {
            Text = text;
            Style = "button";
        }

        public Button(string text, string tooltip) : this(text)
        {
            ToolTip = tooltip;
        }

        public event EventHandler<ClickEventArgs> Click;

        public override void Draw()
        {
            if (IgnoreLayout)
            {
                if (GUI.Button(Rect, new GUIContent(Text, ToolTip), Style))
                    OnClick();
            }
            else
            {
                if (GUILayout.Button(new GUIContent(Text, ToolTip), options: GetGUILayoutOptions(), style: Style))
                    OnClick();
            }

        }

        private void OnClick()
        {
            if (Click != null)
                Click(this, new ClickEventArgs(this));
        }
    }
}


