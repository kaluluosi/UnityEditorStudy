using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorFramework.Panel {
    public class StackPanel : Panel {

        public StackPanel() {
            Orientation = Direction.Vertical;
        }

        public Direction Orientation { get; set; }

        public override void Render() {

            GUILayout.BeginArea(Position, this, Style);

            GUILayout.BeginHorizontal();
            foreach (var item in Items) {
                item.RenderLayout();
            }
            GUILayout.EndHorizontal();

            GUILayout.EndArea();

            base.Render();

        }

        public override void RenderLayout() {
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
