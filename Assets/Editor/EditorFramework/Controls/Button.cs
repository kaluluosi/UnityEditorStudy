using System;
using UnityEngine;
using EditorFramework.Input;

namespace EditorFramework.Controls {
    public class Button : Control,IClickHandler {

        public bool Repeatable { get; set; }
        public Button() {
            Position = new Rect(0, 0, 100, 20);
            Style = "button";
        }

        public event EventHandler<MouseEventArgs> ClickEvent;

        protected virtual void OnClick() {
            if (ClickEvent != null)
                ClickEvent(this, new MouseEventArgs());
        }

        public override void Render() {

            if (Repeatable) {
                if (GUI.RepeatButton(Position, this)) 
                    OnClick();
            }
            else {
                if (GUI.Button(Position, this, Style)) 
                    OnClick();
            }


            base.Render();
        }

        public override void RenderLayout() {

            if (Repeatable) {
                if (GUILayout.RepeatButton(this, LayoutOptions)) 
                    OnClick();
            }else {
                if (GUILayout.Button(this, LayoutOptions)) 
                    OnClick();
            }

            base.RenderLayout();
        }

    }
}
