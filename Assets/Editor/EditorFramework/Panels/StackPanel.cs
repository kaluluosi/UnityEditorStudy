using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorFramework.Panels
{
    /// <summary>
    /// 堆栈式面板
    /// </summary>
    public class StackPanel : Panel
    {

        public StackPanel()
        {
            Orientation = Direction.Vertical;
        }

        public Direction Orientation { get; set; }

        protected override void RenderContent()
        {
            if (Orientation == Direction.Horiziontal)
            {
                GUILayout.BeginHorizontal(this, Style, LayoutOptions);
                foreach (var item in Items)
                {
                    if (item.Visable)
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


        /// <summary>
        /// 计算并获取内容的大小
        /// 注1：Unity IMGUI系统的margin计算方式与其他UI框架不一样，如果AB两个空间相邻，那么A[margin]B，这个margin是A.margin.right和B.margin.left取最大的那个值。
        /// 注2：如果只是想要获得控件渲染大小应该用Size属性，ContentSize是获得控件除去margin外，要显示完所有内容的理想范围大小。
        /// </summary>
        public override Vector2 ContentSize
        {
            get
            {
                float height = AdaptHeight == AdaptMode.Fixed ? FixedHeight : -1;
                float width = AdaptWidth == AdaptMode.Fixed ? FixedWidth : -1;


                if (Orientation == Direction.Horiziontal)
                {
                    //计算高度
                    if (height == -1 && Items.Count != 0)
                        height = Items.Max(item => item.Height + item.Style.margin.top + item.Style.margin.bottom);
                    else
                        height = 0;

                    //计算宽度
                    if (width == -1 && Items.Count!=0)
                    {
                        for (int i = 0; i < Items.Count; i++)
                        {
                            Control curItem = Items[i];

                            float marginLeft = curItem.Style.margin.left;
                            if (i - 1 >= 0)
                            {
                                Control preItem = Items[i - 1];
                                marginLeft = Mathf.Max(preItem.Style.margin.right, marginLeft);
                            }

                            width += curItem.Width + marginLeft;
                        }
                        width += Items.Last().Style.margin.right;
                    }
                    else
                    {
                        width = 0;
                    }
                }
                else if (Orientation == Direction.Vertical)
                {
                    //计算高度
                    if (height == -1 && Items.Count!=0)
                    {
                        for (int i = 0; i < Items.Count; i++)
                        {
                            Control curItem = Items[i];

                            float marginTop = curItem.Style.margin.top;
                            if (i - 1 >= 0)
                            {
                                Control preItem = Items[i - 1];
                                marginTop = Mathf.Max(preItem.Style.margin.bottom, marginTop);
                            }

                            height += curItem.Height + marginTop;
                        }
                        height += Items.Last().Style.margin.bottom;
                    }
                    else
                    {
                        height = 0;
                    }

                    //计算宽度
                    if (width == -1 && Items.Count != 0)
                        width = Items.Max(item => item.Width + item.Style.margin.left + item.Style.margin.right);
                    else
                        width = 0;
                }

                return new Vector2(width, height);

            }
        }
    }
}
