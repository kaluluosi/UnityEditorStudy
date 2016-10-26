using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework {
    public class Label : ContentControl {

        public override void Render() {
            GUI.Label(Position, Content);

            if (Event.current.type == EventType.mouseDown && Event.current.button == 0 && IsMousePositionInside) {
                OnMouseLeftDown();
            }

            if (Event.current.type == EventType.mouseDown && Event.current.button == 1 && IsMousePositionInside) {
                OnMouseRightDown();
            }
        }

        public override void RenderLayout() {
            GUILayout.Label(Content, LayoutOptions);
            base.RenderLayout();
        }
    }
}
