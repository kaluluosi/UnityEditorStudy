

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
                item.Render();
            GUI.EndGroup();

            CheckMouseEvent();
            OnRender(new DrawCanvas(Position));
        }

        protected override void RenderContent()
        {
            GUILayout.Box(this, Style, LayoutOptions);
            Position = GUILayoutUtility.GetLastRect();

            GUI.BeginGroup(Position);
            foreach (var item in Items)
                item.Render();
            GUI.EndGroup();
        }

    }
}
