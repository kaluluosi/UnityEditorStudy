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
                if (IsInVisableArea(item)) {
                    item.Render();
                }
            GUI.EndGroup();
            base.Render();
        }

        public override void RenderLayout()
        {
            var style = GUIStyle.none;
            if (DebugMode)
                style = "box";
            GUILayout.Box(this,style,LayoutOptions);
            Position =GUILayoutUtility.GetLastRect();

            GUI.BeginGroup(Position);
            foreach (var item in Items)
                if (IsInVisableArea(item)) {
                    item.Render();
                }
            GUI.EndGroup();

            base.RenderLayout();
        }

    }
}
