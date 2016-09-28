using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    /// <summary>
    /// 带滚动条的控件
    /// </summary>
    public abstract class ScrollableControl : Control
    {
        /// <summary>
        /// 滚动位置
        /// </summary>
        public Vector2 ScrollPosition { get; set; }

        /// <summary>
        /// 是否显示滚动条
        /// </summary>
        public bool AutoScroll { get; set; }

        public void BeginScrollView()
        {
            if (AutoScroll)
                ScrollPosition = GUILayout.BeginScrollView(ScrollPosition, GetGUILayoutOptions());
        }

        public void EndScrollView()
        {
            if (AutoScroll)
                GUILayout.EndScrollView();
        }
    }
}
