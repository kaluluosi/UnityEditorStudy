﻿using System;
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
    public class ContainerControl:Control
    {

        private Control[] GetTops()
        {
            return (from c in Controls where c.Dock == Dock.Top select c).ToArray();
        }

        private Control[] GetBottoms()
        {
            return (from c in Controls where c.Dock == Dock.Bottom select c).ToArray();
        }

        private Control[] GetRights()
        {
            return (from c in Controls where c.Dock == Dock.Right select c).ToArray();
        }

        private Control[] GetLefts()
        {
            return (from c in Controls where c.Dock == Dock.Left select c).ToArray();
        }

        private Control[] GetFills()
        {
            return (from c in Controls where c.Dock == Dock.Fill select c).ToArray();
        }

        private Control[] GetNones()
        {
            return (from c in Controls where c.Dock == Dock.None select c).ToArray();
        }


        public override void Draw()
        {
            //Container
            GUILayout.BeginVertical();

            //Top
            GUILayout.BeginVertical();
            foreach (Control ctrl in GetTops())
                ctrl.Draw();
            GUILayout.EndVertical();


            //Mid
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            //Left
            GUILayout.BeginVertical();
            foreach (Control ctrl in GetLefts())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Left

            //Fill
            GUILayout.BeginVertical();
            foreach (Control ctrl in GetFills())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Fill

            GUILayout.FlexibleSpace();


            //Right
            GUILayout.BeginVertical();
            foreach (Control ctrl in GetRights())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Right


            GUILayout.EndHorizontal();
            //End Mid

            //GUILayout.FlexibleSpace();
            
            //Bottom
            GUILayout.BeginVertical();
            foreach (Control ctrl in GetBottoms())
                ctrl.Draw();
            GUILayout.EndVertical();
            //End Bottom


            GUILayout.EndVertical();
            //End Container

            foreach (Control ctrl in GetNones())
                ctrl.Draw();

        }
    }
}