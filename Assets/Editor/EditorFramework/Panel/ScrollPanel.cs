using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace EditorFramework.Panel
{
    public class ScrollPanel : StackPanel
    {
        public ScrollPanel()
        {
            Orientation = Direction.Vertical;
            StyleName = "scrollview";
        }

        //         public Direction Orientation { get; set; }

        private Vector2 contentSize;
        public Vector2 ContentSize
        {
            get { return contentSize; }
        }
        public Vector2 ScrollPosistion { get; set; }

        protected override void UpdatePosition()
        {
            //当item有效并且 ScrollPanel Initialized 后计算 ContentSize
            if (Items.Count != 0 && Items != null&&Initialized)
            {
                //2016年11月25日:更完美的计算尺寸
                if (Orientation == Direction.Vertical)
                {
                    contentSize.y = Items.Sum(item => item.Height + item.Style.margin.top) +Items.Average(item=>(float)item.Style.margin.top);
                    contentSize.x = Items.Max(item => item.Width) + Items.Average(item=>(float)item.Style.margin.left)*2;
                }
                else if (Orientation == Direction.Horiziontal)
                {
                    contentSize.y = Items.Max(item => item.Height)+Items.Average(item=>(float)item.Style.margin.top)*2;
                    contentSize.x = Items.Sum(item => item.Width + item.Style.margin.left)+Items.Average(item=>(float)item.Style.margin.left);
                }
            }
            else 
            {
                //在开发ItemTool的时候发现 scrollview.Items.Clear()的时候 界面仍然有滚动条，
                //因此加了这段代码去重置掉 ContentSize
                contentSize = Vector2.zero;
            }

            if (Event.current.type == EventType.repaint)
            {


                Rect newRect = GUILayoutUtility.GetLastRect();

                initialized = true;

                //这里有个很奇怪的现象，当scrollPanel的布局方向是Horizontal的时候，Posistion每一次OnGUI height都会有2像素的偏差。
                //这会导致界面不断的初始化布局，从而导致横向滚动条上下跳动。
                //暂时没有解决办法，因此先用下面本方法解决。
                //2016年11月23日：发现是unity的bug
                //Debug.Log(Position);
                if (Mathf.Abs(Position.width - newRect.width) > 6 || Mathf.Abs(Position.height - newRect.height) > 6)
                {
                    Position = newRect;
                    initialized = false;
                    foreach (var item in Items)
                        item.Initialized = false;
                }

            }
        }


        //         public override void Render()
        //         {
        //             GUILayout.BeginArea(Position);
        // 
        //             RenderLayout();
        // 
        //             GUILayout.EndArea();
        // 
        //         }

        protected override void RenderContent()
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
                    {
                        item.Render();
                        //Debug.Log(item.Name + "看到你了");
                    }
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
                    {
                        item.Render();
                        //Debug.Log(item.Name + "看到你了");
                    }
                }
                GUILayout.EndVertical();
            }

            GUILayout.EndScrollView();

        }

        /// <summary>
        /// 判断item是否再scrollpanel的可视范围内
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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
