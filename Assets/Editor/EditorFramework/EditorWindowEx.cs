
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EditorFramework
{
    /// <summary>
    /// 支持MDI的窗口 
    /// </summary>
    public abstract class EditorWindowEx : EditorWindow,IControlContainer,IWindowContainer
    {
        private List<Window> windows;
        private ContainerControl containerControl;

        public EditorWindowEx(){
            windows = new List<Window>();
            containerControl = new ContainerControl();
        }

        public List<Window> Windows
        {
            get
            {
                return windows;
            }
        }

        public ControlCollection Controls{
            get{
                return containerControl.Controls;
            }
        }

        void OnGUI()
        {
            containerControl.Draw();
            DrawWindows();
        }


        /// <summary>
        /// 绘制窗口
        /// </summary>
        protected void DrawWindows()
        {
            BeginWindows();
            foreach (Window win in windows)
            {
                if (win.Enable)
                    win.Draw();
            }
            EndWindows();
        }


        /// <summary>
        /// 层叠窗口
        /// </summary>
        public void StackWindows(){
            //to do
        }

        /// <summary>
        /// 平铺窗口
        /// </summary>
        public void TileWindows(){
            //to do
        }

    }

}