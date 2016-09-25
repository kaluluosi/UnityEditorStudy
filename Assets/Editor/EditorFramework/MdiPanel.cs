using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEditor;

namespace EditorFramework
{
    public class MdiPanel:ContainerControl
    {

        public delegate void DrawWindowsCallback();
        public DrawWindowsCallback OnDrawWindows;

        public override void Draw()
        {
            EditorGUILayout.BeginVertical();

            OnDrawWindows();
            EditorGUILayout.EndVertical();

            Rect rect = GUILayoutUtility.GetLastRect();
            Handles.RectangleCap(ID, rect.position, new Quaternion(), rect.size.magnitude);

        }
    }
}
