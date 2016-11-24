using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace EditorFramework
{
    public static class MsgUtility
    {
        public static void ShowNotification(string msg)
        {
            EditorWindow.focusedWindow.ShowNotification(new GUIContent(msg));
        }

        public static void ShowNotification(string msg, string tooltip, string icon)
        {
            object resource = EditorGUIUtility.Load(icon);

            resource=resource==null?EditorGUIUtility.Load("Texture2D Icon"):resource;

            EditorWindow.focusedWindow.ShowNotification(new GUIContent(msg, resource as Texture, tooltip));
        }
    }
}
