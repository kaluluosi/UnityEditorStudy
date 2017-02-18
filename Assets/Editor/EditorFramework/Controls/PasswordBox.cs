using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework {
    public class PasswordBox:Control {

        public string Password { get; set; }
        public char MaskChar { get; set; }
        public int MaxLength { get; set; }

        public PasswordBox() {
            StyleName = "textfield";
            Password = "";
            MaskChar = '*';
            MaxLength = 100;
        }


        public override void Render() {

            Password = GUI.PasswordField(Position, Password, MaskChar,MaxLength,Style);

            base.Render();
        }


        public override void RenderLayout() {

            Password = GUILayout.PasswordField(Password, MaskChar,MaxLength,Style, LayoutOptions);

            base.RenderLayout();
        }
    }
}
