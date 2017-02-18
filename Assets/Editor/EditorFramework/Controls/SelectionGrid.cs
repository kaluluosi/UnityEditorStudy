using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using UnityEngine;

namespace EditorFramework {
    public class SelectionGrid:ItemsControl {
        public int Col { get;  set; }

        public SelectionGrid() {
            Col = 1;
            StyleName = "button";
        }

        public override void Render() {

            Selected = GUI.SelectionGrid(Position, Selected, Items.ToArray(), Col, Style);

            base.Render();
        }


        public override void RenderLayout() {

            Selected = GUILayout.SelectionGrid(Selected, Items.ToArray(), Col,Style, LayoutOptions);

            base.RenderLayout();
        }
    }
}
