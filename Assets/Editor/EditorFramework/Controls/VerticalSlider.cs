using UnityEngine;

namespace EditorFramework {
    public class VerticalSlider : SliderBase {

        public VerticalSlider() {
            SliderStyleName = "verticalslider";
            ThumbStyleName = "verticalsliderthumb";
        }

        public override void Render() {

            Value = GUI.VerticalSlider(Position, Value,MinValue, MaxValue, SliderStyle,ThumbStyle);
            base.Render();
        }

        public override void RenderLayout() {

            Value = GUILayout.VerticalSlider(Value, MinValue, MaxValue,SliderStyle,ThumbStyle, LayoutOptions);
            base.RenderLayout();
        }

    }
}
