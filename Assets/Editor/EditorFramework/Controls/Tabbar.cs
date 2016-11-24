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
            StyleName = "button";
        }

        public override void Render() {

            Selected = GUI.Toolbar(Position, Selected, Items.ToArray(),Style);
            if (SelectedItem != null)
                SelectedItem.Render();

            base.Render();
        }

        public override void RenderLayout() {

            Selected = GUILayout.Toolbar(Selected, Items.ToArray(), Style,LayoutOptions);

            if (SelectedItem != null)
                SelectedItem.RenderLayout();

            base.RenderLayout();
        }

    }
}
