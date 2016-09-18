
using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{

    public abstract class Window : Control
    {
        /// <summary>
        /// Title
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        public bool Draggable { get; set; }

        public Rect DragArea { get; set; }

        public bool AutoSize { get; set; }

        public sealed override void Draw()
        {
            if (AutoSize)
                Rect = GUILayout.Window(Id, Rect, DrawWindow, Title);
            else
                Rect = GUI.Window(Id, Rect, DrawWindow, Title);
        }

        private void DrawWindow(int id)
        {
            DrawContent();

            //拖拽判断
            if (Draggable)
            {
                if (DragArea.size != Vector2.zero){
                    GUI.DragWindow(DragArea);
                }
                else{
                    GUI.DragWindow();
                }
            }
        }

        /// <summary>
        /// 窗体内容绘制
        /// </summary>
        protected abstract void DrawContent();
    }

}