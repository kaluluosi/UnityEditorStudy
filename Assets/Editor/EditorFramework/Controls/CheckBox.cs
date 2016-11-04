using System;
using EditorFramework.Input;
using UnityEngine;

namespace EditorFramework.Controls {
    public class CheckBox : Control {
        public bool IsChecked { get; set; }

        public event EventHandler<CheckedEventArgs> CheckedEvent;

        public CheckBox() {
            Style = "toggle";
        }

        public event EventHandler<MouseEventArgs> ClickEvent;

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
            IsChecked = GUILayout.Toggle(IsChecked, this,Style, LayoutOptions);

            base.RenderLayout();
        }

        public void OnClick() {
            if (ClickEvent != null)
                ClickEvent(this, new MouseEventArgs());
        }
    }
}
