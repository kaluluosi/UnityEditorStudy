using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Panels
{
    /// <summary>
    /// 虚拟滚动堆栈式面板
    /// </summary>
    public class VirtualScrollStackPanel:ScrollPanel
    {
        public VirtualScrollStackPanel()
        {
            Orientation = Direction.Vertical;
            StyleName = "scrollview";

            VerticalScrollBarVisibility = HorizontalScrollBarVisibility = true;
        }

        protected override void RenderContent()
        {

            ScrollPosistion = GUILayout.BeginScrollView(ScrollPosistion, Style, LayoutOptions);

            if (initialized)
            {
                float height = VerticalScrollBarVisibility?ContentSize.y:1;
                float widht = HorizontalScrollBarVisibility?ContentSize.x:1;

                GUILayout.Box("", GUIStyle.none, GUILayout.Height(height), GUILayout.Width(widht));

            }

            if (Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal();
                foreach (var item in Items)
                {
                    item.Height = Height - GUI.skin.horizontalScrollbar.fixedHeight-GUI.skin.horizontalScrollbar.margin.top -item.Style.margin.bottom - 4;
                    
                    if (!item.Visable)
                        continue;

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
                    item.Width = Width - GUI.skin.verticalScrollbar.fixedWidth -GUI.skin.verticalScrollbar.margin.left-item.Style.margin.right -4;

                    if (!item.Visable)
                        continue;

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
        /// 刷新重排内容
        /// </summary>
        public void Update()
        {
            initialized = false;
            foreach (var item in Items)
            {
                item.Initialized = false;
            }
            Repaint();
        }

        /// <summary>
        /// 判断item是否再scrollpanel的可视范围内
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override bool IsInView(Control item)
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
