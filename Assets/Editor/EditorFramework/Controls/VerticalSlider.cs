﻿using UnityEngine;

namespace EditorFramework.Controls {
    public class VerticalSlider : SliderBase {

        public VerticalSlider() {
            SliderStyle = "verticalslider";
            ThumbStyle = "verticalsliderthumb";
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
