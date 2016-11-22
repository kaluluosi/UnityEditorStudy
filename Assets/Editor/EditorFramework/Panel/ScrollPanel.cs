using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class ScrollPanel : Panel
    {
        public ScrollPanel()
        {
            Orientation = Direction.Vertical;
            Style = "scrollview";
        }

        public Direction Orientation { get; set; }

        private Vector2 contentSize;
        public Vector2 ContentSize
        {
            get { return contentSize; }
        }
        public Vector2 ScrollPosistion { get; set; }

        protected override void UpdatePosition()
        {
            if (Event.current.type == EventType.repaint)
            {

                if (Items.Count != 0)
                {
                    if (Orientation == Direction.Vertical)
                    {
                        contentSize.y = Items.Sum(item => item.Height + item.Style.margin.top) + 4;
                        contentSize.x = Items.Max(item => item.Width) + 3;
                    }
                    else if (Orientation == Direction.Horiziontal)
                    {
                        contentSize.y = Items.Max(item => item.Height) +4+4;
                        contentSize.x = Items.Sum(item => item.Width + item.Style.margin.left) +4;
                    }
                }

                Rect newRect = GUILayoutUtility.GetLastRect();

                initialized = true;

                //这里有个很奇怪的现象，当scrollPanel的布局方向是Horizontal的时候，Posistion每一次OnGUI height都会有2像素的偏差。
                //这会导致界面不断的初始化布局，从而导致横向滚动条上下跳动。
                //暂时没有解决办法，因此先用下面本方法解决。
//                 Debug.Log(Position);
                if (Mathf.Abs(Position.width-newRect.width)>6||Mathf.Abs(Position.height-newRect.height)>6)
                {
                    Position = newRect;
                    initialized = false;
                    foreach (var item in Items)
                        item.Initialized = false;
                }

            }
        }


        public override void Render()
        {
            GUILayout.BeginArea(Position);

            RenderLayout();

            GUILayout.EndArea();

        }

        public override void RenderLayout()
        {
            ScrollPosistion = GUILayout.BeginScrollView(ScrollPosistion, Style, LayoutOptions);

            if (initialized)
            {
//                 Debug.Log("ContentSize:" + ContentSize);
                //                 Debug.Log("Position:"+Position);
                GUILayout.Box("", "scrollview", GUILayout.Height(ContentSize.y), GUILayout.Width(ContentSize.x));
            }

            if (Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal();
                foreach (var item in Items)
                {
                    if (!item.Initialized)
                    {
                        item.RenderLayout();
                    }
                    else if (IsInView(item))
                        item.Render();
                }
                GUILayout.EndHorizontal();
            }
            else if (Orientation == Direction.Vertical)
            {
                GUILayout.BeginVertical();
                foreach (var item in Items)
                {
                    if (!item.Initialized)
                    {
                        item.RenderLayout();
                    }
                    else if (IsInView(item))
                        item.Render();
                }
                GUILayout.EndVertical();
            }

            GUILayout.EndScrollView();

            base.RenderLayout();
        }

        public bool IsInView(Control item)
        {
            float y = ScrollPosistion.y - item.Height;
            float y_end = y + Height + item.Height;
            float x = ScrollPosistion.x - item.Width;
            float x_end = x + Width + item.Width;
            bool inXRange = item.X > x && item.X < x_end;
            bool inYRange = item.Y > y && item.Y < y_end;
            return inYRange && inXRange;
        }
    }
}
