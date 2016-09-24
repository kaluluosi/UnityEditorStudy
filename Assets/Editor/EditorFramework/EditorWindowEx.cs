
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace EditorFramework
{
    /// <summary>
    /// 支持MDI的窗口 
    /// </summary>
    public abstract class EditorWindowEx : EditorWindow,IControlContainer,IWindowContainer
    {
        private List<Window> windows;
        private ControlCollection controls;

        public EditorWindowEx(){
            windows = new List<Window>();
            controls = new ControlCollection(null);
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
                return controls;
            }
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
        /// 绘制控件
        /// </summary>
        protected void DrawControls(){
            foreach(Control ctrl in controls){
                if(ctrl.Enable)
                    ctrl.Draw();
            }
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