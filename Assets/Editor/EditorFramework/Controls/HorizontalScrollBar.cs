using UnityEngine;

namespace EditorFramework.Controls {
    public class HorizontalScrollBar : ScrollBarBase {

        public HorizontalScrollBar() {
            Style = "horizontalscrollbar";
        }

        public override void Render() {

            Value = GUI.HorizontalScrollbar(Position, Value, BarSize, MinValue, MaxValue, Style);
            base.Render();
        }

        public override void RenderLayout() {

            Value = GUILayout.HorizontalScrollbar(Value, BarSize, MinValue, MaxValue, Style, LayoutOptions);
            base.RenderLayout();
        }
    }
}
