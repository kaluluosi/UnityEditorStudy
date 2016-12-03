using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class StackPanel : Panel
    {

        public StackPanel()
        {
            Orientation = Direction.Vertical;
        }

        public Direction Orientation { get; set; }

        //         public override void Render() {
        // 
        //             GUILayout.BeginArea(Position, this, Style);
        // 
        //             GUILayout.BeginHorizontal();
        //             foreach (var item in Items) {
        //                 item.RenderLayout();
        //             }
        //             GUILayout.EndHorizontal();
        // 
        //             GUILayout.EndArea();
        // 
        //             base.Render();
        // 
        //         }

        //public override void RenderLayout() {

        //    AfterLayout();
        //}

        protected override void RenderContent()
        {
            if (Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal(this, Style, LayoutOptions);
                foreach (var item in Items)
                {
                    if(item.Visable)
                        item.RenderLayout();
                }
                GUILayout.EndHorizontal();
            }
            else if (Orientation == Direction.Vertical)
            {
                GUILayout.BeginVertical(this, Style, LayoutOptions);
                foreach (var item in Items)
                {
                    if (item.Visable)
                        item.RenderLayout();
                }
                GUILayout.EndVertical();
            }
        }

        public override Rect GetContentSize()
        {
            float height = 0;
            float width = 0;

            if (Orientation == Direction.Horiziontal)
            {
                height = Items.Max(item => item.GetContentSize().height);
                width = Items.Sum(item => item.GetContentSize().width);
            }
            else if (Orientation == Direction.Vertical)
            {
                height = Items.Sum(item => item.GetContentSize().height);
                width = Items.Max(item => item.GetContentSize().width);
            }


            return new Rect(0, 0, width, height);
        }
    }
}
