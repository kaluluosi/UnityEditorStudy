using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using EditorFramework.Controls;
using UnityEngine;

namespace EditorFramework.Controls {
    public class Tabbar:ItemsControl {


        public Tabbar() {
            Style = "button";
        }

        public override void Render() {

            Selected = GUI.Toolbar(Position, Selected, Items.ToArray(),Style);

            base.Render();
        }

        public override void RenderLayout() {

            Selected = GUILayout.Toolbar(Selected, Items.ToArray(), Style,LayoutOptions);

            base.RenderLayout();
        }

    }
}
