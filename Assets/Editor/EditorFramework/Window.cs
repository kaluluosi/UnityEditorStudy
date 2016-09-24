
using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    
    public abstract class Window :Control
    {


        public Window(string title) {
            Title = title;
        }

        public Window(){
                Title = "未命名";
        }

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
                Rect = GUILayout.Window(ID, Rect, DrawWindow, Title);
            else
                Rect = GUI.Window(ID, Rect, DrawWindow, Title);
        }

        private void DrawWindow(int id)
        {

            //基本窗体内容绘制
            DrawContent();

            //绘制控件
            foreach(Control ctrl in Controls) {
                ctrl.Draw();
            }

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