﻿using UnityEngine;

namespace EditorFramework.Controls {
    public class VerticalScrollBar : ScrollBarBase {

        public VerticalScrollBar() {
            Style = "verticalscrollbar";
        }

        public override void Render() {

            Value = GUI.VerticalScrollbar(Position, Value, BarSize, MinValue, MaxValue, Style);
            base.Render();
        }

        public override void RenderLayout() {

            Value = GUILayout.VerticalScrollbar(Value, BarSize, MinValue, MaxValue, Style, LayoutOptions);
            base.RenderLayout();
        }
    }
}
