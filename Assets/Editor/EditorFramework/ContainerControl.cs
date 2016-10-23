using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    public enum Dock
    {
        Left,
        Right,
        Top,
        Bottom,
        Fill,
        None
    }


    /// <summary>
    /// 容器控件
    /// </summary>
    public class ContainerControl : ScrollableControl
    {

        private static GUIStyle DockBox {
            get {
                GUIStyle boxStyle = new GUIStyle("box");
                boxStyle.border = new RectOffset();
                boxStyle.margin = new RectOffset();
                boxStyle.padding = new RectOffset();
                boxStyle.normal.background = null;
                return boxStyle;
            }
        }


        public ContainerControl() {
            Style = new GUIStyle();
        }

        protected Control[] GetTops() {
            return (from c in Controls where c.Dock == Dock.Top select c).ToArray();
        }

        protected Control[] GetBottoms() {
            return (from c in Controls where c.Dock == Dock.Bottom select c).ToArray();
        }

        protected Control[] GetRights() {
            return (from c in Controls where c.Dock == Dock.Right select c).ToArray();
        }

        protected Control[] GetLefts() {
            return (from c in Controls where c.Dock == Dock.Left select c).ToArray();
        }

        protected Control[] GetFills() {
            return (from c in Controls where c.Dock == Dock.Fill select c).ToArray();
        }

        protected Control[] GetNones() {
            return (from c in Controls where c.Dock == Dock.None select c).ToArray();
        }


        public override void Draw() {

            BeginScrollView();

            //Container
            GUILayout.BeginVertical();

            //Top
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            foreach(Control ctrl in GetTops())
                ctrl.Draw();
            GUILayout.EndVertical();
            DrawControlArea();

            //Mid
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            //Left
            GUILayout.BeginVertical(DockBox, GUILayout.ExpandHeight(true));
            foreach(Control ctrl in GetLefts())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Left
            DrawControlArea();

            //Fill
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            foreach(Control ctrl in GetFills())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Fill
            DrawControlArea();

            //GUILayout.FlexibleSpace();

            //Right
            GUILayout.BeginVertical(DockBox, GUILayout.ExpandHeight(true));
            foreach(Control ctrl in GetRights())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Right
            DrawControlArea();


            GUILayout.EndHorizontal();
            //End Mid
            DrawControlArea();


            //GUILayout.FlexibleSpace();

            //Bottom
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true));
            foreach(Control ctrl in GetBottoms())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Bottom
            DrawControlArea();


            GUILayout.EndVertical();
            //End Container
            DrawControlArea();


            foreach(Control ctrl in GetNones())
                ctrl.Draw();

            EndScrollView();
        }

        private void DrawControlArea() {
            if(EditorFrameworkUtility.IsDesignMode) {
                Rect rect = GUILayoutUtility.GetLastRect();
                Drawing.DrawRectangle(rect, Color.red);
            }
        }
    }
}
