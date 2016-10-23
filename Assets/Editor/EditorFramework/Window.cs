
using EditorFramework.Container;
using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{


    public abstract class Window : Panel
    {


        public Window(string title)
        {
            Title = title;
        }

        public Window():this("未命名")
        {
           
        }

        /// <summary>
        /// Title
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        public bool Draggable { get; set; }

        public Rect DragArea { get; set; }

        public EditorWindow Parent { get; set; }

        public sealed override void Draw()
        {
            if (AutoSize)
                Rect = GUILayout.Window(ID, Rect, DrawWindow, Title);
            else
                Rect = GUI.Window(ID, Rect, DrawWindow, Title);
        }

        private void DrawWindow(int id)
        {

            //基本窗体内容绘制
            base.Draw();

            //Controls.DrawAll();
            //拖拽判断
            if (Draggable)
            {
                if (DragArea.size != Vector2.zero)
                {
                    GUI.DragWindow(DragArea);
                }
                else
                {
                    GUI.DragWindow();
                }
            }
        }


    }

}