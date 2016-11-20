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

            GUILayout.BeginArea(Position, this, Style);

            GUILayout.BeginHorizontal();

            foreach (var item in Items)
                item.RenderLayout();

            GUILayout.EndHorizontal();

            GUILayout.EndArea();

            base.Render();
        }

        public override void RenderLayout()
        {
            if (Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal(this,Style,LayoutOptions);
                foreach (var item in Items)
                    item.RenderLayout();
                GUILayout.EndHorizontal();
            }
            else if (Orientation == Direction.Vertical)
            {
                GUILayout.BeginVertical(this, Style, LayoutOptions);
                foreach (var item in Items)
                    item.RenderLayout();
                GUILayout.EndVertical();
            }
            base.RenderLayout();
        }
    }
}
