using System;
using UnityEngine;
using EditorFramework.Input;

namespace EditorFramework.Controls
{
    public class Button : Control, IClickHandler
    {
        public event EventHandler<MouseEventArgs> ClickEvent;

        public bool Repeatable { get; set; }
        public Button()
        {
            StyleName = "button";
        }

        public Button(string text) : this()
        {
            this.text = text;
        }


        protected virtual void OnClick()
        {
            if (ClickEvent != null)
                ClickEvent(this, new MouseEventArgs());
        }

        public override void Render()
        {

            if (Repeatable)
            {
                if (GUI.RepeatButton(Position, this, Style))
                    OnClick();
            }
            else
            {
                if (GUI.Button(Position, this, Style))
                    OnClick();
            }

            base.Render();
        }

        public override void RenderLayout()
        {

            if (Repeatable)
            {
                if (GUILayout.RepeatButton(this, Style, LayoutOptions))
                    OnClick();
            }
            else
            {
                if (GUILayout.Button(this, Style, LayoutOptions))
                    OnClick();
            }

            base.RenderLayout();
        }

    }
}
