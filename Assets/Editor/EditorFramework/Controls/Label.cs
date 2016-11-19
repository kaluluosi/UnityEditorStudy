using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Controls {
    public class Label : Control {

        public Label()
        {
            Style = "label";
        }

        public override void Render() {
            GUI.Label(Position, this,Style);

            base.Render();
        }
        public override void RenderLayout() {
            GUILayout.Label(this,Style, LayoutOptions);

            base.RenderLayout();
        }
    }
}
