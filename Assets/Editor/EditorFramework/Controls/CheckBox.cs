using System;
using EditorFramework.Input;
using UnityEngine;

namespace EditorFramework {
    public class CheckBox : Control {
        public event EventHandler<CheckedEventArgs> CheckedEvent;

        public bool IsChecked { get; set; }

        public CheckBox() {
            StyleName = "toggle";
        }

        public CheckBox(string text) : this() {
            this.text = text;
        }

        public override void Render() {

            bool old = IsChecked;
            IsChecked = GUI.Toggle(Position, IsChecked, this, Style);
            if (old != IsChecked)
                OnChecked(old, IsChecked);

            base.Render();
        }

        private void OnChecked(bool old, bool _new) {
            if (CheckedEvent != null)
                CheckedEvent(this, new CheckedEventArgs() { OldValue = old, NewValue = _new });
        }

        public override void RenderLayout() {
            bool old = IsChecked;

            IsChecked = GUILayout.Toggle(IsChecked, this,Style, LayoutOptions);

            if (old != IsChecked)
                OnChecked(old, IsChecked);

            base.RenderLayout();
        }

    }
}
