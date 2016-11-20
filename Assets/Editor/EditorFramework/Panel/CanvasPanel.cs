﻿

using UnityEditor;
using UnityEngine;

namespace EditorFramework.Panel
{
    /// <summary>
    /// 基本面板，绝对定位,没有对内容布局
    /// </summary>
    public class CanvasPanel : Panel
    {

        public override void Render()
        {
            GUI.BeginGroup(Position, this, Style);
            foreach (var item in Items)
            {
                item.Render();
            }
            GUI.EndGroup();
            base.Render();
        }

        public override void RenderLayout()
        {
            GUILayout.Box(this,GUIStyle.none,LayoutOptions);
            Rect boxRect = GUILayoutUtility.GetLastRect();
            GUI.BeginGroup(boxRect);
            foreach (var item in Items)
            {
                item.Render();
            }
            GUI.EndGroup();
            base.RenderLayout();
        }

    }
}
