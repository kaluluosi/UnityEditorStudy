
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;


namespace EditorFramework
{
    public abstract class EditorWindowEx : EditorWindow
    {
        private List<Window> windows = new List<Window>();
        private List<Control> controls = new List<Control>();

        public List<Window> Windows
        {
            get
            {
                return windows;
            }
        }

        public List<Control> Controls{
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