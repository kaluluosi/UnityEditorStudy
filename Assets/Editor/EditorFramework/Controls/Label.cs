using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Controls {
    public class Label : Control {

        public bool Selectable { get; set; }

        public Label(string text):this() {
            this.text = text;
        }

        public Label()
        {
            StyleName = "label";
        }

        public override void Render() {
            if (Selectable)
            {
                EditorGUI.SelectableLabel(Position, text,Style);
            }
            else
            { 
                GUI.Label(Position, this,Style);
            }

            base.Render();
        }
        public override void RenderLayout() {

            if (Selectable)
            {
                AdaptHeight = AdaptMode.Fixed;
                FixedHeight = ContentSize.y;
                EditorGUILayout.SelectableLabel(text, Style, LayoutOptions);
            }
            else
            {
                GUILayout.Label(this, Style, LayoutOptions);
            }

            base.RenderLayout();
        }

        public static implicit operator Label(string text)
        {
            return new Label(text);
        }
    }
}
