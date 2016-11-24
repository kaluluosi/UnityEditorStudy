using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditorFramework;
using EditorFramework.Controls;
using UnityEngine;

namespace EditorFramework.Controls
{

    public enum DisplayMode
    {
        Top,
        Bottom,
        None
    }

    public class Tabbar : ItemsControl
    {

        public DisplayMode Mode { get; set; }

        public Tabbar()
        {
            StyleName = "button";
            Mode = DisplayMode.None;

        }

        public override void Render()
        {

            if (Mode == DisplayMode.Top)
                if (SelectedItem != null)
                    SelectedItem.Render();

            Selected = GUI.Toolbar(Position, Selected, Items.ToArray(), Style);

            if (Mode == DisplayMode.Bottom)
                if (SelectedItem != null)
                    SelectedItem.Render();

            base.Render();
        }

        public override void RenderLayout()
        {
            if (Mode == DisplayMode.Top)
                if (SelectedItem != null)
                    SelectedItem.RenderLayout();

            Selected = GUILayout.Toolbar(Selected, Items.ToArray(), Style, LayoutOptions);

            if (Mode == DisplayMode.Bottom)
                if (SelectedItem != null)
                    SelectedItem.RenderLayout();

            base.RenderLayout();
        }

    }
}
