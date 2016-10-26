using System;
using UnityEngine;
using EditorFramework.Input;

namespace EditorFramework {
    public class Button : ContentControl {
        public Button() {
            Position = new Rect(0, 0, 100, 20);
            Style = "button";
        }

        public override void Render() {
            if (GUI.Button(Position, Content, Style)) {
                OnClick();
                OnMouseLeftDown();
            }
        }

        public override void RenderLayout() {
            if(GUILayout.Button(Content, LayoutOptions)) {
                OnClick();
                OnMouseLeftDown();
            }
            base.RenderLayout();
        }

    }
}
