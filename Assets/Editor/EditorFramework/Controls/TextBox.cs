using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace EditorFramework.Controls {
    public class TextBox : Control {

        public event EventHandler<TextChangedEventArgs> TextChangedEvent;

        public string Text { get; set; }

        public bool MultiLine { get; set; }

        public int MaxLength { get; set; }

        public TextBox() {
            Text = "";
            MaxLength = 180;
            Style = "textfield";
        }

        public override void Render() {
            string old = Text;

            if (MultiLine)
                Text = GUI.TextArea(Position, Text, MaxLength, Style);
            else
                Text = GUI.TextField(Position, Text, MaxLength, Style);

            if (old != Text)
                OnTextChanged(old,Text);

            base.Render();
        }

        private void OnTextChanged(string oldValue ,string newValue) {
            if(TextChangedEvent!=null)
                TextChangedEvent(this, new TextChangedEventArgs() { OldValue = oldValue, NewValue = Text });
        }

        public override void RenderLayout() {

            if (MultiLine)
                Text = GUILayout.TextArea(Text, MaxLength, Style, LayoutOptions);
            else
                Text = GUILayout.TextField(Text, MaxLength, Style, LayoutOptions);

            base.RenderLayout();
        }

    }
}
