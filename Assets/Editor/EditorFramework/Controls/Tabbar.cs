using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using EditorFramework.Controls;
using UnityEngine;

namespace EditorFramework.Controls {
    public class Tabbar:Control {

        public List<GUIContent> Items { get; set; }
        public int Selected { get; set; }

        private GUIContent selectedItem;
        public GUIContent SelectedItem
        {
            get
            {
                return selectedItem = Items[Selected];
            }
            set
            {
                if (Items.Contains(value)) {
                    Selected = Items.IndexOf(value);
                    selectedItem = value;
                }
            }
        }

        public Tabbar() {

            Items = new List<GUIContent>();

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
