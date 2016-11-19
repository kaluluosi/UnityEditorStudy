using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class StackPanel:Panel
    {

        public enum Direction
        {
            Horiziontal,
            Vertical
        }
        public Direction Orientation { get; set; }


        public override void Render()
        {
            GUI.BeginGroup(Position, this, Style);
            if(Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal(LayoutOptions);
                foreach (var item in Items)
                    item.RenderLayout();
                GUILayout.EndHorizontal();
            }
            GUI.EndGroup();
            base.Render();
        }

        public override void RenderLayout()
        {
            GUILayout.BeginHorizontal(LayoutOptions);
            foreach (var item in Items)
                item.RenderLayout();
            GUILayout.EndHorizontal();
            base.RenderLayout();
        }
    }
}
