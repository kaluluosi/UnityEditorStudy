using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel {
    public class VirtualStackPanel : Panel {

        public VirtualStackPanel() {
            Orientation = Direction.Vertical;
        }

        public Direction Orientation { get; set; }

        public override bool Initialized
        {
            get
            {
                return base.Initialized;
            }

            set
            {
                foreach (var item in Items)
                    item.Initialized = false;
                base.Initialized = value;
            }
        }

        public override void Render() {

            GUI.Box(Position, this, Style);
            foreach (var item in Items) {
                item.Render();
            }

            base.Render();
        }

        int count = 0;
        int rendercount = 0;
        public override void RenderLayout() {

            if (Initialized) {
                Render();
            }else {
                if (Orientation == Direction.Horiziontal) {
                    GUILayout.BeginHorizontal(this, Style, LayoutOptions);
                    foreach (var item in Items) {
                        item.RenderLayout();
                    }
                    GUILayout.EndHorizontal();
                }
                else if (Orientation == Direction.Vertical) {
                    GUILayout.BeginVertical(this, Style, LayoutOptions);
                    foreach (var item in Items) {
                        item.RenderLayout();
                    }
                    GUILayout.EndVertical();

                }
                base.RenderLayout();
            }
        }
    }
}
