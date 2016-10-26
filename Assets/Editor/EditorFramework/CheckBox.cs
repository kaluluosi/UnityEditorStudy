using UnityEngine;

namespace EditorFramework {
    public class CheckBox : ContentControl {
        public bool IsChecked { get; set; }

        public CheckBox() {
            Style = "toggle";
        }

        public override void Render() {
            IsChecked = GUI.Toggle(Position, IsChecked, Content, Style);
            base.Render();
        }

        public override void RenderLayout() {
            IsChecked = GUILayout.Toggle(IsChecked, Content,Style, LayoutOptions);
            base.RenderLayout();
        }
    }
}
