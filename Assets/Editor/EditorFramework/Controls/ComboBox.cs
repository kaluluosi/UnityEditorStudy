using System;
using System.Collections.Generic;
using System.Linq;
using EditorFramework;
using UnityEditor;
using UnityEngine;
using System.Text;
using System.Collections;

namespace EditorFramework.Controls
{
    public class ComboBox:ItemsControl
    {

        public ComboBox()
        {
            StyleName = "Popup";
        }


        public override void RenderLayout()
        {
            Selected = EditorGUILayout.Popup(this,Selected, Items.ToArray(),Style, LayoutOptions);
            base.RenderLayout();
        }

        public override void OnRender()
        {
            Selected = EditorGUI.Popup(Position, Selected, Items.ToArray(),Style);
            base.OnRender();
        }
    }
}
