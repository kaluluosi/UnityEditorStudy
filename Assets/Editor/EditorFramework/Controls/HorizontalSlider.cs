using UnityEngine;

namespace EditorFramework.Controls {
    public class HorizontalSlider:SliderBase {

        public HorizontalSlider() {
            SliderStyle = "horizontalslider";
            ThumbStyle = "horizontalsliderthumb";
        }

        public override void Render() {

            Value = GUI.HorizontalSlider(Position, Value,MinValue, MaxValue, SliderStyle,ThumbStyle);
            base.Render();
        }

        public override void RenderLayout() {

            Value = GUILayout.HorizontalSlider(Value, MinValue, MaxValue,SliderStyle,ThumbStyle, LayoutOptions);
            base.RenderLayout();
        }

    }
}
