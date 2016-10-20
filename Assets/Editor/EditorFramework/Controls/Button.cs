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

    public class MouseHoverEventArgs : EventArgs {
        public Button Source { get; private set; }
        public MouseHoverEventArgs(Button source) {
            Source = source;
        }
    }

    public class Button : Control
    {
        public event EventHandler<ClickEventArgs> Click;
        public event EventHandler<MouseHoverEventArgs> MouseHover;

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

        public override void Draw()
        {

            Content = new GUIContent(Text, ToolTip);

            if (IgnoreLayout)
            {
                if (GUI.Button(Rect,Content, Style))
                    OnClick();
            }
            else
            {
                if (GUILayout.Button(Content, options: GetGUILayoutOptions(), style: Style))
                    OnClick();
                //ͬ������Rect
                Rect = GUILayoutUtility.GetLastRect();
            }


            if (EditorFrameworkUtility.IsDesignMode)
                Drawing.DrawRectangle(Rect, Color.red);

            if (Rect.Contains(Event.current.mousePosition))
                OnMouseHover(); 


        }

        private void OnClick()
        {
            if (Click != null)
                Click(this, new ClickEventArgs(this));
        }

        private void OnMouseHover() {
            if (MouseHover != null)
                MouseHover(this, new MouseHoverEventArgs(this));
        }
    }
}


