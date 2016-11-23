

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

            OnRender(new DrawCanvas(Position));
            CheckMouseEvent();
        }

        public override void RenderLayout()
        {
            GUILayout.Box("",GUIStyle.none, LayoutOptions);
            GUI.BeginGroup(Position, this, Style);
            foreach (var item in Items)
                item.Render();
            GUI.EndGroup();
            AfterLayout();
        }

    }
}
