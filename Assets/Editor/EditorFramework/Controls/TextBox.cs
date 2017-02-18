using System;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    public class TextBox : Control
    {

        public event EventHandler<TextChangedEventArgs> TextChangedEvent;

        //输入值校验委托，如果值不对输入框会显示红框（或者别的做法）
        public Predicate<string> Validate = (str) => { return true; };
        public string ValidationMsg { get; set; }

        public bool MultiLine { get; set; }

        public TextBox()
        {

            StyleName = "textfield";
            ReadOnly = false;
        }

        public bool ReadOnly { get; set; }

        public override void Render()
        {

            if (ReadOnly)
            {
                EditorGUI.SelectableLabel(Position, text, Style);
            }
            else
            {
                string old = text;
                if (MultiLine)
                    text = EditorGUI.TextArea(Position, text, Style);
                else
                    text = EditorGUI.TextField(Position, text, Style);

                if (old != text)
                {
                    OnTextChanged(old, text);
                }

            }

            Check();

            base.Render();
        }

        private void OnTextChanged(string oldValue, string newValue)
        {
            if (TextChangedEvent != null)
                TextChangedEvent(this, new TextChangedEventArgs() { OldValue = oldValue, NewValue = text });
        }

        public override void RenderLayout()
        {
            if (ReadOnly)
            {
                EditorGUILayout.SelectableLabel(text, Style, LayoutOptions);
            }
            else
            {
                string old = text;

                if (MultiLine)
                    text = EditorGUILayout.TextArea(text, Style, LayoutOptions);
                else
                    text = EditorGUILayout.TextField(text, Style, LayoutOptions);

                if (old != text)
                {
                    OnTextChanged(old, text);
                }
            }


            Check();

            base.RenderLayout();
        }

        private void Check()
        {

            if (!Validate(text))
            {
                Drawing.DrawRectangle(Position, Color.red);
                MsgUtility.ShowNotification(ValidationMsg);
            }

        }

    }
}
