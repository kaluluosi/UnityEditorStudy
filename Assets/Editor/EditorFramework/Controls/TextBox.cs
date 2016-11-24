using System;
using UnityEngine;

namespace EditorFramework.Controls
{
    public class TextBox : Control {

        public event EventHandler<TextChangedEventArgs> TextChangedEvent;

        public Predicate<string> Validate = (str) => { return false; };
        private bool error=false;

        public bool MultiLine { get; set; }

        public int MaxLength { get; set; }

        public TextBox() {
            MaxLength = 180;
            StyleName = "textfield";
        }

        public override void Render() {
            string old = text;

            if (MultiLine)
                text = GUI.TextArea(Position, text, MaxLength, Style);
            else
                text = GUI.TextField(Position, text, MaxLength, Style);

            if (old != text)
            {
                OnTextChanged(old,text);
            }

            Check();

            base.Render();
        }

        private void OnTextChanged(string oldValue ,string newValue) {
            if(TextChangedEvent!=null)
                TextChangedEvent(this, new TextChangedEventArgs() { OldValue = oldValue, NewValue = text });
        }

        public override void RenderLayout() {
            string old = text;

            if (MultiLine)
                text = GUILayout.TextArea(text, MaxLength, Style, LayoutOptions);
            else
                text = GUILayout.TextField(text, MaxLength, Style, LayoutOptions);

            if (old != text)
            {
                OnTextChanged(old, text);
            }

            Check();

            base.RenderLayout();
        }

        private void Check()
        {
            error = Validate(text);

            if (error)
                Drawing.DrawRectangle(Position, Color.red);

        }

    }
}
